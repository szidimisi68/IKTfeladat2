using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csproj
{
    public class Dog
    {
        string name;
        string breed;
        string age;
        string owner_ID;

        public Dog(string adatok)
        {
            List<string> felbontott = adatok.Split(";").ToList();
            this.name = felbontott[0];
            this.breed = felbontott[1];
            this.age = felbontott[2];
            this.owner_ID = felbontott[3];
        }

        public string Name { get => name; }
        public string Breed { get => breed; }
        public string Age { get => age; }
        public string Owner_ID { get => owner_ID; set => owner_ID = value; }
    }
}
