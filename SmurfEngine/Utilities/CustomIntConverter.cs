using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmurfEngine.Utilities
{
    class CustomIntConverter : JsonConverter
    {
            public override bool CanRead
            {
                get
                {
                    return false;
                }
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
            }

            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(decimal) || objectType == typeof(float) || objectType == typeof(double));
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (CustomIntConverter.IsWholeValue(value))
                {
                    writer.WriteRawValue(JsonConvert.ToString(Convert.ToInt64(value)));
                }
                else
                {
                    writer.WriteRawValue(JsonConvert.ToString(value));
                }
            }

            private static bool IsWholeValue(object value)
            {
                if (value is decimal)
                {
                    decimal decimalValue = (decimal)value;
                    int precision = (Decimal.GetBits(decimalValue)[3] >> 16) & 0x000000FF;
                    return precision == 0;
                }
                else if (value is float || value is double)
                {
                    double doubleValue = (double)value;
                    return doubleValue == Math.Truncate(doubleValue);
                }

                return false;
            }
        }
    }
