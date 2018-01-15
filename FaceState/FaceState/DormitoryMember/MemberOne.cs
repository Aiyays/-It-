using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceState.DormitoryMember
{
    //画出成员
    public class MemberOne: Dormitory
    {
        public MemberOne(string x,string y,string information ):base(int.Parse(x),int.Parse(y),information)
        {

        }

        public override string ImageAdress => @"PNG图片\1.png";

        public override int StringPixeX => ImagePixeX;

        public override int StringPixeY => ImagePixeY+50;
    }
}
