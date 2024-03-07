using RestSharp;
using Newtonsoft.Json;

namespace CatClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClientService service = new ClientService();

            List<CatFact> catFacts = new List<CatFact>();

            for (int i = 0; i < 5; i++)
            {
                RestResponse response = service.GetCatText("https://catfact.ninja/fact");
                CatFact catFact = JsonConvert.DeserializeObject<CatFact>(response.Content);
                catFacts.Add(catFact);
            }

            foreach (CatFact catFact in catFacts)
            {
                Console.WriteLine("This is a catfact: " + catFact.fact);
                Console.WriteLine($"This cat fact was {catFact.length} characters long!\n");
            }
        }
    }
}
