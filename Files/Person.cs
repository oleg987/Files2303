using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Files
{
    [Serializable]
    public class Person
    {
        //[NonSerialized]
        //private int? bankAcc;

        [JsonProperty("ИД")]
        public int Id { get; set; }

        [JsonProperty("Имя")]
        public string FirstName { get; set; }

        [JsonProperty("Фамилия")]
        public string LastName { get; set; }

        [JsonProperty("Дата рождения")]
        public DateTime Birthday { get; set; }

        [JsonIgnore]        
        public int? BankAccount { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{FirstName}\t{LastName}\t{Birthday.ToShortDateString()}\t{BankAccount}";
        }

        /*
                     {
               "Имя": "Иван",
               "Фамилия": "Иванов",
               "address": {
                   "streetAddress": "Московское ш., 101, кв.101",
                   "city": "Ленинград",
                   "postalCode": 101101
               },
               "phoneNumbers": [
                   "812 123-1234",
                   "916 123-4567"
               ]
            }
         */
    }
}
