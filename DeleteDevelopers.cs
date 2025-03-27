using Newtonsoft.Json;

namespace L9
{
    public class DeleteDevelopers
    {
        private string filePath = "developers.json";

        public void DeleteDeveloper()
        {
            Console.Write("Developer ID: ");
            int idToDelete = Convert.ToInt32(Console.ReadLine());

            DeleteDeveloperById(idToDelete);
        }

        public void DeleteDeveloperById(int id)
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                List<Developers> developers = JsonConvert.DeserializeObject<List<Developers>>(jsonData);

                Developers devToRemove = developers.Find(d => d.ID == id);
                if (devToRemove == null)
                {
                    Console.WriteLine($"{id} Developer is not found by ID! ");
                    return;
                }
               
                developers.RemoveAll(d => d.ID == id);
                
                string updatedJson = JsonConvert.SerializeObject(developers, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
                Console.WriteLine();
                Console.WriteLine($"{id} developer is deleted succesfully!");
            }
            else
            {
                Console.WriteLine("Informations not found!");
            }
        }
    }
}