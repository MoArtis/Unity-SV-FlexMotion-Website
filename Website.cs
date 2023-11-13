return await Bootstrapper
    .Factory
    .CreateDocs(args)
    .DeployToGitHubPagesBranch(
        "MoArtis",
        "Unity-SV-FlexMotion-Website",
        Config.FromSetting<string>("GITHUB_TOKEN"),
        "main")
    .AddSourceFiles("../FlexMotion/Runtime/**/*.cs")
    .RunAsync();