
namespace InventorySystem
{
    partial class AddModifyPartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPartTitle = new System.Windows.Forms.Label();
            this.radioButtonInHouse = new System.Windows.Forms.RadioButton();
            this.radioButtonOutsourced = new System.Windows.Forms.RadioButton();
            this.groupBoxPartType = new System.Windows.Forms.GroupBox();
            this.labelPartID = new System.Windows.Forms.Label();
            this.textBoxPartID = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxInventory = new System.Windows.Forms.TextBox();
            this.labelInventory = new System.Windows.Forms.Label();
            this.textBoxPriceCost = new System.Windows.Forms.TextBox();
            this.labelPriceCost = new System.Windows.Forms.Label();
            this.textBoxMin = new System.Windows.Forms.TextBox();
            this.labelMin = new System.Windows.Forms.Label();
            this.textBoxSourceEntityID = new System.Windows.Forms.TextBox();
            this.labelSourceEntityID = new System.Windows.Forms.Label();
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxPartType.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPartTitle
            // 
            this.labelPartTitle.AutoSize = true;
            this.labelPartTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPartTitle.Location = new System.Drawing.Point(12, 28);
            this.labelPartTitle.Name = "labelPartTitle";
            this.labelPartTitle.Size = new System.Drawing.Size(85, 21);
            this.labelPartTitle.TabIndex = 0;
            this.labelPartTitle.Text = "Action Part";
            // 
            // radioButtonInHouse
            // 
            this.radioButtonInHouse.AutoSize = true;
            this.radioButtonInHouse.Checked = true;
            this.radioButtonInHouse.Location = new System.Drawing.Point(6, 22);
            this.radioButtonInHouse.Name = "radioButtonInHouse";
            this.radioButtonInHouse.Size = new System.Drawing.Size(74, 19);
            this.radioButtonInHouse.TabIndex = 1;
            this.radioButtonInHouse.TabStop = true;
            this.radioButtonInHouse.Text = "In-House";
            this.radioButtonInHouse.UseVisualStyleBackColor = true;
            this.radioButtonInHouse.CheckedChanged += new System.EventHandler(this.radioButtonInHouse_CheckedChanged);
            // 
            // radioButtonOutsourced
            // 
            this.radioButtonOutsourced.AutoSize = true;
            this.radioButtonOutsourced.Location = new System.Drawing.Point(122, 22);
            this.radioButtonOutsourced.Name = "radioButtonOutsourced";
            this.radioButtonOutsourced.Size = new System.Drawing.Size(87, 19);
            this.radioButtonOutsourced.TabIndex = 2;
            this.radioButtonOutsourced.Text = "Outsourced";
            this.radioButtonOutsourced.UseVisualStyleBackColor = true;
            this.radioButtonOutsourced.CheckedChanged += new System.EventHandler(this.radioButtonOutsourced_CheckedChanged);
            // 
            // groupBoxPartType
            // 
            this.groupBoxPartType.Controls.Add(this.radioButtonInHouse);
            this.groupBoxPartType.Controls.Add(this.radioButtonOutsourced);
            this.groupBoxPartType.Location = new System.Drawing.Point(106, 9);
            this.groupBoxPartType.Name = "groupBoxPartType";
            this.groupBoxPartType.Size = new System.Drawing.Size(215, 60);
            this.groupBoxPartType.TabIndex = 0;
            this.groupBoxPartType.TabStop = false;
            this.groupBoxPartType.Text = "Select Part Type";
            // 
            // labelPartID
            // 
            this.labelPartID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPartID.Location = new System.Drawing.Point(22, 94);
            this.labelPartID.Name = "labelPartID";
            this.labelPartID.Size = new System.Drawing.Size(94, 20);
            this.labelPartID.TabIndex = 0;
            this.labelPartID.Text = "Part ID";
            this.labelPartID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPartID
            // 
            this.textBoxPartID.Location = new System.Drawing.Point(122, 94);
            this.textBoxPartID.Name = "textBoxPartID";
            this.textBoxPartID.ReadOnly = true;
            this.textBoxPartID.Size = new System.Drawing.Size(166, 23);
            this.textBoxPartID.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(122, 133);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(166, 23);
            this.textBoxName.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelName.Location = new System.Drawing.Point(22, 133);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(94, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxInventory
            // 
            this.textBoxInventory.Location = new System.Drawing.Point(122, 172);
            this.textBoxInventory.Name = "textBoxInventory";
            this.textBoxInventory.Size = new System.Drawing.Size(166, 23);
            this.textBoxInventory.TabIndex = 5;
            this.textBoxInventory.TextChanged += new System.EventHandler(this.textBoxInventory_TextChanged);
            // 
            // labelInventory
            // 
            this.labelInventory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelInventory.Location = new System.Drawing.Point(22, 172);
            this.labelInventory.Name = "labelInventory";
            this.labelInventory.Size = new System.Drawing.Size(94, 20);
            this.labelInventory.TabIndex = 0;
            this.labelInventory.Text = "Inventory";
            this.labelInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPriceCost
            // 
            this.textBoxPriceCost.Location = new System.Drawing.Point(122, 211);
            this.textBoxPriceCost.Name = "textBoxPriceCost";
            this.textBoxPriceCost.Size = new System.Drawing.Size(166, 23);
            this.textBoxPriceCost.TabIndex = 6;
            this.textBoxPriceCost.TextChanged += new System.EventHandler(this.textBoxPriceCost_TextChanged);
            this.textBoxPriceCost.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPriceCost_Validating);
            // 
            // labelPriceCost
            // 
            this.labelPriceCost.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPriceCost.Location = new System.Drawing.Point(22, 211);
            this.labelPriceCost.Name = "labelPriceCost";
            this.labelPriceCost.Size = new System.Drawing.Size(94, 20);
            this.labelPriceCost.TabIndex = 0;
            this.labelPriceCost.Text = "Price / Cost";
            this.labelPriceCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxMin
            // 
            this.textBoxMin.Location = new System.Drawing.Point(122, 250);
            this.textBoxMin.Name = "textBoxMin";
            this.textBoxMin.Size = new System.Drawing.Size(48, 23);
            this.textBoxMin.TabIndex = 7;
            this.textBoxMin.TextChanged += new System.EventHandler(this.textBoxMin_TextChanged);
            // 
            // labelMin
            // 
            this.labelMin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelMin.Location = new System.Drawing.Point(22, 250);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(94, 20);
            this.labelMin.TabIndex = 0;
            this.labelMin.Text = "Min";
            this.labelMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxSourceEntityID
            // 
            this.textBoxSourceEntityID.Location = new System.Drawing.Point(122, 289);
            this.textBoxSourceEntityID.Name = "textBoxSourceEntityID";
            this.textBoxSourceEntityID.Size = new System.Drawing.Size(166, 23);
            this.textBoxSourceEntityID.TabIndex = 9;
            this.textBoxSourceEntityID.TextChanged += new System.EventHandler(this.textBoxSourceEntityID_TextChanged);
            // 
            // labelSourceEntityID
            // 
            this.labelSourceEntityID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelSourceEntityID.Location = new System.Drawing.Point(22, 289);
            this.labelSourceEntityID.Name = "labelSourceEntityID";
            this.labelSourceEntityID.Size = new System.Drawing.Size(94, 20);
            this.labelSourceEntityID.TabIndex = 0;
            this.labelSourceEntityID.Text = "Source Entity ID";
            this.labelSourceEntityID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxMax
            // 
            this.textBoxMax.Location = new System.Drawing.Point(240, 250);
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(48, 23);
            this.textBoxMax.TabIndex = 8;
            this.textBoxMax.TextChanged += new System.EventHandler(this.textBoxMax_TextChanged);
            // 
            // labelMax
            // 
            this.labelMax.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelMax.Location = new System.Drawing.Point(185, 250);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(49, 20);
            this.labelMax.TabIndex = 0;
            this.labelMax.Text = "Max";
            this.labelMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(122, 351);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(213, 351);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // AddPartForm
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(402, 404);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxMax);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.textBoxSourceEntityID);
            this.Controls.Add(this.labelSourceEntityID);
            this.Controls.Add(this.textBoxMin);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.textBoxPriceCost);
            this.Controls.Add(this.labelPriceCost);
            this.Controls.Add(this.textBoxInventory);
            this.Controls.Add(this.labelInventory);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxPartID);
            this.Controls.Add(this.labelPartID);
            this.Controls.Add(this.groupBoxPartType);
            this.Controls.Add(this.labelPartTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddPartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add or Modify a Part";
            this.groupBoxPartType.ResumeLayout(false);
            this.groupBoxPartType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPartTitle;
        private System.Windows.Forms.RadioButton radioButtonInHouse;
        private System.Windows.Forms.RadioButton radioButtonOutsourced;
        private System.Windows.Forms.GroupBox groupBoxPartType;
        private System.Windows.Forms.Label labelPartID;
        private System.Windows.Forms.TextBox textBoxPartID;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxInventory;
        private System.Windows.Forms.Label labelInventory;
        private System.Windows.Forms.TextBox textBoxPriceCost;
        private System.Windows.Forms.Label labelPriceCost;
        private System.Windows.Forms.TextBox textBoxMin;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.TextBox textBoxSourceEntityID;
        private System.Windows.Forms.Label labelSourceEntityID;
        private System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}