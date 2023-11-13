return await Bootstrapper
    .Factory
    .CreateDocs(args)
    .AddSourceFiles("../FlexMotion/Runtime/**/*.cs")
    .DeployToGitHubPagesBranch(
        "MoArtis",
        "Unity-SV-FlexMotion-Website",
        Config.FromSetting<string>("GITHUB_TOKEN"),
        "main")
    .RunAsync();