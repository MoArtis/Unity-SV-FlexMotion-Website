return await Bootstrapper
    .Factory
    .CreateDocs(args)
    .AddSourceFiles("../FlexMotion/Runtime/Core/**/*.cs")
    .AddSourceFiles("../FlexMotion/Runtime/Containers/**/*.cs")
    .AddSetting("LinkRoot", "Unity-SV-FlexMotion-Website")
    .AddSetting(Statiq.Markdown.MarkdownKeys.MarkdownExtensions, "Bootstrap")
    .AddShortcode<CalloutShortCode>("Callout")
    .RunAsync();