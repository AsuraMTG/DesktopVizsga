using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grefikusasztali
{
    public partial class Form1 : Form
    {
        List<User> users = new List<User>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AdatokBeolvasasa();
            listBox1.Items.Clear();
            listBox1.DataSource = users;
        }

        private void AdatokBeolvasasa()
        {
            string inputFajl = "todousers.csv";
            using (StreamReader sr = new StreamReader(inputFajl))
            {
                string sor = null;
                sr.ReadLine();
                while ((sor = sr.ReadLine()) != null)
                {
                    string[] adatok = sor.Split(';');
                    User user = new User();
                    user.user_id = int.Parse(adatok[0]);
                    user.name = adatok[1];
                    user.email = adatok[2];
                    user.birthday = DateTime.Parse(adatok[3]);
                    users.Add(user);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }
            User selectedUser = (User)listBox1.SelectedItem;
            textBox1.Text = selectedUser.name;
        }
    }
}
