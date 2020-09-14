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
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
            Table();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// 显示表格信息
        /// </summary>
        public void Table()
        {
            dataGridView1.Rows.Clear();//清除表格信息
            string sql = "select *from Steel";

            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e,f;
                a = dr["编号"].ToString();
                b = dr["钢种"].ToString();
                c = dr["熔点"].ToString();
                d = dr["密度"].ToString();
                e = dr["粘度"].ToString();
                f = dr["凝固区间"].ToString();
                
                string[] str = { a, b, c, d, e,f };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭数据库的链接



        }

        private void 添加原料信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(this);//this是本类的生成的对象 this传给form1
            f.ShowDialog();
            Table();

        }
        private void 修改原料信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString(), dataGridView1.SelectedCells[4].Value.ToString(), dataGridView1.SelectedCells[5].Value.ToString()};
            //MessageBox.Show(str[0]+str[4]);  
            Form1 f = new Form1(str, this);
            f.ShowDialog();
        }

        private void 删除原料信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定删除？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string name, id;
                name = dataGridView1.SelectedCells[0].Value.ToString();//获取用户选定的单元格的集合，第0个单元格的值转换为字符串
                id = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from Steel where 编号='" + name + "'and 钢种='" + id + "'";
                //  MessageBox.Show(sql);
                Dao dao = new Dao();
                dao.Excute(sql);
                Table();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form0_Load(object sender, EventArgs e)
        {

        }

        private void Form0_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Table();
        }
    }
}
