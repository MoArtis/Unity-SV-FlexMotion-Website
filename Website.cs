return await Bootstrapper
    .Factory
    .CreateDocs(args)
    .DeployToGitHubPagesBranch(
        "MoArtis",
        "https://moartis.github.io",
        Config.FromSetting<string>("GITHUB_TOKEN"),
        "main")
    .AddSourceFiles("../FlexMotion/Runtime/**/*.cs")
    .RunAsync();