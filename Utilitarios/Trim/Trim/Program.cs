using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Trim
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Name1 ";
            person.Other = " Other2 ";

            //Console.WriteLine(person.Name);
            Console.WriteLine(person.Other);
            Console.WriteLine(JsonConvert.SerializeObject(person));
            Console.WriteLine(JsonConvert.SerializeObject(person));
            Console.ReadKey();
        }
    }

    //[KnownType(typeof(Person))]
    [JsonConverter(typeof(UserConverter))]
    public class Person
    {
        public string Name { get; set; }
        public string Other { get; set; }
    }

    public class UserConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

            var stringProperties = value.GetType().GetProperties().Where(p => p.PropertyType == typeof(string));

            foreach (var stringProperty in stringProperties)
            {
                string currentValue = (string)stringProperty.GetValue(value, null);
                stringProperty.SetValue(value, currentValue.Trim(), null);
                writer.WriteValue(currentValue.Trim());
            }

            //Person user = (Person)value;

            //writer.WriteValue(user.Other.Trim());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Person user = new Person();
            user.Other = Convert.ToString(reader.Value).Trim();

            return user;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Person);
        }
    }

}
