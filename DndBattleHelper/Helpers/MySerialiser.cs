using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace DndBattleHelper.Helpers
{
    public class MySerialiser<T> where T : class
    {
        public static string Serialize(T obj)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            using (var sww = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(sww) { Formatting = Formatting.Indented })
                {
                    xsSubmit.Serialize(writer, obj);
                    return sww.ToString();
                }
            }
        }

        public static T Deserialize(string xml)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(xml))
            {
                var test = xsSubmit.Deserialize(stringReader) as T;

                if (test != null)
                {
                    return test;
                }
                else
                {
                    throw new Exception("Deserialisation failed");
                };
            }
        }
    }
}
