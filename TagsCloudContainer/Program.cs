﻿
using Autofac;
using TagsCloudContainer.ApplicationRunning;
using TagsCloudContainer.CloudLayouters;
using TagsCloudContainer.CloudVisualizers;
using TagsCloudContainer.CloudVisualizers.BitmapMakers;
using TagsCloudContainer.CloudVisualizers.ImageSaving;
using TagsCloudContainer.TextParsing;
using TagsCloudContainer.TextParsing.CloudParsing;
using TagsCloudContainer.TextParsing.CloudParsing.ParsingRules;
using TagsCloudContainer.TextParsing.FileWordsParsers;

namespace TagsCloudContainer
{
    public static class Program
    {
        public static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TagsCloudMaker>().AsSelf();
            builder.RegisterType<ConsoleAppRunner>().As<IAppRunner>();
            builder.RegisterType<TagsCloud>().AsSelf();
            builder.RegisterType<CloudWordsParser>().As<ICloudWordsParser>();
            builder.RegisterType<CloudLayouter>().As<ICloudLayouter>();
            builder.RegisterType<CloudVisualizer>().As<ICloudVisualizer>();
            builder.RegisterType<ImageSaver>().As<IImageSaver>();
            builder.RegisterType<TxtWordParser>().As<IFileWordsParser>();
            builder.RegisterType<DefaultParsingRule>().As<ICloudWordParsingRule>();
            builder.RegisterType<DefaultBitmapMaker>().As<IBitmapMaker>();
            builder.RegisterType<SettingsManager>().AsSelf().SingleInstance();
            builder
                .Register(c => c.Resolve<SettingsManager>().GetLayouterSettings())
                .As<CloudLayouterSettings>();
            builder
                .Register(c => c.Resolve<SettingsManager>().GetWordsParserSettings())
                .As<CloudWordsParserSettings>();
            builder
                .Register(c => c.Resolve<SettingsManager>().GetVisualizerSettings())
                .As<CloudVisualizerSettings>();
            builder
                .Register(c => c.Resolve<SettingsManager>().GetImageSaverSettings())
                .As<ImageSaverSettings>();
            var container = builder.Build();
            container.Resolve<TagsCloudMaker>();
        }
    }
}