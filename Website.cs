return await Bootstrapper
    .Factory
    .CreateDocs(args)
    .AddSourceFiles("../FlexMotion/Runtime/**/*.cs")
    .AddSetting("LinkRoot", "Unity-SV-FlexMotion-Website")
    .RunAsync();