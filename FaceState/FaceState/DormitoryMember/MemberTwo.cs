using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceState
{
    //画出寝室成员

    public class MemberTwo:Dormitory
    {
        public MemberTwo(string x, string y, string information):base(int.Parse(x),int.Parse(y),information)
        {

        }
        public override string ImageAdress => @"PNG图片\1.png";

        public override int StringPixeX => ImagePixeX+40;

        public override int StringPixeY => ImagePixeY;
    }
}
