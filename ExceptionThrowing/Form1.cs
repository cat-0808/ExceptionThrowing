using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExceptionThrowing
{
    public partial class frmAddProduct : Form
    {
        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        private int _Quantity;
        private double _SellPrice;

        BindingSource showProductList;
        
        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$")) { throw new StringFormatException("Invalid Name Input!"); }
                //Exception here
                return name;
        }

        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]")) { throw new NumberFormatException("Invalid Quantity Input!"); }
                
                return Convert.ToInt32(qty);
        }
        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$")) { throw new CurrencyFormatException("Invalid Price Input!"); }
            {
                //Exception here
                return Convert.ToDouble(price);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Product_Name(txtProductName.Text);
                _ProductName = Product_Name(txtProductName.Text);
            }
            catch (StringFormatException sfe)
            {
                MessageBox.Show("Message : " + sfe.Message);
                
            }

                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;

            try 
            {
                Quantity(txtQuantity.Text);
                _Quantity = Quantity(txtQuantity.Text);
            }
            catch (NumberFormatException nfe)
            {
                MessageBox.Show("Message : " + nfe.Message);
            }

            try
            {
                SellingPrice(txtSellPrice.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);
            }
            catch (CurrencyFormatException cfe) {
                MessageBox.Show("Message : " + cfe.Message);
            }

                

            if (txtProductName.Text == "" || txtQuantity.Text == "" || txtSellPrice.Text == "" || cbCategory.Text == "") { MessageBox.Show("Please fill out the missing fields"); }
            else {
                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
                _ExpDate, _SellPrice, _Quantity, _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }




        }

        public frmAddProduct()
        {

            InitializeComponent();
            showProductList = new BindingSource();
            string[] ListOfProductCategory = { "Beverages", "Bread/Bakery", "Canned/Jarred Goods", "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other", };
            foreach (string x in ListOfProductCategory)
            {
                cbCategory.Items.Add(x);
            }
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
