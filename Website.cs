return await Bootstrapper
    .Factory
    .CreateDocs(args)
    .AddSourceFiles("../FlexMotion/Runtime/**/*.cs")
    .DeployToGitHubPagesBranch(
        "MoArtis",
        "https://moartis.github.io/Unity-SV-FlexMotion-Website",
        Config.FromSetting<string>("GITHUB_TOKEN"),
        "main")
    .RunAsync();