using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private readonly Dictionary<string, double> _caloriesFromBackingTechnique = new(StringComparer.OrdinalIgnoreCase)
        {
            ["crispy"] = 0.9,
            ["chewy"] = 1.1,
            ["homemade"] = 1.0
        };

        private readonly Dictionary<string, double> _caloriesFromFlourType = new(StringComparer.OrdinalIgnoreCase)
        {
            ["white"] = 1.5,
            ["wholegrain"] = 1.0
        };

        public Dough(string flourType, string backingTechnique, double grams)
        {
            if (!FlourTypeAvailable(flourType) || !BackingTechniqueAvailable(backingTechnique))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            if (grams < 1 || grams > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            this.FlourType = flourType;
            this.BackingTechnique = backingTechnique;
            this.Grams = grams;
            this.Calories = CalculateCalories();
        }


        public string FlourType { get; }
        public string BackingTechnique { get; }
        public double Grams { get; }
        public double Calories { get; }

        private double CalculateCalories()
            => 2 * this.Grams * this._caloriesFromBackingTechnique[this.BackingTechnique] * this._caloriesFromFlourType[this.FlourType];

        private bool FlourTypeAvailable(string flourType)
            => this._caloriesFromFlourType.ContainsKey(flourType);

        private bool BackingTechniqueAvailable(string backingTechnique)
            => this._caloriesFromBackingTechnique.ContainsKey(backingTechnique);

    }
}
