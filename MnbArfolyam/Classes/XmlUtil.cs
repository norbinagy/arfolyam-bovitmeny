using System.IO;
using System.Xml.Serialization;

namespace MnbArfolyam.Classes
{
    public static class XmlUtil
    {

        /// <summary>
        /// Létrehozza a megadott típusú objektumot a megadott XML dokumentum alapján.
        /// </summary>
        /// <typeparam name="T">A létrehozandó objektum típusa.</typeparam>
        /// <param name="xml">Az XML dokumentum.</param>
        /// <returns>A kívánt objektum.</returns>
        public static T Deserialize<T>(string xml) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
