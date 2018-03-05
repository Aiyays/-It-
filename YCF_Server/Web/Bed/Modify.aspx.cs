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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int BID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(BID);
				}
			}
		}
			
	private void ShowInfo(int BID)
	{
		YCF_Server.BLL.Bed bll=new YCF_Server.BLL.Bed();
		YCF_Server.Model.Bed model=bll.GetModel(BID);
		this.lblBID.Text=model.BID.ToString();
		this.txtNumber.Text=model.Number;
		this.txtPosture.Text=model.Posture;
		this.txtPID.Text=model.PID.ToString();
		this.txtEID.Text=model.EID.ToString();
		this.txtAID.Text=model.AID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int BID=int.Parse(this.lblBID.Text);
			string Number=this.txtNumber.Text;
			string Posture=this.txtPosture.Text;
			int PID=int.Parse(this.txtPID.Text);
			int EID=int.Parse(this.txtEID.Text);
			int AID=int.Parse(this.txtAID.Text);


			YCF_Server.Model.Bed model=new YCF_Server.Model.Bed();
			model.BID=BID;
			model.Number=Number;
			model.Posture=Posture;
			model.PID=PID;
			model.EID=EID;
			model.AID=AID;

			YCF_Server.BLL.Bed bll=new YCF_Server.BLL.Bed();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
