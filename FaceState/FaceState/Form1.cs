using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace FaceState
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 20; i++)
            {
                RunningEngine.Initialization.infrormation.Add(new string[] { "633", "王舒婷", "张熙贤", "王舒婷", "张熙贤" });
            }

            RunningEngine.Initialization.agent = new Agent(DrawDorm);
        }

        private void button1_Click(object sender, EventArgs e)
        {


            DrawDorm(0, new string[] { "644", "张熙贤", "吴宗阳", "张进涛", "陶金祥" });
            DrawDorm(1, new string[] { "633", "王舒婷", "张熙贤", "王舒婷", "张熙贤" });
            DrawDorm(2, new string[] { "355", "赵耀祖", "陈德", "张迎港", "赵广" });

            DrawDorm(3, new string[] { "355", "赵耀祖", "陈德", "张迎港", "赵广" });
            DrawDorm(4, new string[] { "355", "赵耀祖", "陈德", "张迎港", "赵广" });
            DrawDorm(5, new string[] { "355", "赵耀祖", "陈德", "张迎港", "赵广" });
            Point position = new Point(0, 8);
            this.AutoScrollMinSize = new Size(0, position.Y + 1000);///滚动框
            //RunningEngine.Initialization.infrormation.Draw(e.Graphics);



        }


        /// <summary>
        /// 绘制出一个宿舍
        /// </summary>
        /// <param 索引坐标="indexX"></param>
        /// <param 索引坐标="indexY"></param>
        /// <param 人员信息="information">寝室号，在寝姓名1，在寝姓名2，在寝姓名3，在寝姓名四</param>
        public void DrawDorm(int Nub, string[] information)
        {
            
            int indexX;

            int indexY;

            indexX = Nub % 4;
            indexY = Nub / 4;
            foreach (var item in RunningEngine.Initialization.DropItem(this.imageList1,this.imageList2, information,indexX,indexY, Graphics.FromHwnd(this.Handle)))
            {
                this.Controls.Add(item);
            }


        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // RunningEngine.Initialization.start();
            String drawString = "吴宗阳";//要显示的字符串
            Font drawFont = new Font("Arial", 9);//显示的字符串使用的字体
            SolidBrush drawBrush = new SolidBrush(Color.Black);//写字符串用的刷子
            PointF drawPoint = new PointF(20, 20);//显示的字符串左上角的坐标
            Graphics a = Graphics.FromHwnd(this.Handle);
            a.DrawString(drawString, drawFont, drawBrush, drawPoint);
            a.DrawString(drawString, drawFont, drawBrush, new PointF(20, 40));
            Point position = new Point(0, 8);
            this.AutoScrollMinSize = new Size(35, position.Y + 1000);///滚动框
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {


        }
    }
}
