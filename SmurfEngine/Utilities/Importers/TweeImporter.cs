//using System;
//using System.IO;
//using System.Text.RegularExpressions;

//namespace SmurfEngine.Utilities.Importers
//{
//    class TweeImporter
//    {
//        static Regex rx_Passages = new Regex(@"^::\s(?<name>[^\]\|\r\n]+)(\s+\[(?<tags>[^\]]+)\])?\r?\n(?<body>.*?)(?=\r?\n::|\Z)",
//                                             RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.ExplicitCapture);

//        public override void Initialize()
//        {
//            string tweeSource = File.ReadAllText(this.AssetPath);

//            MatchCollection matches = rx_Passages.Matches(tweeSource);
//            if (matches.Count < 1)
//                throw new FormatException("Twee data could not be found.");

//            for (int i = 0; i < matches.Count; i++)
//            {
//                Match m = matches[i];

//                // Ignore images
//                if (m.Groups["tags"].Success && m.Groups["tags"].Value == "Twine.image")
//                    continue;

//                this.Passages.Add(new PassageData()
//                {
//                    Pid = i.ToString(),
//                    Name = m.Groups["name"].Value,
//                    Tags = m.Groups["tags"].Value,
//                    Body = m.Groups["body"].Value.Trim()
//                });
//            }

//            // Twee currently supports the Sugar transcoder only
//            this.Transcoder = new StoryFormats.Sugar.SugarTranscoder() { Importer = this };
//        }
//    }
//}
