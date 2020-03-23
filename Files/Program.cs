using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            // Drive

            DriveInfo[] drives = DriveInfo.GetDrives();

            // Directory

            string path = @"D:\Test";
            string subPath = @"MyApp";

            DirectoryInfo dir = new DirectoryInfo(path);
            try
            {
                if (!dir.Exists)
                {
                    dir.Create();
                    dir.CreateSubdirectory(subPath);
                }                
            }
            catch (Exception)
            {
               
            }

            var subDirs = dir.GetDirectories();

            foreach (var item in subDirs)
            {
                //Console.WriteLine(item.Name);
            }

            //dir.Delete(true);


            // File

            FileInfo file = new FileInfo(path + @"\test.txt");
            file.Create();            
            //file.Delete();   

            using (StreamWriter sw = new StreamWriter(new FileStream("write_test.txt", FileMode.Append)))
            {
                while (true)
                {
                    string input = Console.ReadLine();

                    if (input == "")
                    {
                        break;
                    }

                    sw.WriteLine(input + " " + DateTime.Now.ToShortTimeString());
                }
            }

            //sw.Dispose();

            using(StreamReader sr = new StreamReader("write_test.txt"))
            {
                //string output2 = sr.ReadToEnd();
                //Console.WriteLine(output2);
                
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            
            // Serialize

            var p = new Person() { Id = 1, FirstName = "John", LastName = "Doe", Birthday = DateTime.Now, BankAccount = 2358721 };

            BinaryFormatter formatter = new BinaryFormatter();

            //using (FileStream fs = new FileStream("person.bin", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, p);
            //}

            //Person person = null;

            //using (FileStream fs = new FileStream("person.bin", FileMode.OpenOrCreate))
            //{
            //    person = (Person)formatter.Deserialize(fs);
            //}

            //XmlSerializer xml = new XmlSerializer(typeof(Person));

            //using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            //{
            //    xml.Serialize(fs, p);
            //}

            //using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            //{
            //    var person = xml.Deserialize(fs);
            //    Console.WriteLine(person);
            //}

            string output = JsonConvert.SerializeObject(p);

            Console.WriteLine(output);

            var person = JsonConvert.DeserializeObject<Person>(output);
            Console.WriteLine(person);
        }
    }
}
