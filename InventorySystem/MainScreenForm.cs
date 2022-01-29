using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#if DEBUG
using System.Diagnostics;
#endif

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
        }

        /// <summary>
        /// Gets the selected part data from a DataGridView, then returns a part of that type
        /// </summary>
        /// <param name="selected">The selected row of data from a DataGridView</param>
        /// <returns>An object of the correct type from the selected DataGridViewRow</returns>
        static Part CastSelectedDataGridViewObject(DataGridViewSelectedRowCollection selected)
        {
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

        /// <summary>
        /// Moves the dataGridView selection to a part where the Part.Name matches what is in the search textbox.
        /// </summary>
        /// <param name="searchText"></param>
        private void HighlightSearchPart(string searchText)
        {
            // Need index of
            var part = MainInventory.AllParts.FirstOrDefault(p => p.Name.ToUpper().Contains(searchText.ToUpper()));
            var index = MainInventory.AllParts.IndexOf(part);
            dataGridViewParts.CurrentCell = dataGridViewParts.Rows[index].Cells[1];
            //dataGridViewParts.FirstDisplayedScrollingRowIndex = 3;
        }

        private void buttonDataGridViewPartsAdd_Click(object sender, EventArgs e)
        {
            var partForm = new AddModifyPartForm(MainInventory, AddModifyPartForm.OpenMode.ADD);
            partForm.ShowDialog(this);
            partForm.Dispose();
        }

        private void buttonDataGridViewPartsModify_Click(object sender, EventArgs e)
        {
            Part selectedpart = CastSelectedDataGridViewObject(dataGridViewParts.SelectedRows);
            var partForm = new AddModifyPartForm(MainInventory, AddModifyPartForm.OpenMode.MODIFY, selectedpart);
            partForm.ShowDialog(this);
            partForm.Dispose();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonDataGridViewPartsDelete_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Are you sure you want to delete this part?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (confirmation)
            {
                case DialogResult.Yes:
                    {
                        var selectedpart = CastSelectedDataGridViewObject(dataGridViewParts.SelectedRows);
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
    }
}
