using Newtonsoft.Json;

namespace L9
{
    public class Changes
    {
        private string filePath = "developers.json";

        public void AllChanges()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Not found data!");
                return;
            }

            string jsonData = File.ReadAllText(filePath);
            List<Developers> developers = JsonConvert.DeserializeObject<List<Developers>>(jsonData);

            Console.WriteLine("\n New Updated Data:");
            Console.WriteLine("------------------------------------------------------");

            foreach (var dev in developers)
            {
                Console.WriteLine($"ID: {dev.ID}");
                Console.WriteLine($"Name: {dev.Name}");
                Console.WriteLine($"Position: {dev.Position}");
                Console.WriteLine($"Hobby: {dev.Hobby}");
                Console.WriteLine($"Salary: {dev.Salary}");
                Console.WriteLine($"Company: {dev.Company}");
                Console.WriteLine("------------------------------------------------------");
            }
        }
    }
}
