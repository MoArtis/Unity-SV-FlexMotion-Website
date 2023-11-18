return await Bootstrapper
    .Factory
    .CreateDocs(args)
    .AddSourceFiles("../FlexMotion/Runtime/Core/**/*.cs")
    .AddSourceFiles("../FlexMotion/Runtime/Containers/**/*.cs")
    .AddSetting("LinksUseHttps", "true")
    .AddSetting(Statiq.Markdown.MarkdownKeys.MarkdownExtensions, "Bootstrap")
    .AddShortcode<CalloutShortCode>("Callout")
    .RunAsync();