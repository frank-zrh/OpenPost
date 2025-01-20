using OpenPostLib.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenPostForms.dialogs
{
    public partial class FormNewItem : Form
    {
        public object NewItem { get; set; }
        public FormItemType ItemType { get; set; }

        public FormNewItem()
        {
            InitializeComponent();
            ItemType = FormItemType.Null;
        }

        public void SetTitle(string title)
        {
            this.Text = title;
        }

        private void buttonNewItemOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNewItemName.Text))
            {
                MessageBox.Show("Please enter a name for the group", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (ItemType)
            {
                case FormItemType.Project:
                    NewItem = new Project
                    {
                        Name = textBoxNewItemName.Text,
                        Description = textBoxNewItemDescription.Text,
                        Id = Guid.NewGuid(),
                        Order = 999
                    };
                    break;
                case FormItemType.Group:                   
                    NewItem = new Group
                    {
                        Name = textBoxNewItemName.Text,
                        Description = textBoxNewItemDescription.Text,
                        Id = Guid.NewGuid(),
                        Order = 999
                    };
                    break;
                case FormItemType.Request:
                    NewItem = new RequestInfo
                    {
                        Name = textBoxNewItemName.Text,
                        Description = textBoxNewItemDescription.Text,
                        Id=Guid.NewGuid(),
                        Order = 999
                    };
                    break;

            }

            this.Hide();

        }

        private void buttonNewItemCancel_Click(object sender, EventArgs e)
        {            
            this.Hide();
        }
    }

    public enum FormItemType
    {
        Null,
        Project,
        Group,
        Request
    }


}
