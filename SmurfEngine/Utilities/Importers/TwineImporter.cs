//using System;
//using System.Collections.Generic;

//namespace SmurfEngine.Utilities.TwineImporters
//{
//    class TwineImporter
//    {
//        public class TwineHtmlImporter : Importer
//        {
//            static TwineHtmlImporter()
//            {
//                //CradleAssetProcessor.RegisterImporter<TwineHtmlImporter>("html");
//            }

//            #region Transcoder handling
//            // --------------------------

//            static List<TranscoderDef> _transcoders = new List<TranscoderDef>();

//            class TranscoderDef
//            {
//                public int Weight;
//                public Type Type;
//            }

//            public static void RegisterTranscoder<T>(int weight = -1) where T : StoryFormatTranscoder, new()
//            {
//                _transcoders.Add(new TranscoderDef()
//                {
//                    Weight = weight >= 0 ? weight : _transcoders.Count,
//                    Type = typeof(T)
//                });
//            }
//            // --------------------------
//            #endregion

//            public override bool IsAssetRelevant()
//            {
//                foreach (TranscoderDef entry in _transcoders.OrderBy(ent => ent.Weight))
//                {
//                    var transcoder = (StoryFormatTranscoder)Activator.CreateInstance(entry.Type);
//                    transcoder.Importer = this;

//                    if (transcoder.RecognizeFormat())
//                    {
//                        this.Transcoder = transcoder;
//                        break;
//                    }
//                }

//                // If a transcoder recognized the format, use it. Otherwise this asset is not relevant
//                return this.Transcoder != null;
//            }
//        }
//    }
//}
