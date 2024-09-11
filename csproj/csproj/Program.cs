namespace csproj
{
    public static class MyExtensions
    {
        public static bool IsValid(this string str)
        {
            int nyito = 0;
            bool valid = false;
            bool helyes = true;
            str.ToList().ForEach(y => {
                if (y == ')')
                {
                    if (nyito == 0)
                    {
                        helyes = false;
                    }
                    else
                    {
                        nyito--;
                    }
                }
                if (y == '(')
                {
                    nyito++;
                }
            });
            if (nyito == 0 && helyes)
            {
                valid = true;
            }

            return valid;
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            int szabalyos = 0;
            File.ReadAllLines("input.txt").ToList().ForEach(x => {
                int nyito = 0;
                bool helyes = true;
                x.ToList().ForEach(y => {
                    if (y == ')')
                    {
                        if (nyito == 0)
                        {
                            helyes = false;
                        }
                        else {
                            nyito--;
                        }
                    }
                    if (y == '(')
                    {
                        nyito++;
                    }
                });
                if (nyito == 0 && helyes)
                {
                    szabalyos++;
                }
            });
            Console.WriteLine("\n1.feladat: "+szabalyos);

            Console.WriteLine("\n2.feladat:");
            int jo = 0;
            File.ReadAllLines("input.txt").ToList().ForEach(x =>
            {
                if (x.IsValid())
                    jo++;
            });
            Console.WriteLine(jo);
            Console.WriteLine("\n3.feladat");
            string legfiatalabb = File.ReadAllLines("people.csv").ToList().MinBy(x => x.Split(";")[2].Split("-")[1]);
            Console.WriteLine($"legfiatalabb személy:\n{legfiatalabb.Split(";")[0]} {legfiatalabb.Split(";")[1]}, {legfiatalabb.Split(";")[2].Split("-")[1].TrimStart('0')} éves");
            Console.WriteLine("---");
            string legidosebb = File.ReadAllLines("people.csv").ToList().MaxBy(x => x.Split(";")[2].Split("-")[1]);
            Console.WriteLine($"Legidősebb személy:\n{legidosebb.Split(";")[0]} {legidosebb.Split(";")[1]}, {legidosebb.Split(";")[2].Split("-")[1].TrimStart('0')} éves");
            Console.WriteLine("---");
            Console.WriteLine($"A fájlban szereplő személyek átlagos életkora: {File.ReadAllLines("people.csv").ToList().Average(x=> Convert.ToDouble(x.Split(";")[2].Split("-")[1]))} év.");

            Console.WriteLine("\n4.feladat");
            List<Person> emberek = new List<Person>();
            List<Dog> kutyak = new List<Dog>();
            File.ReadAllLines("people.csv").ToList().ForEach(x=> emberek.Add(new Person(x)));
            File.ReadAllLines("dogs.csv").ToList().ForEach(x => kutyak.Add(new Dog(x)));

            kutyak.ForEach(x => emberek.Where(y=> y.ID1 == x.Owner_ID).First().Dogs.Add(x));

            Person legtobbkutya = emberek.MaxBy(x=> x.Dogs.Count());
            Console.WriteLine($"{legtobbkutya.First_name} {legtobbkutya.Last_name} has {legtobbkutya.Dogs.Count()} dogs");
        }
    }
}
