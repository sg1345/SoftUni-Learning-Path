using System.Text;

namespace CocktailBar
{
    public class Menu
    {
        public Menu(int barCapacity)
        {
            this.Cocktails = new();
            this.BarCapacity = barCapacity;
        }

        public List<Cocktail> Cocktails { get; set; }
        public int BarCapacity { get; set; }
        public int Count => this.Cocktails.Count;

        public void AddCocktail(Cocktail cocktail)
        {

            //BarCapacity must be bigger and shouldnt duplicates the cocktail names
            if (BarCapacity > this.Count &&
                !this.Cocktails.Any(thisCocktail => thisCocktail.Name == cocktail.Name))
            {
                this.Cocktails.Add(cocktail);
            }
        }

        public bool RemoveCocktail(string name)
        {
            int index = this.Cocktails.FindIndex(cocktail => cocktail.Name == name);
            if (index < 0)
            {
                return false;
            }

            Cocktails.RemoveAt(index);
            return true;
        }

        public Cocktail GetMostDiverse()
        {
            return this.Cocktails
                .OrderByDescending(cocktail =>cocktail.Ingredients.Count)
                .FirstOrDefault()!;
        }

        public string Details(string cocktailName)
        {
            int index = this.Cocktails.FindIndex(cocktail => cocktail.Name == cocktailName);

            return this.Cocktails.ElementAt(index).ToString();
        }

        public string GetAll()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("All Cocktails:");



            foreach(var cocktail  in this.Cocktails.OrderBy(cocktail => cocktail.Name))
            {
                sb.AppendLine(cocktail.Name);
            }

            return sb.ToString().Trim();
        }
    }
}
