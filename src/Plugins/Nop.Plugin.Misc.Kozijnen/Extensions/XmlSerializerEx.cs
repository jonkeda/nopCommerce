using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Nop.Plugin.Misc.Kozijnen.Extensions
{
    public static class XmlSerializerEx
    {
        public static T Load<T>(this string filename)
            where T : class
        {
            try
            {
                using (Stream stream = File.OpenRead(filename))
                {
                    var xs = XmlSerializer(typeof(T));
                    return xs.Deserialize(stream) as T;
                }
            }
            catch
            {
                // do nothing
            }
            return default;
        }

        public static object LoadFromText(this string text, Type type)
        {
            try
            {
                using (var stream = new StringReader(text))
                {
                    var xs = XmlSerializer(type);
                    return xs.Deserialize(stream);
                }
            }
            catch
            {
                //
            }
            return default;
        }


        public static T LoadFromText<T>(this string text)
            where T : class
        {
            try
            {
                using (var stream = new StringReader(text))
                {
                    var xs = XmlSerializer(typeof(T));
                    return xs.Deserialize(stream) as T;
                }
            }
            catch
            {
                //
            }
            return default;
        }

        private class SwUtf8 : StringWriter
        {
            public SwUtf8(StringBuilder sb) : base(sb)
            {
            }

            public override Encoding Encoding => Encoding.UTF8;
        }

        public static string Serialize(this object value)
        {
            var sb = new StringBuilder();
            using (StringWriter sw = new SwUtf8(sb))
            {
                var xs = XmlSerializer(value.GetType());
                xs.Serialize(sw, value);
                return sb.ToString();
            }
        }

        public static void Save<T>(string filename, T value)
        {
            using (var stream = File.Create(filename))
            {
                var xs = XmlSerializer(typeof(T));
                xs.Serialize(stream, value);
                stream.Flush();
                stream.Close();
            }
        }

        private static XmlSerializer XmlSerializer(Type type)
        {
            var xs = new XmlSerializer(type);
            xs.UnknownAttribute += Xs_UnknownAttribute;
            xs.UnknownElement += XsOnUnknownElement;
            xs.UnknownNode += Xs_UnknownNode;
            xs.UnreferencedObject += Xs_UnreferencedObject;
            return xs;
        }

        private static void Xs_UnreferencedObject(object sender, UnreferencedObjectEventArgs e)
        {
        }

        private static void Xs_UnknownNode(object sender, XmlNodeEventArgs e)
        {
        }

        private static void XsOnUnknownElement(object sender, XmlElementEventArgs e)
        {
        }

        private static void Xs_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
        }
    }
}
