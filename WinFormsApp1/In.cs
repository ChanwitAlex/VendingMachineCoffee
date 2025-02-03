using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class In
    {
        public string Name { get; set; }
        public double Quantity { get; set; }

        public In(string name, double quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public void Use(double quantity)
        {
            if (Quantity >= quantity)
            {
                Quantity -= quantity;
            }
            else
            {
                throw new InvalidOperationException($"Not enough {Name}.");
            }
        }
    }
}
