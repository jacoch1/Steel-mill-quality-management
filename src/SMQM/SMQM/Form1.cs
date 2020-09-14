using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMQM
{
    public partial class Form1 : Form
    {

        Form0 form0;
        string[] str = new string[6];
        //private Form0 form0;
        public Form1(Form0 f)
        {
            InitializeComponent();
            button3.Visible = false;//隐藏修改按钮
            form0= f;
        }
        /// <summary>
        /// 类变量数组记录初始值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="f"></param>
        public Form1(string[] a, Form0 f)//类变量数组记录初始值，方便修改完后对比修改的哪一条
        {

            InitializeComponent();
            for (int i = 0; i < 6; i++)
            {
                str[i] = a[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
            textBox6.Text = str[5];
        
            button1.Visible = false;//隐藏保存按钮
            form0 = f;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //添加一条物料记录
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" )
            {

                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "insert into Steel values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                // MessageBox.Show(sql);
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("插入成功");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                    textBox5.Text = null;
                    textBox6.Text = null;
                    


                }
                form0.Table();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
        
        }
        //修改一条物料记录
        private void button3_Click(object sender, EventArgs e)
        {
             

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" )
            {

                MessageBox.Show("修改后有空项，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox1.Text != str[0])
                {
                    string sql = "update Steel set 编号='" + textBox1.Text + "'where 编号='" + str[0] + "'and 钢种='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[0] = textBox1.Text;

                }

                if (textBox2.Text != str[1])
                {
                    string sql = "update Steel set 钢种='" + textBox2.Text + "'where 编号='" + str[0] + "'and 钢种='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[1] = textBox2.Text;

                }

                if (textBox3.Text != str[2])
                {
                    string sql = "update Steel set 熔点='" + textBox3.Text + "'where 编号='" + str[0] + "'and 钢种='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[2] = textBox3.Text;

                }

                if (textBox4.Text != str[3])
                {
                    string sql = "update Steel set 密度='" + textBox4.Text + "'where 编号='" + str[0] + "'and 钢种='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[3] = textBox4.Text;

                }

                if (textBox5.Text != str[4])
                {
                    string sql = "update Steel set 粘度='" + textBox5.Text + "'where 编号='" + str[0] + "'and 钢种='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[4] = textBox5.Text;

                }
                if (textBox6.Text != str[5])
                {
                    string sql = "update Steel set 凝固区间='" + textBox6.Text + "'where 编号='" + str[0] + "'and 钢种='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[5] = textBox6.Text;

                }
               
                form0.Table();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
