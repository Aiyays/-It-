using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace YCF_Server.Web.EmpRankTitle
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtEID.Text))
			{
				strErr+="（外键） 关联员工表格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtTID.Text))
			{
				strErr+="外键（关联职称表）格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtRTID.Text))
			{
				strErr+="外键（职称等级关联表）格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int EID=int.Parse(this.txtEID.Text);
			int TID=int.Parse(this.txtTID.Text);
			int RTID=int.Parse(this.txtRTID.Text);

			YCF_Server.Model.EmpRankTitle model=new YCF_Server.Model.EmpRankTitle();
			model.EID=EID;
			model.TID=TID;
			model.RTID=RTID;

			YCF_Server.BLL.EmpRankTitle bll=new YCF_Server.BLL.EmpRankTitle();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
