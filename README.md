# Cake.DocFx

![nuget release](https://img.shields.io/nuget/vpre/Cake.DocFx.svg)

This Addin for the Cake Build Automation System allows you to generate a documentation website with [docfx](http://dotnet.github.io/docfx/index.html). More about Cake at http://cakebuild.net

## Use the addin

To use docfx in your cake file simply import it and the docfx tool. Then define a doc task.
```cake
#addin "Cake.DocFx"
#tool "docfx.console"

Task("doc").Does(() => DocFx());
```
>   Do not forget to load '#tool "docfx.console"' at top of your cake file. Otherwise, you can not run the `DocFx()` command. 



If the `docfx.json` file is anywhere else then the root directory you can pass in the location as parameter.

```cake
#addin "Cake.DocFx"
#tool "docfx.console"

Task("doc").Does(() => DocFx("./docs/docfx.json"));
```

>   **INFO**
>   
>   The `DocFx` command requires an existing `docfx.json` file. To bootstrap docfx use `docfx init` or `./tools/docfx.console/tools/docfx.exe init`.

## Build

To build this package we are using Cake.

On Windows PowerShell run:

```powershell
./build
```

On OSX/Linux run:
```bash
./build.sh
```

Run `-t pack` alias to create a nuget package.
