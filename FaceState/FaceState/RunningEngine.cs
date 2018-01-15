using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace FaceState
{
    public delegate void Agent(int Nub, string[] information);
    class RunningEngine
    {

        #region 单例模式

        /// <summary>
        /// 私有的运行的字段
        /// </summary>
        private static  RunningEngine _RunningEngine;

        /// <summary>
        /// 私有的构造函数
        /// </summary>
        private RunningEngine()
        {
            matrix = new string[4,4];
        }

        /// <summary>
        /// 单例构造函数
        /// </summary>
        public static RunningEngine Initialization
        {
           get
           {
                if (_RunningEngine == null)
                {
                    _RunningEngine = new RunningEngine();
                }
                return _RunningEngine;
           }
            
        }

        #endregion

        #region 私有的运行矩阵

        public Agent agent;

        /// <summary>
        /// 4个一排  也就是 以4进1  一面最多 三排
        /// 每个数组存取一个对象{寝室号，成员1，成员2，成员3，成员4}
        /// 当存在的时候 那么存
        /// </summary>
        public List<string[]> infrormation= new List<string[]>();

        /// <summary>
        /// 绘制一个寝室的人员信息
        /// </summary>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <param 人员信息="information"></param>
        /// <param 人员索引坐标="indexX"></param>
        /// <param name="indexY"></param>
        /// <param 绘图信息="my"></param>
        /// <returns></returns>
        public void  DropItem(ImageList a, ImageList c, string[] information, int indexX, int indexY, Graphics my)
        {         
            System.Drawing.Image ac = System.Drawing.Image.FromFile(@"C:\Users\Administrator\Desktop\PNG图片\2.png");
            a.Images.Add(ac);


            string ImageAdress =@"C:\Users\Administrator\Desktop\PNG图片\1.png";
          //  Image DrawImage = Image.FromFile(@"" + ImageAdress);
            System.Drawing.Image b = System.Drawing.Image.FromFile(ImageAdress);
            c.Images.Add(b);
            int x  = indexX * 200 + 70;
             int y = indexY * 200 + 70;
           //int x = indexX * 200 + 70;
            // int y = indexY * 200 - 130;
            a.Draw(my, new Point(x, y), 0);

            for (int i = 0; i < (information.Length); i++)
            {

                switch (i)
                {

                    case 0:

                        my.DrawString(information[i], new Font("Arial", 9), new SolidBrush(Color.Black), new PointF(x + 30, y + 30));

                        break;
                    case 1:
                      
                        my.DrawString(information[i], new Font("Arial", 9), new SolidBrush(Color.Black), new PointF(x - 50, y + 50));
                        c.Draw(my, new Point(x - 50, y), 0);
                        break;
                    case 2:
                        my.DrawString(information[i], new Font("Arial", 9), new SolidBrush(Color.Black), new PointF(x + 50, y - 50));
                       
                        c.Draw(my, new Point(x+10 , y - 50), 0);
                        break;
                    case 3:
                        my.DrawString(information[i], new Font("Arial", 9), new SolidBrush(Color.Black), new PointF(x + 80, y + 50 ));
                        
                        c.Draw(my, new Point(x + 80, y), 0);
                        break;
                    case 4:
                        // Graphics mys = Graphics.FromHwnd(this.Handle);
                        my.DrawString(information[i], new Font("Arial", 9), new SolidBrush(Color.Black), new PointF(x + 50, y + 80));
                       
                        c.Draw(my, new Point(x +10, y + 80), 0);
                        break;
                }
            }
           

        }

        public void start()
        {
            for (int i = 0; i < RunningEngine.Initialization.infrormation.Count; i++)
            {
                agent(i, RunningEngine.Initialization.infrormation[i]);
            }
        }

        #endregion


        #region 绘制矩阵

        /// <summary>
        /// 
        /// </summary>
        private string[,] matrix;

        #endregion

    }
}
