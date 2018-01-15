using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceState.DormitoryMember
{
    /// <summary>
    /// 画出整个宿舍
    /// </summary>
    
    public class DrawHome
    {
        #region 坐标信息和成员信息

        public int pixeX;//DrawDoorX坐标
        public int pixeY;//DrawDoorY坐标
        private string[] information;//{寝室号，成员1，成员2，成员3，成员4}
        private Dormitory[] info;//
        #endregion

        
        public DrawHome(string  pixeX,string   pixeY,string[] information)
        {
            this.pixeX = int.Parse(pixeX);
            this.pixeY = int.Parse(pixeY);
            this.information = information;
            info = new Dormitory[information.Length];
            AddNummber();
           
        }

        public void Draw(ImageList image1,ImageList image2,Graphics g)
        {
            foreach (var item in info)
            {
                if (item == info[0])
                {
                    item.DrawImage(g,image1);
                }
                else
                {
                    item.DrawImage(g,image2);
                }
            }
        }

        public void AddNummber()
        {
            info[0] = new DrawDoor(pixeX.ToString(), pixeY.ToString(), information[0]);
            for (int i = 0; i < (information.Length); i++)
            {
                switch (i)
                {
                    case 1:
                        info[1] = new MemberOne((pixeX-50).ToString(), pixeY.ToString(),information[1]);
                      break;
                    case 2:
                        info[2] = new MemberTwo((pixeX +10).ToString(), (pixeY-50).ToString(), information[1]);
                        break;
                    case 3:
                        info[3] = new MemberOne((pixeX +80).ToString(), pixeY.ToString(), information[1]);
                        break;
                    case 4:
                        info[4] = new MemberTwo((pixeX +10).ToString(), (pixeY+80).ToString(), information[1]);
                        break;
                }
            }
        }

        public void Chionce(int i)
        {
            foreach (var item in info)
            {
                item.ImagePixeY += i;
            }
        }


        
        
         
    }
}
