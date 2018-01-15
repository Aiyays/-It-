using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceState
{
    //画出寝室

    class DrawDoor : Dormitory
    {

        /// <summary>
        /// 坐标 （70，70）是最标准的
        /// </summary>
        /// <param name="doorNub"></param>
        /// <param name="pixeX"></param>
        /// <param name="pixeY"></param>

        public DrawDoor( string pixeX, string pixeY, string doorNub) : base(int.Parse(pixeX), int.Parse(pixeY), doorNub)
        {

        }

        public override string ImageAdress => @"PNG图片\2.png";

        public override int StringPixeX => ImagePixeX + 30;

        public override int StringPixeY => ImagePixeY + 30;

    }


}
