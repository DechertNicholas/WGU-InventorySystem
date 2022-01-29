
namespace InventorySystem
{
    partial class MainScreenForm
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
            this.dataGridViewParts = new System.Windows.Forms.DataGridView();
            this.labelDataGridVewPartsTitle = new System.Windows.Forms.Label();
            this.textBoxSearchParts = new System.Windows.Forms.TextBox();
            this.buttonSearchParts = new System.Windows.Forms.Button();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.buttonSearchProducts = new System.Windows.Forms.Button();
            this.textBoxSearchProducts = new System.Windows.Forms.TextBox();
            this.labelDataGridVewProductsTitle = new System.Windows.Forms.Label();
            this.labelForumTitle = new System.Windows.Forms.Label();
            this.buttonDataGridViewPartsDelete = new System.Windows.Forms.Button();
            this.buttonDataGridViewPartsModify = new System.Windows.Forms.Button();
            this.buttonDataGridViewPartsAdd = new System.Windows.Forms.Button();
            this.buttonDataGridViewProductsAdd = new System.Windows.Forms.Button();
            this.buttonDataGridViewProductsModify = new System.Windows.Forms.Button();
            this.buttonDataGridViewProductsDelete = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewParts
            // 
            this.dataGridViewParts.AllowUserToAddRows = false;
            this.dataGridViewParts.AllowUserToDeleteRows = false;
            this.dataGridViewParts.AllowUserToResizeRows = false;
            this.dataGridViewParts.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataGridViewParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParts.Location = new System.Drawing.Point(19, 170);
            this.dataGridViewParts.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.dataGridViewParts.Name = "dataGridViewParts";
            this.dataGridViewParts.ReadOnly = true;
            this.dataGridViewParts.RowHeadersVisible = false;
            this.dataGridViewParts.RowTemplate.Height = 25;
            this.dataGridViewParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewParts.ShowEditingIcon = false;
            this.dataGridViewParts.Size = new System.Drawing.Size(448, 240);
            this.dataGridViewParts.TabIndex = 0;
            // 
            // labelDataGridVewPartsTitle
            // 
            this.labelDataGridVewPartsTitle.AutoSize = true;
            this.labelDataGridVewPartsTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDataGridVewPartsTitle.Location = new System.Drawing.Point(19, 136);
            this.labelDataGridVewPartsTitle.Name = "labelDataGridVewPartsTitle";
            this.labelDataGridVewPartsTitle.Size = new System.Drawing.Size(59, 30);
            this.labelDataGridVewPartsTitle.TabIndex = 1;
            this.labelDataGridVewPartsTitle.Text = "Parts";
            // 
            // textBoxSearchParts
            // 
            this.textBoxSearchParts.Location = new System.Drawing.Point(320, 141);
            this.textBoxSearchParts.Name = "textBoxSearchParts";
            this.textBoxSearchParts.Size = new System.Drawing.Size(147, 23);
            this.textBoxSearchParts.TabIndex = 2;
            this.textBoxSearchParts.WordWrap = false;
            this.textBoxSearchParts.Enter += new System.EventHandler(this.textBoxSearchParts_Enter);
            this.textBoxSearchParts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchParts_KeyDown);
            this.textBoxSearchParts.Leave += new System.EventHandler(this.textBoxSearchParts_Leave);
            // 
            // buttonSearchParts
            // 
            this.buttonSearchParts.Location = new System.Drawing.Point(239, 141);
            this.buttonSearchParts.Name = "buttonSearchParts";
            this.buttonSearchParts.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchParts.TabIndex = 1;
            this.buttonSearchParts.Text = "Search";
            this.buttonSearchParts.UseVisualStyleBackColor = true;
            this.buttonSearchParts.Click += new System.EventHandler(this.buttonSearchParts_Click);
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AllowUserToResizeRows = false;
            this.dataGridViewProducts.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(587, 170);
            this.dataGridViewProducts.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            this.dataGridViewProducts.RowHeadersVisible = false;
            this.dataGridViewProducts.RowTemplate.Height = 25;
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.ShowEditingIcon = false;
            this.dataGridViewProducts.Size = new System.Drawing.Size(448, 240);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // buttonSearchProducts
            // 
            this.buttonSearchProducts.Location = new System.Drawing.Point(807, 141);
            this.buttonSearchProducts.Name = "buttonSearchProducts";
            this.buttonSearchProducts.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchProducts.TabIndex = 6;
            this.buttonSearchProducts.Text = "Search";
            this.buttonSearchProducts.UseVisualStyleBackColor = true;
            // 
            // textBoxSearchProducts
            // 
            this.textBoxSearchProducts.Location = new System.Drawing.Point(888, 141);
            this.textBoxSearchProducts.Name = "textBoxSearchProducts";
            this.textBoxSearchProducts.Size = new System.Drawing.Size(147, 23);
            this.textBoxSearchProducts.TabIndex = 7;
            this.textBoxSearchProducts.Enter += new System.EventHandler(this.textBoxSearchProducts_Enter);
            this.textBoxSearchProducts.Leave += new System.EventHandler(this.textBoxSearchProducts_Leave);
            // 
            // labelDataGridVewProductsTitle
            // 
            this.labelDataGridVewProductsTitle.AutoSize = true;
            this.labelDataGridVewProductsTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDataGridVewProductsTitle.Location = new System.Drawing.Point(587, 136);
            this.labelDataGridVewProductsTitle.Name = "labelDataGridVewProductsTitle";
            this.labelDataGridVewProductsTitle.Size = new System.Drawing.Size(97, 30);
            this.labelDataGridVewProductsTitle.TabIndex = 7;
            this.labelDataGridVewProductsTitle.Text = "Products";
            // 
            // labelForumTitle
            // 
            this.labelForumTitle.AutoSize = true;
            this.labelForumTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelForumTitle.Location = new System.Drawing.Point(12, 9);
            this.labelForumTitle.Name = "labelForumTitle";
            this.labelForumTitle.Size = new System.Drawing.Size(315, 30);
            this.labelForumTitle.TabIndex = 8;
            this.labelForumTitle.Text = "Inventory Management System";
            // 
            // buttonDataGridViewPartsDelete
            // 
            this.buttonDataGridViewPartsDelete.Location = new System.Drawing.Point(392, 416);
            this.buttonDataGridViewPartsDelete.Name = "buttonDataGridViewPartsDelete";
            this.buttonDataGridViewPartsDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDataGridViewPartsDelete.TabIndex = 5;
            this.buttonDataGridViewPartsDelete.Text = "Delete";
            this.buttonDataGridViewPartsDelete.UseVisualStyleBackColor = true;
            this.buttonDataGridViewPartsDelete.Click += new System.EventHandler(this.buttonDataGridViewPartsDelete_Click);
            // 
            // buttonDataGridViewPartsModify
            // 
            this.buttonDataGridViewPartsModify.Location = new System.Drawing.Point(311, 416);
            this.buttonDataGridViewPartsModify.Name = "buttonDataGridViewPartsModify";
            this.buttonDataGridViewPartsModify.Size = new System.Drawing.Size(75, 23);
            this.buttonDataGridViewPartsModify.TabIndex = 4;
            this.buttonDataGridViewPartsModify.Text = "Modify";
            this.buttonDataGridViewPartsModify.UseVisualStyleBackColor = true;
            this.buttonDataGridViewPartsModify.Click += new System.EventHandler(this.buttonDataGridViewPartsModify_Click);
            // 
            // buttonDataGridViewPartsAdd
            // 
            this.buttonDataGridViewPartsAdd.Location = new System.Drawing.Point(230, 416);
            this.buttonDataGridViewPartsAdd.Name = "buttonDataGridViewPartsAdd";
            this.buttonDataGridViewPartsAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonDataGridViewPartsAdd.TabIndex = 3;
            this.buttonDataGridViewPartsAdd.Text = "Add";
            this.buttonDataGridViewPartsAdd.UseVisualStyleBackColor = true;
            this.buttonDataGridViewPartsAdd.Click += new System.EventHandler(this.buttonDataGridViewPartsAdd_Click);
            // 
            // buttonDataGridViewProductsAdd
            // 
            this.buttonDataGridViewProductsAdd.Location = new System.Drawing.Point(798, 416);
            this.buttonDataGridViewProductsAdd.Name = "buttonDataGridViewProductsAdd";
            this.buttonDataGridViewProductsAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonDataGridViewProductsAdd.TabIndex = 8;
            this.buttonDataGridViewProductsAdd.Text = "Add";
            this.buttonDataGridViewProductsAdd.UseVisualStyleBackColor = true;
            this.buttonDataGridViewProductsAdd.Click += new System.EventHandler(this.buttonDataGridViewProductsAdd_Click);
            // 
            // buttonDataGridViewProductsModify
            // 
            this.buttonDataGridViewProductsModify.Location = new System.Drawing.Point(879, 416);
            this.buttonDataGridViewProductsModify.Name = "buttonDataGridViewProductsModify";
            this.buttonDataGridViewProductsModify.Size = new System.Drawing.Size(75, 23);
            this.buttonDataGridViewProductsModify.TabIndex = 9;
            this.buttonDataGridViewProductsModify.Text = "Modify";
            this.buttonDataGridViewProductsModify.UseVisualStyleBackColor = true;
            // 
            // buttonDataGridViewProductsDelete
            // 
            this.buttonDataGridViewProductsDelete.Location = new System.Drawing.Point(960, 416);
            this.buttonDataGridViewProductsDelete.Name = "buttonDataGridViewProductsDelete";
            this.buttonDataGridViewProductsDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDataGridViewProductsDelete.TabIndex = 10;
            this.buttonDataGridViewProductsDelete.Text = "Delete";
            this.buttonDataGridViewProductsDelete.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(960, 546);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // MainScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 581);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonDataGridViewProductsAdd);
            this.Controls.Add(this.buttonDataGridViewProductsModify);
            this.Controls.Add(this.buttonDataGridViewProductsDelete);
            this.Controls.Add(this.buttonDataGridViewPartsAdd);
            this.Controls.Add(this.buttonDataGridViewPartsModify);
            this.Controls.Add(this.buttonDataGridViewPartsDelete);
            this.Controls.Add(this.labelForumTitle);
            this.Controls.Add(this.labelDataGridVewProductsTitle);
            this.Controls.Add(this.buttonSearchProducts);
            this.Controls.Add(this.textBoxSearchProducts);
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.buttonSearchParts);
            this.Controls.Add(this.textBoxSearchParts);
            this.Controls.Add(this.labelDataGridVewPartsTitle);
            this.Controls.Add(this.dataGridViewParts);
            this.Name = "MainScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainScreenForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewParts;
        private System.Windows.Forms.Label labelDataGridVewPartsTitle;
        private System.Windows.Forms.TextBox textBoxSearchParts;
        private System.Windows.Forms.Button buttonSearchParts;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Button buttonSearchProducts;
        private System.Windows.Forms.TextBox textBoxSearchProducts;
        private System.Windows.Forms.Label labelDataGridVewProductsTitle;
        private System.Windows.Forms.Label labelForumTitle;
        private System.Windows.Forms.Button buttonDataGridViewPartsDelete;
        private System.Windows.Forms.Button buttonDataGridViewPartsModify;
        private System.Windows.Forms.Button buttonDataGridViewPartsAdd;
        private System.Windows.Forms.Button buttonDataGridViewProductsAdd;
        private System.Windows.Forms.Button buttonDataGridViewProductsModify;
        private System.Windows.Forms.Button buttonDataGridViewProductsDelete;
        private System.Windows.Forms.Button buttonExit;
    }
}