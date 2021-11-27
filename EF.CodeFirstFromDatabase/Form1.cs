using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EF.CodeFirstFromDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Model1 context = new CodeFirstFromDatabase.Model1())
            {
                if (context.Database.CreateIfNotExists())
                {
                    MessageBox.Show("数据库创建成功");
                }
                else
                {
                    MessageBox.Show("数据库已存在");
                }
            }
        }
    }
}
