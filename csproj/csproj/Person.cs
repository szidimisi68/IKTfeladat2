using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csproj
{
    public class Person
    {
        string first_name;
        string last_name;
        string ID;
        List<Dog> dogs = new();

        public Person(string bekeres)
        {
            List<string> felbontott = bekeres.Split(";").ToList() ;
            this.first_name = felbontott[0];
            this.last_name = felbontott[1];
            this.ID = felbontott[2];
        }

        public string First_name { get => first_name; }
        public string Last_name { get => last_name; }
        public string ID1 { get => ID; }
        public List<Dog> Dogs { get => dogs; set => dogs = value; }
    }
}
