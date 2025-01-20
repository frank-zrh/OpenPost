namespace OpenPostForms.dialogs
{
    partial class FormNewItem
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
            labelNewItemName = new Label();
            labelNewItemDescription = new Label();
            textBoxNewItemName = new TextBox();
            textBoxNewItemDescription = new TextBox();
            buttonNewItemCancel = new Button();
            buttonNewItemOK = new Button();
            SuspendLayout();
            // 
            // labelNewItemName
            // 
            labelNewItemName.AutoSize = true;
            labelNewItemName.Location = new Point(56, 33);
            labelNewItemName.Name = "labelNewItemName";
            labelNewItemName.Size = new Size(70, 24);
            labelNewItemName.TabIndex = 0;
            labelNewItemName.Text = "Name*";
            // 
            // labelNewItemDescription
            // 
            labelNewItemDescription.AutoSize = true;
            labelNewItemDescription.Location = new Point(56, 86);
            labelNewItemDescription.Name = "labelNewItemDescription";
            labelNewItemDescription.Size = new Size(109, 24);
            labelNewItemDescription.TabIndex = 1;
            labelNewItemDescription.Text = "Description";
            // 
            // textBoxNewItemName
            // 
            textBoxNewItemName.Location = new Point(190, 32);
            textBoxNewItemName.Name = "textBoxNewItemName";
            textBoxNewItemName.Size = new Size(495, 30);
            textBoxNewItemName.TabIndex = 2;
            // 
            // textBoxNewItemDescription
            // 
            textBoxNewItemDescription.Location = new Point(190, 83);
            textBoxNewItemDescription.Name = "textBoxNewItemDescription";
            textBoxNewItemDescription.Size = new Size(494, 30);
            textBoxNewItemDescription.TabIndex = 3;
            // 
            // buttonNewItemCancel
            // 
            buttonNewItemCancel.Location = new Point(415, 149);
            buttonNewItemCancel.Name = "buttonNewItemCancel";
            buttonNewItemCancel.Size = new Size(112, 34);
            buttonNewItemCancel.TabIndex = 4;
            buttonNewItemCancel.Text = "Cancel";
            buttonNewItemCancel.UseVisualStyleBackColor = true;
            buttonNewItemCancel.Click += buttonNewItemCancel_Click;
            // 
            // buttonNewItemOK
            // 
            buttonNewItemOK.Location = new Point(572, 149);
            buttonNewItemOK.Name = "buttonNewItemOK";
            buttonNewItemOK.Size = new Size(112, 34);
            buttonNewItemOK.TabIndex = 5;
            buttonNewItemOK.Text = "OK";
            buttonNewItemOK.UseVisualStyleBackColor = true;
            buttonNewItemOK.Click += buttonNewItemOK_Click;
            // 
            // FormNewItem
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(736, 209);
            Controls.Add(buttonNewItemOK);
            Controls.Add(buttonNewItemCancel);
            Controls.Add(textBoxNewItemDescription);
            Controls.Add(textBoxNewItemName);
            Controls.Add(labelNewItemDescription);
            Controls.Add(labelNewItemName);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNewItem";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Group";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNewItemName;
        private Label labelNewItemDescription;
        private TextBox textBoxNewItemName;
        private TextBox textBoxNewItemDescription;
        private Button buttonNewItemCancel;
        private Button buttonNewItemOK;
    }
}