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
namespace YCF_Server.Web.Respiratory
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int RID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(RID);
				}
			}
		}
			
	private void ShowInfo(int RID)
	{
		YCF_Server.BLL.Respiratory bll=new YCF_Server.BLL.Respiratory();
		YCF_Server.Model.Respiratory model=bll.GetModel(RID);
		this.lblRID.Text=model.RID.ToString();
		this.txtRtime.Text=model.Rtime.ToString();
		this.txtBreathe.Text=model.Breathe.ToString();
		this.txtHeartRate.Text=model.HeartRate.ToString();
		this.txtPID.Text=model.PID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtRtime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtBreathe.Text))
			{
				strErr+="呼吸格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtHeartRate.Text))
			{
				strErr+="心率格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="外键-病人格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int RID=int.Parse(this.lblRID.Text);
			DateTime Rtime=DateTime.Parse(this.txtRtime.Text);
			int Breathe=int.Parse(this.txtBreathe.Text);
			int HeartRate=int.Parse(this.txtHeartRate.Text);
			int PID=int.Parse(this.txtPID.Text);


			YCF_Server.Model.Respiratory model=new YCF_Server.Model.Respiratory();
			model.RID=RID;
			model.Rtime=Rtime;
			model.Breathe=Breathe;
			model.HeartRate=HeartRate;
			model.PID=PID;

			YCF_Server.BLL.Respiratory bll=new YCF_Server.BLL.Respiratory();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
