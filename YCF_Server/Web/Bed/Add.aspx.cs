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
namespace YCF_Server.Web.Bed
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtNumber.Text.Trim().Length==0)
			{
				strErr+="编号不能为空！\\n";	
			}
			if(this.txtPosture.Text.Trim().Length==0)
			{
				strErr+="姿态不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="外键-病人格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtEID.Text))
			{
				strErr+="外键-设备格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtAID.Text))
			{
				strErr+="外键-房间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Number=this.txtNumber.Text;
			string Posture=this.txtPosture.Text;
			int PID=int.Parse(this.txtPID.Text);
			int EID=int.Parse(this.txtEID.Text);
			int AID=int.Parse(this.txtAID.Text);

			YCF_Server.Model.Bed model=new YCF_Server.Model.Bed();
			model.Number=Number;
			model.Posture=Posture;
			model.PID=PID;
			model.EID=EID;
			model.AID=AID;

			YCF_Server.BLL.Bed bll=new YCF_Server.BLL.Bed();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
