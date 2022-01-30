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
    public partial class AddModifyPartForm : Form
    {
        // I use an enum here to modify the form depending on if a part is being added or modified
        // This reduces the code I need to write by re-using what I have for the Add form in the Modify form,
        // and I don't have to write a new form that is essentially a duplicate (Add and Modify will be almost exactly the same).
        public enum OpenMode {ADD, MODIFY}
        private OpenMode Mode { get; set; }
        private Inventory Inventory { get; set; }
        private Dictionary<TextBox, string> TextboxMappings { get; set; }

        /// <summary>
        /// A constructor used to add a new part
        /// </summary>
        /// <param name="inventory">The forums Inventory object</param>
        /// <param name="mode">The OpenMode for the AddPartForm</param>
        public AddModifyPartForm(Inventory inventory, OpenMode mode)
        {
            InitializeComponent();
            Inventory = inventory;
            Mode = mode;

            InitializeFormData();
        }

        /// <summary>
        /// A constructor used to modify an existing part
        /// </summary>
        /// <param name="inventory">The forums Inventory object</param>
        /// <param name="mode">The OpenMode for the AddPartForm</param>
        /// <param name="part">The Part to modify</param>
        public AddModifyPartForm(Inventory inventory, OpenMode mode, Part part) : this(inventory, mode)
        {
            // Prepopoulate the text in the text boxes from the part data
            textBoxPartID.Text = part.PartID.ToString();
            textBoxName.Text = part.Name;
            textBoxInventory.Text = part.InStock.ToString();
            textBoxPriceCost.Text = part.Price.ToString();
            textBoxMin.Text = part.Min.ToString();
            textBoxMax.Text = part.Max.ToString();
            
            // The correct radio button needs to be set, and the SourceEntityID TextBox.Text set accordingly
            switch (part)
            {
                case InHouse inHouse:
                    {
                        radioButtonInHouse.Checked = true;
                        textBoxSourceEntityID.Text = inHouse.MachineID.ToString();
                        break;
                    }
                case Outsourced outsourced:
                    {
                        radioButtonOutsourced.Checked = true;
                        textBoxSourceEntityID.Text = outsourced.CompanyName;
                        break;
                    }
                default:
                    {
                        // Part is abstract and should never be submitted
                        throw new InvalidOperationException();
                    }
            }
        }

        /// <summary>
        /// Does some minor work to setup things like the TextboxMappings and sets the Form title and title label
        /// </summary>
        private void InitializeFormData()
        {
            // Setup the mappings for use in displaying errors during validation later
            TextboxMappings = new Dictionary<TextBox, string>
            {
                { textBoxPartID, labelPartID.Text },
                { textBoxName, labelName.Text },
                { textBoxInventory, labelInventory.Text },
                { textBoxPriceCost, labelPriceCost.Text },
                { textBoxMin, labelMin.Text },
                { textBoxMax, labelMax.Text },
                { textBoxSourceEntityID, labelSourceEntityID.Text }
            };

            switch (Mode)
            {
                case OpenMode.ADD:
                    {
                        // "this" isn't needed, but makes it clearer what Text is being modified
                        this.Text = "Add a New Part";
                        labelPartTitle.Text = "Add Part";
                        break;
                    }
                case OpenMode.MODIFY:
                    {
                        this.Text = "Modify a Part";
                        labelPartTitle.Text = "Modify Part";
                        break;
                    }
            }

            // Immediately on opening the form, the Source label needs to be set to Machine ID or Company Name, depending on the radio controls
            SetLabelSourceEntityID();
        }

        /// <summary>
        /// Dynamically determines the Text value of labelSourceEntityID based on the Checked values of the In-House and Outsourced radio controls.
        /// </summary>
        private void SetLabelSourceEntityID()
        {
            if (radioButtonInHouse.Checked)
            {
                labelSourceEntityID.Text = "Machine ID";
            }
            else if (radioButtonOutsourced.Checked)
            {
                labelSourceEntityID.Text = "Company Name";
            }
            TextboxMappings[textBoxSourceEntityID] = labelSourceEntityID.Text;
        }

        /// <summary>
        /// Gathers the data from all TextBoxes and the Form Open Mode to either save a new part, or save changes to an existing part
        /// </summary>
        private void SavePart()
        {
            // All validation tests
            var inputs = new List<TextBox>
            {
                textBoxName,
                textBoxInventory,
                textBoxPriceCost,
                textBoxMin,
                textBoxMax,
                textBoxSourceEntityID
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
                // Unsure what type of part will be added, so use polymorphism
                Part newPart;
                if (radioButtonInHouse.Checked)
                {
                    newPart = new InHouse { MachineID = int.Parse(textBoxSourceEntityID.Text) };
                }
                else
                {
                    newPart = new Outsourced { CompanyName = textBoxSourceEntityID.Text };
                }

                newPart.Name = textBoxName.Text;
                newPart.InStock = int.Parse(textBoxInventory.Text);
                newPart.Price = decimal.Parse(textBoxPriceCost.Text);
                newPart.Min = int.Parse(textBoxMin.Text);
                newPart.Max = int.Parse(textBoxMax.Text);

                switch (Mode)
                {
                    case OpenMode.ADD:
                        {
                            Inventory.AddPart(newPart);
                            Close();
                            break;
                        }
                    case OpenMode.MODIFY:
                        {
                            newPart.PartID = int.Parse(textBoxPartID.Text);
                            Inventory.UpdatePart(newPart.PartID, newPart);
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

        #region FormEvents
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SavePart();
        }

        private void textBoxInventory_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxInt((TextBox)sender, new Regex("[^0-9]"));
        }

        private void textBoxPriceCost_TextChanged(object sender, EventArgs e)
        {
            var textSender = (TextBox)sender;
            ValidateTextBoxInt(textSender, new Regex("[^0-9.]"));
        }

        private void textBoxPriceCost_Validating(object sender, CancelEventArgs e)
        {
            var textSender = (TextBox)sender;
            // Must be any number of digits followed by optional '.', and optional 1 -2 digits, or empty.
            if (!Regex.IsMatch(textSender.Text, @"(^\d+(\.\d(\d)?)?$)|(^.{0}$)"))
            {
                MessageBox.Show($"{labelPriceCost.Text} does not have a valid price. Limit to two decimal places, or enter a valid decimal.",
                    "Invalid price input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textSender.Focus();
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(textSender.Text, @"^\d+\.\d$"))
            {
                textSender.Text += "0"; // Add trailing 0 to a price like 1.2 -> 1.20
            }
        }

        private void radioButtonInHouse_CheckedChanged(object sender, EventArgs e)
        {
            SetLabelSourceEntityID();
        }

        private void radioButtonOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            SetLabelSourceEntityID();
            // When Outsourced is checked, and this state changes, textBoxSourceEntityID needs to be verified to have an int value, not a string value.
            ValidateTextBoxInt(textBoxSourceEntityID, new Regex("[^0-9]"));
        }

        private void textBoxMin_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxInt((TextBox)sender, new Regex("[^0-9]"));
        }

        private void textBoxMax_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxInt((TextBox)sender, new Regex("[^0-9]"));
        }

        private void textBoxSourceEntityID_TextChanged(object sender, EventArgs e)
        {
            // Only the InHouse option uses an int ID.
            if (radioButtonInHouse.Checked)
            {
                ValidateTextBoxInt((TextBox)sender, new Regex("[^0-9]"));
            }
        }

        #endregion FormEvents
    }
}
