﻿using System.Collections.Generic;
using System.IO;

namespace TagsCloudContainer.TextParsing.FileWordsParsers
{
    public class TxtWordParser : IFileWordsParser
    {
        public IEnumerable<string> ParseFrom(string path)
        {
            var file = new StreamReader(path);
            var line = "";
            while ((line = file.ReadLine()) != null)
                yield return line;
        }
    }
}