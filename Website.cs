return await Bootstrapper
    .Factory
    .CreateDocs(args)
    .AddSourceFiles("../FlexMotion/Runtime/**/*.cs")
    .DeployToGitHubPages(
        "MoArtis",
        "https://moartis.github.io",
        Config.FromSetting<string>("GITHUB_TOKEN"),
        "main")
    .RunAsync();