using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Item5
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Dictionary<string, double> Ingredients { get; set; }

        public Item5()
        {
            Ingredients = new Dictionary<string, double>();
        }

        public double GetTotalPrice()
        {
            return Price * Quantity;
        }

        public void UseIngredients(Dictionary<string, In> availableIngredients)
        {
            foreach (var ingredient in Ingredients)
            {
                if (!availableIngredients.ContainsKey(ingredient.Key))
                {
                    throw new InvalidOperationException($"Ingredient {ingredient.Key} not available.");
                }

                double requiredQuantity = ingredient.Value * Quantity;
                if (availableIngredients[ingredient.Key].Quantity < requiredQuantity)
                {
                    MessageBox.Show($"Not enough {ingredient.Key}. Please refill!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (availableIngredients[ingredient.Key].Quantity - requiredQuantity < 500)
                {
                    MessageBox.Show($"{ingredient.Key} is running low!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                availableIngredients[ingredient.Key].Use(requiredQuantity);
            }
        }
    }
 }
