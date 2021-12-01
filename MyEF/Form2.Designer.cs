namespace MyEF
{
    partial class Form2
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
            this.btnBindGrid = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLazyLoading = new System.Windows.Forms.Button();
            this.btnExplicitLoading = new System.Windows.Forms.Button();
            this.btnEagerLoading = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBindGrid
            // 
            this.btnBindGrid.Location = new System.Drawing.Point(56, 31);
            this.btnBindGrid.Name = "btnBindGrid";
            this.btnBindGrid.Size = new System.Drawing.Size(208, 23);
            this.btnBindGrid.TabIndex = 0;
            this.btnBindGrid.Text = "BindGrid";
            this.btnBindGrid.UseVisualStyleBackColor = true;
            this.btnBindGrid.Click += new System.EventHandler(this.btnBindGrid_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(56, 62);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(208, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(56, 93);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(71, 84);
            this.btnRetrieve.TabIndex = 2;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(56, 185);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(208, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(56, 216);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(208, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLazyLoading
            // 
            this.btnLazyLoading.Location = new System.Drawing.Point(133, 93);
            this.btnLazyLoading.Name = "btnLazyLoading";
            this.btnLazyLoading.Size = new System.Drawing.Size(131, 23);
            this.btnLazyLoading.TabIndex = 5;
            this.btnLazyLoading.Text = "Lazy Loading";
            this.btnLazyLoading.UseVisualStyleBackColor = true;
            this.btnLazyLoading.Click += new System.EventHandler(this.btnLazyLoading_Click);
            // 
            // btnExplicitLoading
            // 
            this.btnExplicitLoading.Location = new System.Drawing.Point(133, 123);
            this.btnExplicitLoading.Name = "btnExplicitLoading";
            this.btnExplicitLoading.Size = new System.Drawing.Size(131, 23);
            this.btnExplicitLoading.TabIndex = 6;
            this.btnExplicitLoading.Text = "Explicit Loading";
            this.btnExplicitLoading.UseVisualStyleBackColor = true;
            this.btnExplicitLoading.Click += new System.EventHandler(this.btnExplicitLoading_Click);
            // 
            // btnEagerLoading
            // 
            this.btnEagerLoading.Location = new System.Drawing.Point(133, 153);
            this.btnEagerLoading.Name = "btnEagerLoading";
            this.btnEagerLoading.Size = new System.Drawing.Size(131, 23);
            this.btnEagerLoading.TabIndex = 7;
            this.btnEagerLoading.Text = "Eager Loading";
            this.btnEagerLoading.UseVisualStyleBackColor = true;
            this.btnEagerLoading.Click += new System.EventHandler(this.btnEagerLoading_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.Location = new System.Drawing.Point(56, 246);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(208, 23);
            this.btnTransaction.TabIndex = 8;
            this.btnTransaction.Text = "Transaction";
            this.btnTransaction.UseVisualStyleBackColor = true;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 302);
            this.Controls.Add(this.btnTransaction);
            this.Controls.Add(this.btnEagerLoading);
            this.Controls.Add(this.btnExplicitLoading);
            this.Controls.Add(this.btnLazyLoading);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRetrieve);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnBindGrid);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBindGrid;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLazyLoading;
        private System.Windows.Forms.Button btnExplicitLoading;
        private System.Windows.Forms.Button btnEagerLoading;
        private System.Windows.Forms.Button btnTransaction;
    }
}