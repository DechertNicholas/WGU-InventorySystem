using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem
{
    public partial class MainScreenForm : Form
    {
        /// <summary>
        /// Instance of the Inventory Class used for everything.
        /// </summary>
        public Inventory MainInventory { get; }

        public MainScreenForm()
        {
            InitializeComponent();
            MainInventory = new Inventory();
            dataGridViewParts.DataSource = MainInventory.AllParts;
            dataGridViewProducts.DataSource = MainInventory.Products;
            PopulateInitialData();
        }

        /// <summary>
        /// Quickly populate some sample data so the evaluator doesn't have to add everything manually.
        /// </summary>
        void PopulateInitialData()
        {
            MainInventory.AddPart(new InHouse { Name = "Wheel", MachineID = 1, Min = 5, Max = 25, InStock = 10, Price = 2 });
            MainInventory.AddPart(new InHouse { Name = "Pedal", MachineID = 2, Min = 5, Max = 25, InStock = 16, Price = 1 });
            MainInventory.AddPart(new InHouse { Name = "Chain", MachineID = 3, Min = 5, Max = 25, InStock = 24, Price = 4 });
            MainInventory.AddPart(new Outsourced { Name = "Seat", CompanyName = "Bob's Upholstry", Min = 5, Max = 25, InStock = 16, Price = 10 });

            MainInventory.AddProduct(new Product
            {
                Name = "Unicycle",
                Min = 1,
                Max = 25,
                InStock = 15,
                Price = 20,
                AssociatedParts =
                    new BindingList<Part> { MainInventory.LookupPart(1), MainInventory.LookupPart(2), MainInventory.LookupPart(4) }
            });
        }

        /// <summary>
        /// Gets the selected part data from a DataGridView, then returns a part of that type
        /// </summary>
        /// <param name="selected">The selected row of data from a DataGridView</param>
        /// <returns>An object of the correct type from the selected DataGridViewRow</returns>
        static Object CastSelectedDataGridViewPart(DataGridViewSelectedRowCollection selected)
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
                case Product product:
                    {
                        return product;
                    }
                default:
                    {
                        throw new InvalidOperationException();
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
            var part = MainInventory.AllParts.FirstOrDefault(p => p.Name.ToUpper().Contains(searchText.ToUpper()));
            if (part != null)
            {
                var index = MainInventory.AllParts.IndexOf(part);
                dataGridViewParts.CurrentCell = dataGridViewParts.Rows[index].Cells[1];
            }
            // if no search result is found, simply do nothing
        }

        /// <summary>
        /// Moves the dataGridView selection to a product where the Product.Name matches what is in the search textbox.
        /// </summary>
        /// <param name="searchText">The product name to search for</param>
        private void HighlightSearchProduct(string searchText)
        {
            // Need index of
            var product = MainInventory.Products.FirstOrDefault(p => p.Name.ToUpper().Contains(searchText.ToUpper()));
            if (product != null)
            {
                var index = MainInventory.Products.IndexOf(product);
                dataGridViewProducts.CurrentCell = dataGridViewProducts.Rows[index].Cells[1];
            }
            // if no search result is found, simply do nothing
        }

        private void buttonDataGridViewPartsAdd_Click(object sender, EventArgs e)
        {
            var partForm = new AddModifyPartForm(MainInventory, AddModifyPartForm.OpenMode.ADD);
            partForm.ShowDialog(this);
            partForm.Dispose();
        }

        private void buttonDataGridViewPartsModify_Click(object sender, EventArgs e)
        {
            Part selectedpart = (Part)CastSelectedDataGridViewPart(dataGridViewParts.SelectedRows);
            if (selectedpart != null)
            {
                var partForm = new AddModifyPartForm(MainInventory, AddModifyPartForm.OpenMode.MODIFY, selectedpart);
                partForm.ShowDialog(this);
                partForm.Dispose();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonDataGridViewPartsDelete_Click(object sender, EventArgs e)
        {
            Part selectedpart = (Part)CastSelectedDataGridViewPart(dataGridViewParts.SelectedRows);
            if (selectedpart != null)
            {
                var confirmation = MessageBox.Show("Are you sure you want to delete this part?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (confirmation)
                {
                    case DialogResult.Yes:
                        {

                            MainInventory.DeletePart(selectedpart);
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    default:
                        {
                            throw new InvalidOperationException();
                        }
                }
            }
        }

        private void textBoxSearchParts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HighlightSearchPart(textBoxSearchParts.Text);
            }
        }

        private void buttonSearchParts_Click(object sender, EventArgs e)
        {
            HighlightSearchPart(textBoxSearchParts.Text);
        }

        private void textBoxSearchParts_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = buttonSearchParts;
        }

        private void textBoxSearchParts_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void textBoxSearchProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HighlightSearchProduct(textBoxSearchProducts.Text);
            }
        }

        private void buttonSearchProducts_Click(object sender, EventArgs e)
        {
            HighlightSearchProduct(textBoxSearchProducts.Text);
        }

        private void textBoxSearchProducts_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = buttonSearchProducts;
        }

        private void textBoxSearchProducts_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void buttonDataGridViewProductsAdd_Click(object sender, EventArgs e)
        {
            var productForm = new AddModifyProductForm(MainInventory, AddModifyProductForm.OpenMode.ADD);
            productForm.ShowDialog(this);
            productForm.Dispose();
        }

        private void buttonDataGridViewProductsModify_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)CastSelectedDataGridViewPart(dataGridViewProducts.SelectedRows);
            if (selectedProduct != null)
            {
                var productForm = new AddModifyProductForm(MainInventory, AddModifyProductForm.OpenMode.MODIFY, selectedProduct);
                productForm.ShowDialog(this);
                productForm.Dispose();
            }
        }

        private void buttonDataGridViewProductsDelete_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)CastSelectedDataGridViewPart(dataGridViewProducts.SelectedRows);
            if (selectedProduct != null)
            {
                if (selectedProduct.AssociatedParts.Count > 0)
                {
                    MessageBox.Show("All associated parts must be removed before deleting a product.", "Invalid Associations", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var confirmation = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (confirmation)
                {
                    case DialogResult.Yes:
                        {

                            MainInventory.RemoveProduct(selectedProduct.ProductID);
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    default:
                        {
                            throw new InvalidOperationException();
                        }
                }
            }
        }
    }
}
