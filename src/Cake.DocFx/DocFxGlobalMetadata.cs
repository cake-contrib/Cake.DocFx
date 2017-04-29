namespace Cake.DocFx
{
    /// <summary>
    /// Constants for metadata keys.
    /// </summary>
    public static class DocFxGlobalMetadata
    {
        /// <summary>
        /// Metadata key for setting the title.
        /// The value will be appended to each output page's head title.
        /// </summary>
        public const string AppTitle = "_appTitle";

        /// <summary>
        /// Metadata key for setting the footer text.
        /// If not specified DocFX's Copyright will be shown.
        /// </summary>
        public const string AppFooter = "_appFooter";

        /// <summary>
        /// Metadata key for setting the logo file's path from output root.
        /// If not specified DocFX's logo will be shown.
        /// Remember to also add file to resource.
        /// </summary>
        public const string AppLogoPath = "_appLogoPath";

        /// <summary>
        /// Metadata key for setting the favicon file's path from output root.
        /// If not specified DocFX's favicon will be shown.
        /// Remember to add file to resource.
        /// </summary>
        public const string AppFaviconPath = "_appFaviconPath";

        /// <summary>
        /// Metadata key for showing the search box on the top of each page.
        /// </summary>
        public const string EnableSearch = "_enableSearch";

        /// <summary>
        /// Metadata key for setting indicating whether to open a new tab when clicking an external link.
        /// Internal links always shows within the current tab.
        /// </summary>
        public const string EnableNewTab = "_enableNewTab";

        /// <summary>
        /// Metadata key for disabling the navigation bar on the top of each page.
        /// </summary>
        public const string DisableNavbar = "_disableNavbar";

        /// <summary>
        /// Metadata key for disabling the breadcrumb on the top of each page.
        /// </summary>
        public const string DisableBreadcrumb = "_disableBreadcrumb";

        /// <summary>
        /// Metadata key for disabling table of contents on the left of each page.
        /// </summary>
        public const string DisableToc = "_disableToc";

        /// <summary>
        /// Metadata key for disabling the affix bar on the right of each page.
        /// </summary>
        public const string DisableAffix = "_disableAffix";

        /// <summary>
        /// Metadata key for disabling the "View Source" and "Improve this Doc" buttons.
        /// </summary>
        public const string DisableContribution = "_disableContribution";

        /// <summary>
        /// Metadata key for customizing the "Improve this Doc" URL button for public contributors.
        /// Use repo to specify the contribution repository URL.
        /// Use branch to specify the contribution branch.
        /// Use path to specify the folder for new overwrite files.
        /// If not set, the Git URL and branch of the current Git repository will be used.
        /// </summary>
        public const string GitContribute = "_gitContribute";

        /// <summary>
        /// Metadata key for choosing the URL pattern of the generated link for "View Source" and "Improve this Doc".
        /// Supports <c>github</c> and <c>vso</c> currently.
        /// If not set, DocFX will try speculating the pattern from domain name of the Git URL.
        /// </summary>
        public const string GitUrlPattern = "_gitUrlPattern";
    }
}
