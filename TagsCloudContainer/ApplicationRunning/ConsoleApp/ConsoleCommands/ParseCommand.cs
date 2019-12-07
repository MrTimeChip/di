﻿using System;
using System.IO;
using TagsCloudContainer.TextParsing.CloudParsing.ParsingRules;
using TagsCloudContainer.TextParsing.FileWordsParsers;

namespace TagsCloudContainer.ApplicationRunning.ConsoleApp.ConsoleCommands
{
    public class ParseCommand : IConsoleCommand
    {
        private TagsCloud cloud;
        private SettingsManager manager;
        public ParseCommand(TagsCloud cloud, SettingsManager manager)
        {
            this.cloud = cloud;
            this.manager = manager;
        }
        public void Act(string[] args)
        {
            var path = string.Join("", args);
            if(!File.Exists(path)) throw new ArgumentException($"No file '{path}' found!");
            var extension = Path.GetExtension(path);
            var parser = WordsParser.GetParser(extension);
            manager.ConfigureWordsParserSettings(parser, path, new DefaultParsingRule());
            cloud.ParseWords();
            Console.WriteLine($"Successfully parsed words from: '{path}'");
        }

        public string Name => "Parse";
        public string Description => "Parse words from path";
        public string Arguments => "path";
    }
}