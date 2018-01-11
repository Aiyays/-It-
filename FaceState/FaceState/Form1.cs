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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            asd(0, 0,new List<string>() { "644","张熙贤","吴宗阳","张进涛"});
           


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param 索引坐标="indexX"></param>
        /// <param 索引坐标="indexY"></param>
        /// <param 有几个人在="Nub"></param>
        /// <param 人员信息="information">寝室号，在寝姓名1，在寝姓名2，在寝姓名3，在寝姓名四</param>
        public void asd(int indexX,int indexY,List<string> information)
        {

            foreach (var item in DropItem(information,indexX,indexY))
            {
                this.Controls.Add(item);
            }


        }

        public List<Label> DropItem( List<string> information, int indexX, int indexY)
        {
            System.Drawing.Image ac = System.Drawing.Image.FromFile(@"C:\Users\Administrator\Desktop\PNG图片\2.png");
            Graphics my = Graphics.FromHwnd(this.Handle);
            imageList1.Images.Add(ac);
            System.Drawing.Image b = System.Drawing.Image.FromFile(@"C:\Users\Administrator\Desktop\PNG图片\blue_business_06.png");
            imageList2.Images.Add(b);
            List<Label> D = new List<Label>();

            int x = indexX * 200 + 70;
            int y = indexY * 200 + 70;
            imageList1.Draw(my, new Point(x, y), 0);
           
            for (int i = 0; i < (information.Count); i++)
            {
                D.Add(new Label());
                System.Diagnostics.Debug.Print(i + "");
                D[i].Text = information[i];
                D[i].Width = 50;
                switch (i)
                {
                    case 0:
                        D[i].Font = new Font("宋体", 12);
                        D[i].Location = new Point(x + 20, y + 30);
                        break;
                    case 1:
                        D[i].Location = new Point(x - 50, y + 50);

                        imageList2.Draw(my, new Point(x - 50, y), 0);
                        break;
                    case 2:
                       

                        D[i].Location = new Point(x + 50, y - 50);
                        imageList2.Draw(my, new Point(x + 10, y - 50), 0);
                        break;
                    case 3:
                      
                        D[i].Location = new Point(x + 80, y + 50);
                        imageList2.Draw(my, new Point(x + 80, y), 0);
                        break;
                    case 4:

                        D[i].Location = new Point(x + 50, y + 80);
                        imageList2.Draw(my, new Point(x + 10, y + 80), 0);
                        break;
                }
            }
            return D;
   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Drawing.Image ac = System.Drawing.Image.FromFile(@"C:\Users\Administrator\Desktop\PNG图片\2.png");
            Graphics my = Graphics.FromHwnd(this.Handle);
            imageList1.Images.Add(ac);
            System.Drawing.Image b = System.Drawing.Image.FromFile(@"C:\Users\Administrator\Desktop\PNG图片\blue_business_06.png");
            imageList2.Images.Add(b);
            listView1.LargeImageList.Images.Add(ac);
            listView1.LargeImageList.Draw(my, new Point(0, 0), 0);
            Label a = new Label();
            a.Text = "dasdqa";
            listView1.Controls.Add(a); listView1.Controls.Add(new VScrollBar());
            ImageList adsa = new ImageList();


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
