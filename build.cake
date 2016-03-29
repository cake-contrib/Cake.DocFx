#addin "Cake.Xamarin"

// ARGUMENTS
var target = Argument("target", "default");
var configuration = Argument("configuration", "release");

var local = BuildSystem.IsLocalBuild;

// Define directories.
var sln = "Cake.DocFx.sln";
var output = Directory("./output");
var src = "./src/*";

var releaseNotes = ParseReleaseNotes(File("./ReleaseNotes.md"));
var projectTitle = "Cake.DocFx";
var owner = "Paul Reichelt";
var authors = owner + " and contributors";
var copyright = "Copyright 2016 (c) " + authors;

// version
var buildNumber = AppVeyor.Environment.Build.Number;
var version = releaseNotes.Version.ToString();
var semVersion = local ? version : (version + string.Concat("-build-", buildNumber));

var prerelease = false;

Setup(() => 
{
    if(!local)
        Information(string.Format("Building {0} Version: {1} on branch {2}", projectTitle, semVersion, AppVeyor.Environment.Repository.Branch));
    else 
        Information(string.Format("Building {0} Version: {1}", projectTitle, semVersion));
});

// TASKS
Task("clean")
    .Does(() =>
    {
        CleanDirectories(output);
        CleanDirectories(string.Format("./src/**/obj/{0}", configuration));
        CleanDirectories(string.Format("./src/**/bin/{0}", configuration));
    });

Task("restore")
    .Does(() => NuGetRestore(sln));

Task("patch-assembly-info")
    .Does(() =>
    {
        CreateAssemblyInfo("./src/Cake.DocFx/Properties/AssemblyInfo.cs", new AssemblyInfoSettings {
            Product = projectTitle,
            Version = version,
            FileVersion = version,
            InformationalVersion = semVersion,
            Copyright = copyright
        });
    });


Task("build")
    .IsDependentOn("restore")    
    .IsDependentOn("patch-assembly-info")
    .Does(() => 
    {
        if(IsRunningOnWindows())
            MSBuild(sln, cfg => cfg.SetConfiguration(configuration));
        else
            XBuild(sln, cfg => cfg.SetConfiguration(configuration));
    });
    
Task("rebuild")
    .IsDependentOn("clean")
    .IsDependentOn("build");

Task("pack")
    .Does(() => 
    {
        var artifacts = output + Directory("artifacts");
        CreateDirectory(artifacts);
        
        NuGetPack(new NuGetPackSettings 
        {
            Id                      = projectTitle,
            Version                 = prerelease ? semVersion : version,
            Title                   = projectTitle,
            Authors                 = new[] { authors },
            Owners                  = new[] { owner },
            Description             = "DocFx Addin for Cake Build Automation System",
            Summary                 = "The DocFx Addin for Cake allows you to generated API documentation directly from .NET source code.",
            ProjectUrl              = new Uri("https://github.com/reicheltp/Cake.DocFx"),
          //  IconUrl                 = new Uri("http://cdn.rawgit.com/SomeUser/TestNuget/master/icons/testnuget.png"),
            LicenseUrl              = new Uri("https://github.com/reicheltp/Cake.DocFx/blob/master/LICENSE.md"),
            Copyright               = copyright,
          //  ReleaseNotes            = new [] {"Bug fixes", "Issue fixes", "Typos"},
            Tags                    = new [] {"Cake", "Script", "Build", "DocFx", "Documentation" },
            RequireLicenseAcceptance= false,
            Symbols                 = false,
            NoPackageAnalysis       = true,
            Files                   = new [] 
            {
                new NuSpecContent {Source = "Cake.DocFx.dll", Target = "net45"},
                new NuSpecContent {Source = "Cake.DocFx.pdb", Target = "net45"},
                new NuSpecContent {Source = "Cake.DocFx.xml", Target = "net45"},
            },
            BasePath                = "./src/Cake.DocFx/bin/release",
            OutputDirectory         = artifacts
         });
    });

// default target is build
Task("default")
    .IsDependentOn("build");

Task("appveyor")
    .Does(() => 
    {
        if(local)
            throw new Exception("This target should only run from AppVoyer");
    
        RunTarget("clean");
        RunTarget("build");
    
        var branch = AppVeyor.Environment.Repository.Branch;
    
        if(branch == "master" || branch == "develop")
        {
            prerelease = branch != "master";
                
            RunTarget("pack");
        }
    });

// EXECUTION
RunTarget(target);