using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Convertor
{
    internal class ReadFile
    {

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public string Read(string path)
        {
            if (File.Exists(path))
            {
               
                return File.ReadAllText(path);
            }
            else
            {
                
                return string.Empty;
            }
        }

        public List<Human> ReadText(string text, List<Human> humans)
        {
            humans = new List<Human>();

            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string name = parts[0].Trim();
                        string country = parts[1].Trim();
                        int age;
                        if (int.TryParse(parts[2].Trim(), out age))
                        {
                            humans.Add(new Human(name, country, age));
                        }
                    }
                }
                return humans;
            }

        public List<Human> ReadJson(string json, List<Human> humans)
        {
            humans = JsonConvert.DeserializeObject<List<Human>>(json);
           
            return humans;
        }

        public List<Human> ReadXml(string xml, List<Human> humans)
        {
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<Human>));
            using (StringReader reader = new StringReader(xml))
            {
                humans = (List<Human>)serializer.Deserialize(reader);
            }
            
            return humans;
        }
    
        public void SaveText(string path, List<Human> humans)
        {
            
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (var human in humans)
                    {
                        
                        string line = $"{human.name}, {human.country}, {human.age}";
                        sw.WriteLine(line);
                    }
                }
            
        }

        public void SaveJson(string path, List<Human> humans)
        { 
            string json = JsonConvert.SerializeObject(humans);
            File.WriteAllText(path, json);
        }

        public void SaveXml(string path, List<Human> humans)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Human>));
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fileStream, humans);
            }
            /*using (FileStream reader = new FileStream(path, FileMode.Open))
            {
                serializer.Serialize(reader, humans);
            }*/
        }

    }
}
