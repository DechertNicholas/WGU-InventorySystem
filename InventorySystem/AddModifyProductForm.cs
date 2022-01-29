using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using static InventorySystem.SharedValidation;

namespace InventorySystem
{
    public partial class AddModifyProductForm : Form
    {
        // I use an enum here to modify the form depending on if a part is being added or modified
        // This reduces the code I need to write by re-using what I have for the Add form in the Modify form,
        // and I don't have to write a new form that is essentially a duplicate (Add and Modify will be almost exactly the same).
        public enum OpenMode { ADD, MODIFY }
        private OpenMode Mode { get; set; }
        private Inventory Inventory { get; set; }
        private Dictionary<TextBox, string> TextboxMappings { get; set; }

        private Product workingProduct;

        /// <summary>
        /// A constructor used to add a new product
        /// </summary>
        /// <param name="inventory">The forums Inventory object</param>
        /// <param name="mode">The OpenMode for the AddProductForm</param>
        public AddModifyProductForm(Inventory inventory, OpenMode mode)
        {
            InitializeComponent();
            Inventory = inventory;
            Mode = mode;
            InitializeFormData();
            dataGridViewCandidates.DataSource = Inventory.AllParts;
            dataGridViewAssociated.DataSource = workingProduct.AssociatedParts;
            
        }

        /// <summary>
        /// A constructor used to modify an existing product
        /// </summary>
        /// <param name="inventory">The forums Inventory object</param>
        /// <param name="mode">The OpenMode for the AddProductForm</param>
        /// <param name="product">The Product to modify</param>
        public AddModifyProductForm(Inventory inventory, OpenMode mode, Product product) : this(inventory, mode)
        {
            // Prepopoulate the text in the text boxes from the part data
            textBoxID.Text = product.ProductID.ToString();
            textBoxName.Text = product.Name;
            textBoxInventory.Text = product.InStock.ToString();
            textBoxPrice.Text = product.Price.ToString();
            textBoxMin.Text = product.Min.ToString();
            textBoxMax.Text = product.Max.ToString();
        }

        private void InitializeFormData()
        {
            // Setup the mappings for use in displaying errors during validation later
            TextboxMappings = new Dictionary<TextBox, string>
            {
                { textBoxID, labelID.Text },
                { textBoxName, labelName.Text },
                { textBoxInventory, labelInventory.Text },
                { textBoxPrice, labelPrice.Text },
                { textBoxMin, labelMin.Text },
                { textBoxMax, labelMax.Text }
            };

            switch (Mode)
            {
                case OpenMode.ADD:
                    {
                        // "this" isn't needed, but makes it clearer what Text is being modified
                        this.Text = "Add a New Product";
                        labelTitle.Text = "Add Product";
                        workingProduct = new Product();
                        break;
                    }
                case OpenMode.MODIFY:
                    {
                        this.Text = "Modify a Product";
                        labelTitle.Text = "Modify Product";
                        break;
                    }
            }
        }

        private void textBoxInventory_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxInt((TextBox)sender, new Regex("[^0-9]"));
        }

        private void textBoxMin_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxInt((TextBox)sender, new Regex("[^0-9]"));
        }

        private void textBoxMax_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxInt((TextBox)sender, new Regex("[^0-9]"));
        }

        private void textBoxPrice_Validating(object sender, CancelEventArgs e)
        {
            var textSender = (TextBox)sender;
            // Must be any number of digits followed by optional '.', and optional 1 -2 digits, or empty.
            if (!Regex.IsMatch(textSender.Text, @"(^\d+(\.\d(\d)?)?$)|(^.{0}$)"))
            {
                MessageBox.Show($"{labelPrice.Text} does not have a valid price. Limit to two decimal places, or enter a valid decimal.",
                    "Invalid price input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textSender.Focus();
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(textSender.Text, @"^\d+\.\d$"))
            {
                textSender.Text += "0"; // Add trailing 0 to a price like 1.2 -> 1.20
            }
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxInt((TextBox)sender, new Regex("[^0-9.]"));
        }
    }
}
