using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Persister
    {
        public void SaveToFile(object obj, string filePath) // сохраняем объект в файл
        {
            var serialized = JsonConvert.SerializeObject(
                obj,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                }); // превратил объект в строку

            File.WriteAllText(filePath, serialized);  //записываем строковое значение в файл
        }

        public T LoadFromFile<T>(string filePath) // Загрузить из Файла объкт
        {
            var text = File.ReadAllText(filePath);
            var deserialized = JsonConvert.DeserializeObject<T>(
                text,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                }); // Загрузить из текста объект типа Т(любой тип)
            return deserialized;
        }
    }
}
