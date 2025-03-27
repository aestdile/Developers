using System.Text.Json;

namespace L9
{
    public class Developers
    {
        public int ID{get; set;} 
        public string Name{get; set;}
        public string Position{get; set;}
        public string Hobby{get; set;}
        public int Salary{get; set;}
        public string Company{get; set;}

        private const string FilePath="developers.json";

        public void AddDevelopers()
        {
            Console.Write("ID: ");
            int id=Convert.ToInt32(Console.ReadLine());

            Console.Write("Name: ");
            string name=Console.ReadLine();

            Console.Write("Position: ");
            string position=Console.ReadLine();

            Console.Write("Hobby: ");
            string hobby=Console.ReadLine();

            Console.Write("Salary: ");
            int salary=Convert.ToInt32(Console.ReadLine());

            Console.Write("Company: ");
            string  company=Console.ReadLine();

            Developers addDeveloper=new Developers()
            {
                ID=id,
                Name=name,
                Position=position,
                Hobby=hobby,
                Salary=salary,
                Company=company
            };

            List<Developers> developers=ReadDevelopersFromJson();
            developers.Add(addDeveloper);
            SaveUsersToJson(developers);
            Console.WriteLine();
            Console.WriteLine("Succesfully Joined!");

        }

        public List<Developers> ReadDevelopersFromJson()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Developers>(); 
            }

            string json=File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<Developers>>(json);
        }

        private static void SaveUsersToJson(List<Developers> developers)
        {
            string json=JsonSerializer.Serialize(developers, new JsonSerializerOptions{WriteIndented=true});

            File.WriteAllText(FilePath, json);
        }

    }
}