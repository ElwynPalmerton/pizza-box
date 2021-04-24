using System.IO;
using System.Xml.Serialization;
using sc = System.Console;

namespace PizzaBox.Storing.Repositories
{
    public class FileRepository
    {

        public T ReadFromFile<T>(string path) where T : class
        {
            try{
                var reader = new StreamReader(path);
                var xml = new XmlSerializer(typeof(T));

                return xml.Deserialize(reader) as T;
            }
            catch{
                return null;
            }

        }

        public bool WriteToFile<T>(string path, T items) where T: class
        {
            sc.WriteLine("path: " + path);
            try{
                var writer = new StreamWriter(path);
                var xml = new XmlSerializer(typeof(T));
                xml.Serialize(writer, items);
                return true;
            }
            catch (System.Exception e) {
                sc.WriteLine("Throw exception: " + e);
                return false;
            }
        }
    }
}