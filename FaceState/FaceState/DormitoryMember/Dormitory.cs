using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FaceState
{
    public  abstract class Dormitory
    {

        public  int ImagePixeX { get; set; }//绘制的图片的坐标
        public  int ImagePixeY { get; set; }

        public abstract int StringPixeX { get;  }//绘制文字
        public abstract int StringPixeY { get; }

        public abstract string ImageAdress { get;  }//图片的地址

        public   string DormitoryInformation { get; set; }//文字信息



        //构造
        public Dormitory(int imagePixeX,int imagePixeY,string information)
        {
            this.ImagePixeX = imagePixeX;
            this.ImagePixeY = imagePixeY;
            this.DormitoryInformation = information;
        }

        /// <summary>
        /// 绘制
        /// </summary>
        public void DrawImage(Graphics g, ImageList imageList)
        {
            //System.Drawing.Image b = System.Drawing.Image.FromFile(@"C:\Users\Administrator\Desktop\PNG图片\1.png");
            Image DrawImage = Image.FromFile( ImageAdress);
            imageList.Images.Add(DrawImage);
            imageList.Draw(g, new Point(ImagePixeX, ImagePixeY), 0);
            g.DrawString(DormitoryInformation, new Font("Arial", 9), new SolidBrush(Color.Black), new PointF(StringPixeX, StringPixeY));

          }
        // my.DrawString(information[i], new Font("Arial", 9), new SolidBrush(Color.Black), new PointF(x + 30, y + 30));

        public bool CanDown()
        {

            //缺少一个判断是否可以移动的方法
            return true;
        }

        public void MoveDown()
        {
            if (CanDown())
            {
                ImagePixeY -= 10;
            }
        }

        public bool CanUp()
        {
            return true;
        }

        public void MoveUp()
        {
            if (CanUp())
            {
                ImagePixeY += 10;
            }
        }
       

    }
}
