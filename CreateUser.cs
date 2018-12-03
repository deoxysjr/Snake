using System;
using System.IO;
using System.Windows.Forms;

namespace Snake
{
    public partial class CreateUser : Form
    {
        public Main MainForm;

        public CreateUser(Main form)
        {
            this.MainForm = form;
            InitializeComponent();
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            Sorry.Visible = false;

            if (UserNameTextbox.Text.Length == 0)
            {
                Sorry.Visible = true;
                Sorry.Text = "please enter a name first";
            }
            else
            {
                if (File.Exists($"./users/{UserNameTextbox.Text}.gsf"))
                {
                    Sorry.Text = "Sorry but this user name is already in use";
                    Sorry.Visible = true;
                }
                else
                {
                    File.Create($"./users/{UserNameTextbox.Text}.gsf").Close();
                    
                    MainForm.SellectUser.Items.Add(UserNameTextbox.Text);
                    this.Close();
                }
            }
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
