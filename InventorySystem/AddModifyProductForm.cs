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

using static InventorySystem.SharedUtilities;

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
            workingProduct = new Product();
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
            textBoxProductID.Text = product.ProductID.ToString();
            textBoxName.Text = product.Name;
            textBoxInventory.Text = product.InStock.ToString();
            textBoxPrice.Text = product.Price.ToString();
            textBoxMin.Text = product.Min.ToString();
            textBoxMax.Text = product.Max.ToString();

            workingProduct = product;
            // Seems this needs to be declared again after the product is assigned
            dataGridViewAssociated.DataSource = workingProduct.AssociatedParts;
        }

        private void InitializeFormData()
        {
            // Setup the mappings for use in displaying errors during validation later
            TextboxMappings = new Dictionary<TextBox, string>
            {
                { textBoxProductID, labelID.Text },
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

        private void SaveProduct()
        {
            // All validation tests
            var inputs = new List<TextBox>
            {
                textBoxName,
                textBoxInventory,
                textBoxPrice,
                textBoxMin,
                textBoxMax
            };

            var NoInputInvalid = true;

            foreach (var input in inputs)
            {
                if (string.IsNullOrEmpty(input.Text))
                {
                    MessageBox.Show($"{TextboxMappings[input]} must not be blank.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NoInputInvalid = false;
                    // Exit the method immediately, not all inputs have a value
                    return;
                }
            }

            // If not
            if (!(int.Parse(textBoxInventory.Text) >= int.Parse(textBoxMin.Text) && int.Parse(textBoxInventory.Text) <= int.Parse(textBoxMax.Text)))
            {
                MessageBox.Show($"{labelInventory.Text} must be between Min and Max values.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NoInputInvalid = false;
            }

            if (int.Parse(textBoxMax.Text) < int.Parse(textBoxMin.Text))
            {
                MessageBox.Show("Min inventory must be less than Max inventory", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NoInputInvalid = false;
            }

            if (NoInputInvalid)
            {
                workingProduct.Name = textBoxName.Text;
                workingProduct.InStock = int.Parse(textBoxInventory.Text);
                workingProduct.Price = decimal.Parse(textBoxPrice.Text);
                workingProduct.Min = int.Parse(textBoxMin.Text);
                workingProduct.Max = int.Parse(textBoxMax.Text);

                switch (Mode)
                {
                    case OpenMode.ADD:
                        {
                            Inventory.AddProduct(workingProduct);
                            Close();
                            break;
                        }
                    case OpenMode.MODIFY:
                        {
                            workingProduct.ProductID = int.Parse(textBoxProductID.Text);
                            Inventory.UpdateProduct(workingProduct.ProductID, workingProduct);
                            Close();
                            break;
                        }
                    default:
                        {
                            throw new InvalidOperationException();
                        }
                }

            }
        }

        /// <summary>
        /// Moves the dataGridView selection to a part where the Part.Name matches what is in the search textbox.
        /// </summary>
        /// <param name="searchText">The part name to search for</param>
        private void HighlightSearchPart(string searchText)
        {
            // Need index of
            var part = Inventory.AllParts.FirstOrDefault(p => p.Name.ToUpper().Contains(searchText.ToUpper()));
            if (part != null)
            {
                var index = Inventory.AllParts.IndexOf(part);
                dataGridViewCandidates.CurrentCell = dataGridViewCandidates.Rows[index].Cells[1];
            }
            // if no search result is found, simply do nothing
        }

        /// <summary>
        /// Gets the selected part data from a DataGridView, then returns a part of that type
        /// </summary>
        /// <param name="selected">The selected row of data from a DataGridView</param>
        /// <returns>An object of the correct type from the selected DataGridViewRow</returns>
        static Part CastSelectedDataGridViewPart(DataGridViewSelectedRowCollection selected)
        {
            if (selected.Count == 0)
            {
                MessageBox.Show("No part selected. Select a part to perform this operation on, or add a new part if none exist.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            switch (selected[0].DataBoundItem)
            {
                case InHouse inHouse:
                    {
                        return inHouse;
                    }
                case Outsourced outsourced:
                    {
                        return outsourced;
                    }
                default:
                    {
                        throw new InvalidOperationException();
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveProduct();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HighlightSearchPart(textBoxSearch.Text);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            HighlightSearchPart(textBoxSearch.Text);
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = buttonSearch;
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Part selectedpart = CastSelectedDataGridViewPart(dataGridViewCandidates.SelectedRows);
            if (selectedpart != null)
            {
                // Don't add the part if it is already associated
                if (workingProduct.LookupAssociatedPart(selectedpart.PartID) != null)
                {
                    MessageBox.Show("This part is already associated with the product.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (selectedpart != null)
                {
                    workingProduct.AddAssociatedpart(selectedpart);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Part selectedpart = CastSelectedDataGridViewPart(dataGridViewAssociated.SelectedRows);
            if (selectedpart != null)
            {
                workingProduct.RemoveAssociatedPart(selectedpart.PartID);
            }
        }
    }
}
