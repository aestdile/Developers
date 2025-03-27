using Newtonsoft.Json;

namespace L9
{
    public class AllDeveloprs
    {
        public void SeeAllDevelopers()
        {
            // barcha developerlarni ma'lumotlarini qaytarishim kerak
            string filePath = "developers.json";
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                List<Developers> developers = JsonConvert.DeserializeObject<List<Developers>>(jsonData);
                foreach (var developer in developers)
                {
                    Console.WriteLine($"ID: {developer.ID}");
                    Console.WriteLine($"Name: {developer.Name}");
                    Console.WriteLine($"Position: {developer.Position}");
                    Console.WriteLine($"Hobby: {developer.Hobby}");
                    Console.WriteLine($"Salary: {developer.Salary}");
                    Console.WriteLine($"Company: {developer.Company}");
                    Console.WriteLine("-----------------------------");
                }
            }
            else
            {
                Console.WriteLine("Informations not found!");
            }
        }
    }
}
