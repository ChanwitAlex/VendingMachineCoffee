namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Item5 itemBlackCoffee = new Item5();
        Item5 itemLatte = new Item5();
        Item5 itemMocha = new Item5();
        Item5 itemChocolate = new Item5();
        Item5 itemWater = new Item5();
        Item5 itemCoffee = new Item5();
        Item5 itemMilk = new Item5();
        Item5 itemChocolatMix = new Item5();

        public Form1()
        {
            InitializeComponent();

            itemBlackCoffee.Name = "Black Coffee";
            itemBlackCoffee.Price = 50;
            itemBlackCoffee.Quantity = 0;
            itemBlackCoffee.Ingredients.Add("Water", 300);
            itemBlackCoffee.Ingredients.Add("Coffee", 20);

            itemLatte.Name = "Latte";
            itemLatte.Price = 85;
            itemLatte.Quantity = 0;
            itemLatte.Ingredients.Add("Water", 300);
            itemLatte.Ingredients.Add("Coffee", 20);
            itemLatte.Ingredients.Add("Milk", 10);

            itemMocha.Name = "Mocha";
            itemMocha.Price = 70;
            itemMocha.Quantity = 0;
            itemMocha.Ingredients.Add("Water", 300);
            itemMocha.Ingredients.Add("Coffee", 20);
            itemMocha.Ingredients.Add("Chocolate", 10);

            itemChocolate.Name = "Chocolate";
            itemChocolate.Price = 75;
            itemChocolate.Quantity = 0;
            itemChocolate.Ingredients.Add("Water", 300);
            itemChocolate.Ingredients.Add("Chocolate", 20);


            tbBlackCoffeePrice.Text = itemBlackCoffee.Price.ToString();
            tbBlackCoffeeQuantity.Text = itemBlackCoffee.Quantity.ToString();

            tbLattePrice.Text = itemLatte.Price.ToString();
            tbLatteQuantity.Text = itemLatte.Quantity.ToString();

            tbMochaPrice.Text = itemMocha.Price.ToString();
            tbMochaQuantity.Text = itemMocha.Quantity.ToString();

            tbChocolatePrice.Text = itemChocolate.Price.ToString();
            tbChocolateQuantity.Text = itemChocolate.Quantity.ToString();

            itemWater.Name = "Water Mix";
            itemWater.Quantity = 10000;

            itemCoffee.Name = "Coffee Mix";
            itemCoffee.Quantity = 10000;

            itemMilk.Name = "Milk Mix";
            itemMilk.Quantity = 10000;

            itemChocolatMix.Name = "Chocolat Mix";
            itemChocolatMix.Quantity = 10000;

            tbWater.Text = itemWater.Quantity.ToString();
            tbCoffee.Text = itemCoffee.Quantity.ToString();
            tbMilk.Text = itemMilk.Quantity.ToString();
            tbChocolate.Text = itemChocolatMix.Quantity.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                double dCash = double.Parse(tbCrash.Text);
                double dTotal = 0;

                Dictionary<string, In> availableIngredients = new Dictionary<string, In>
                {
                    { "Water", new In("Water", 10000) },
                    { "Coffee", new In("Coffee", 10000) },
                    { "Milk", new In("Milk", 10000) },
                    { "Chocolate", new In("Chocolate", 10000) }
                };

                if (chbBlackCoffee.Checked)
                {
                    itemBlackCoffee.Quantity = int.Parse(tbBlackCoffeeQuantity.Text);
                    dTotal += itemBlackCoffee.GetTotalPrice();
                    itemBlackCoffee.UseIngredients(availableIngredients);


                    tbWater.Text = availableIngredients["Water"].Quantity.ToString();
                    tbCoffee.Text = availableIngredients["Coffee"].Quantity.ToString();
                }


                if (chbLatte.Checked)
                {
                    itemLatte.Quantity = int.Parse(tbLatteQuantity.Text);
                    dTotal += itemLatte.GetTotalPrice();
                    itemLatte.UseIngredients(availableIngredients);

                    tbWater.Text = availableIngredients["Water"].Quantity.ToString();
                    tbCoffee.Text = availableIngredients["Coffee"].Quantity.ToString();
                    tbMilk.Text = availableIngredients["Milk"].Quantity.ToString();
                }

                if (chbMocha.Checked)
                {
                    itemMocha.Quantity = int.Parse(tbMochaQuantity.Text);
                    dTotal += itemMocha.GetTotalPrice();
                    itemMocha.UseIngredients(availableIngredients);

                    tbWater.Text = availableIngredients["Water"].Quantity.ToString();
                    tbCoffee.Text = availableIngredients["Coffee"].Quantity.ToString();
                    tbChocolate.Text = availableIngredients["Chocolate"].Quantity.ToString();
                }

                if (chbChocolate.Checked)
                {
                    itemChocolate.Quantity = int.Parse(tbChocolateQuantity.Text);
                    dTotal += itemChocolate.GetTotalPrice();
                    itemChocolate.UseIngredients(availableIngredients);

                    tbWater.Text = availableIngredients["Water"].Quantity.ToString();
                    tbChocolate.Text = availableIngredients["Chocolate"].Quantity.ToString();
                }

                if (dCash < dTotal)
                {
                    MessageBox.Show("Insufficient cash", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double dChange = dCash - dTotal;
                tbTotal.Text = dTotal.ToString("F2");
                tbChange.Text = dChange.ToString("F2");

                CalculateChangeDenominations(dChange);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please fill in the numbers correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateChangeDenominations(double change)
        {
            double[] denominations = { 500, 100, 50, 20, 10, 5, 1, 0.50, 0.25 };
            int[] changeCount = new int[denominations.Length];
            double remainChange = change;

            for (int i = 0; i < denominations.Length; i++)
            {
                changeCount[i] = (int)(remainChange / denominations[i]);
                remainChange %= denominations[i];
            }

            tb500.Text = changeCount[0].ToString();
            tb100.Text = changeCount[1].ToString();
            tb50.Text = changeCount[2].ToString();
            tb20.Text = changeCount[3].ToString();
            tb10.Text = changeCount[4].ToString();
            tb5.Text = changeCount[5].ToString();
            tb1.Text = changeCount[6].ToString();
            tb05.Text = changeCount[7].ToString();
            tb025.Text = changeCount[8].ToString();
        }
    }
}
