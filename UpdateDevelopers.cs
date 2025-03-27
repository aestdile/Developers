using Newtonsoft.Json;

namespace L9
{
    public class UpdateDevelopers
    {
        private string filePath = "developers.json";

        public void UpdateDevelopersProperties()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Not found data!");
                return;
            }

            string jsonData = File.ReadAllText(filePath);
            List<Developers> developers = JsonConvert.DeserializeObject<List<Developers>>(jsonData);

            Console.Write("ID: ");
            int idToUpdate = Convert.ToInt32(Console.ReadLine());

            Developers devToUpdate = developers.Find(d => d.ID == idToUpdate);
            if (devToUpdate == null)
            {
                Console.WriteLine($"{idToUpdate} Developer is not found by ID!");
                return;
            }

            // Ma'lumotlarni yangilayman
            Console.WriteLine("If you don't want to update the data, leave it blank!");

            Console.Write("New Name: ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
                devToUpdate.Name = newName;

            Console.Write("New Position: ");
            string newPosition = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPosition))
                devToUpdate.Position = newPosition;

            Console.Write("New Hobby: ");
            string newHobby = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newHobby))
                devToUpdate.Hobby = newHobby;

            Console.Write("New Salary: ");
            string newSalaryStr = Console.ReadLine();
            if (int.TryParse(newSalaryStr, out int newSalary))
                devToUpdate.Salary = newSalary;

            Console.Write("New Company: ");
            string newCompany = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newCompany))
                devToUpdate.Company = newCompany;

            // Yangilangan ma'lumotlarni dataga qo'shaman
            string updatedJson = JsonConvert.SerializeObject(developers, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
            Console.WriteLine();
            Console.WriteLine($"{idToUpdate} developer's informations are updated by ID!");
        }
    }
}
