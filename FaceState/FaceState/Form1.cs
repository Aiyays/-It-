using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;
using FaceState.DormitoryMember;
using System.Drawing.Drawing2D;

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
        DrawHome a;
        private void button1_Click(object sender, EventArgs e)
        {

            //    this.AutoScrollMinSize = new Size(0, 1000);///滚动框

             a = new DrawHome("70", "70", new string[] { "633" });
            a.Draw(imageList1,imageList2, Graphics.FromHwnd(panel1.Handle));
         
            //RunningEngine.Initialization.start();

            //     Debug.Print(this.AutoScrollPosition.Y.ToString());
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
            RunningEngine.Initialization.DropItem(this.imageList1, this.imageList2, information, indexX, indexY, Graphics.FromHwnd(panel1.Handle));
          

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.HorizontalScroll.Visible = true;
            this.VerticalScroll.Visible = false;

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            a.Chionce(20);
            Graphics.FromHwnd(panel1.Handle).Clear(Color.WhiteSmoke);
            a.Draw(imageList1, imageList2, Graphics.FromHwnd(panel1.Handle));

            // RunningEngine.Initialization.start();
            // RunningEngine.Initialization.start();
            // this.AutoScrollMinSize = new Size(35, position.Y + 1000);///滚动框

            // Graphics.FromHwnd(panel1.Handle).Clear(Color.WhiteSmoke);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {   
            
        }

        private void DrawRectBackImage()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            try
            {
                //在内存创建一块和panel一大小的区域
               // Bitmap bitmap = new Bitmap(_currentChart.ClientSize.Width, _currentChart.ClientSize.Height);
             //   using (Graphics buffer = Graphics.FromImage(bitmap))
                //{
                   // buffer.Transform = new Matrix();

                    //要画的背景图片

//buffer.DrawImage();

                    //背景图片上的内容
                   // DrawFitAdjustRect(buffer);
                    //屏幕绘图
                  //  g.DrawImage(bitmap, 0, 0); //将buffer绘制到屏幕上
             //   }
            }
            finally
            {
                g.Dispose();
            }
        }


    }
}
