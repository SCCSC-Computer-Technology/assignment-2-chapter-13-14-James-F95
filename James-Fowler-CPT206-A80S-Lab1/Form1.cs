using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace James_Fowler_CPT206_A80S_Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // These two buttons allow you to either search by Product Number or Product Descritpion for Part 4
        private void searchProductNumberButton_Click(object sender, EventArgs e)
        {
            string productNumber = searchTextBox.Text;

            ProductDBDataContext db = new ProductDBDataContext();

            var results = from product in db.Products
                          where product.Product_Number == productNumber
                          select product;

            productsDataGridView.DataSource = results;
        }

        private void searchProductDescriptionButton_Click(object sender, EventArgs e)
        {
            string productDescription = searchTextBox.Text;

            ProductDBDataContext db = new ProductDBDataContext();

            var results = from product in db.Products
                          where product.Description.ToLower().Contains(productDescription.ToLower())
                          select product;

            productsDataGridView.DataSource = results;

        }
        // This Makes the data load automatically when you run the program and sorts it by Units on hand for Problem 5
        private void Form1_Load(object sender, EventArgs e)
        {
            ProductDBDataContext db = new ProductDBDataContext();

            var results = from product in db.Products
                          orderby product.Units_On_Hand
                          select product;
            productsDataGridView.DataSource = results;

        }
        //This search button is apart of Problem 5 and takes the min and Max amount you put in textboxes and sorts the data using those numbers
        private void searchButton_Click(object sender, EventArgs e)
        {
            int minAmtUnitsOnHand =Convert.ToInt32(minimumAmountTextBox.Text);
            int maxAmtUnitsOnHand = Convert.ToInt32(maximumAmountTextBox.Text);

            ProductDBDataContext db = new ProductDBDataContext();


            var results = from product in db.Products
                          where product.Units_On_Hand>minAmtUnitsOnHand && product.Units_On_Hand<maxAmtUnitsOnHand
                          orderby product.Units_On_Hand
                          select product;

            productsDataGridView.DataSource = results;

        }
        //This allows you to get the data based on what price you put in the textboxes and sorts it from low to high for Problem 6
        private void searchsButton_Click(object sender, EventArgs e)
        {
            decimal minPrice = Convert.ToDecimal(minimumPriceTextBox.Text);
            decimal maxPrice = Convert.ToDecimal(maximumPriceTextBox.Text);

            ProductDBDataContext db = new ProductDBDataContext();

            var results = from product in db.Products
                          where product.Price>=minPrice && product.Price<=maxPrice
                          orderby product.Price
                          select product;

            productsDataGridView.DataSource = results;
        }
    }
}
