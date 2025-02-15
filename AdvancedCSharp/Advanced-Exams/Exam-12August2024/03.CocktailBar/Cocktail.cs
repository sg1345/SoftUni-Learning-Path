using System.Text;

namespace CocktailBar
{
    public class Cocktail
    {
        private List<string> _ingredients;

        public string? Name { get; }
        public decimal Price { get; }
        public double Volume { get; }

        public Cocktail(string ingredients)
        {
            this._ingredients = ingredients.Split(", ").ToList();
        }

        public Cocktail(string name, decimal price, double volume, string ingredients)
            : this(ingredients)
        {
            this.Name = name;
            this.Price = price;
            this.Volume = volume;
        }

        public List<string> Ingredients { get => this._ingredients; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name}, Price: {this.Price:F2} BGN, Volume: {this.Volume} ml");
            sb.Append($"Ingredients: {string.Join(", ", this.Ingredients)}");

            return sb.ToString().Trim();
        }
    }
}
