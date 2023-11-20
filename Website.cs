return await Bootstrapper
    .Factory
    .CreateDocs(args)
    .AddSourceFiles("../FlexMotion/Runtime/Core/**/*.cs")
    .AddSourceFiles("../FlexMotion/Runtime/Containers/**/*.cs")
    .AddSetting(Keys.LinksUseHttps, "true")
    .AddSetting(Statiq.Markdown.MarkdownKeys.MarkdownExtensions, "Bootstrap")
    .AddShortcode<CalloutShortCode>("Callout")
    .AddSetting(WebKeys.OptimizeContentFileNames, "false")
    .RunAsync();