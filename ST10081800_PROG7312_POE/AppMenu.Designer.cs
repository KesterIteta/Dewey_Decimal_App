namespace ST10081800_PROG7312_POE
{
    partial class AppMenu
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
            this.selectionMenu = new System.Windows.Forms.Label();
            this.bookReplacementBtn = new System.Windows.Forms.RadioButton();
            this.findingCallNumbersBtn = new System.Windows.Forms.RadioButton();
            this.identifyAreaBtn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.submitButton = new CustomControlsClassLibrary.CustomButtonClass();
            this.SuspendLayout();
            // 
            // selectionMenu
            // 
            this.selectionMenu.Font = new System.Drawing.Font("Perpetua Titling MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectionMenu.Location = new System.Drawing.Point(86, 32);
            this.selectionMenu.Name = "selectionMenu";
            this.selectionMenu.Size = new System.Drawing.Size(205, 28);
            this.selectionMenu.TabIndex = 2;
            this.selectionMenu.Text = "Selection menu";
            // 
            // bookReplacementBtn
            // 
            this.bookReplacementBtn.AutoSize = true;
            this.bookReplacementBtn.Font = new System.Drawing.Font("Perpetua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookReplacementBtn.Location = new System.Drawing.Point(90, 99);
            this.bookReplacementBtn.Name = "bookReplacementBtn";
            this.bookReplacementBtn.Size = new System.Drawing.Size(165, 26);
            this.bookReplacementBtn.TabIndex = 3;
            this.bookReplacementBtn.TabStop = true;
            this.bookReplacementBtn.Text = "Replacing Books";
            this.bookReplacementBtn.UseVisualStyleBackColor = true;
            // 
            // findingCallNumbersBtn
            // 
            this.findingCallNumbersBtn.AutoSize = true;
            this.findingCallNumbersBtn.Font = new System.Drawing.Font("Perpetua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findingCallNumbersBtn.Location = new System.Drawing.Point(90, 185);
            this.findingCallNumbersBtn.Name = "findingCallNumbersBtn";
            this.findingCallNumbersBtn.Size = new System.Drawing.Size(206, 26);
            this.findingCallNumbersBtn.TabIndex = 4;
            this.findingCallNumbersBtn.TabStop = true;
            this.findingCallNumbersBtn.Text = "Finding Call Numbers";
            this.findingCallNumbersBtn.UseVisualStyleBackColor = true;
            // 
            // identifyAreaBtn
            // 
            this.identifyAreaBtn.AutoSize = true;
            this.identifyAreaBtn.Font = new System.Drawing.Font("Perpetua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.identifyAreaBtn.Location = new System.Drawing.Point(90, 139);
            this.identifyAreaBtn.Name = "identifyAreaBtn";
            this.identifyAreaBtn.Size = new System.Drawing.Size(172, 26);
            this.identifyAreaBtn.TabIndex = 5;
            this.identifyAreaBtn.TabStop = true;
            this.identifyAreaBtn.Text = "Identifying Areas";
            this.identifyAreaBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Designed by Kester Iteta @ Varsity College";
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.submitButton.FlatAppearance.BorderSize = 0;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.ForeColor = System.Drawing.Color.White;
            this.submitButton.Location = new System.Drawing.Point(107, 262);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(155, 40);
            this.submitButton.TabIndex = 7;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // AppMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(579, 388);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.identifyAreaBtn);
            this.Controls.Add(this.findingCallNumbersBtn);
            this.Controls.Add(this.bookReplacementBtn);
            this.Controls.Add(this.selectionMenu);
            this.MaximizeBox = false;
            this.Name = "AppMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label selectionMenu;
        private System.Windows.Forms.RadioButton bookReplacementBtn;
        private System.Windows.Forms.RadioButton findingCallNumbersBtn;
        private System.Windows.Forms.RadioButton identifyAreaBtn;
        private System.Windows.Forms.Label label1;
        private CustomControlsClassLibrary.CustomButtonClass submitButton;
    }
}