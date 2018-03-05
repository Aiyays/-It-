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
namespace YCF_Server.Web.RemindRecord
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
		YCF_Server.BLL.RemindRecord bll=new YCF_Server.BLL.RemindRecord();
		YCF_Server.Model.RemindRecord model=bll.GetModel(RID);
		this.lblRID.Text=model.RID.ToString();
		this.txtPID.Text=model.PID.ToString();
		this.txtRcontent.Text=model.Rcontent;
		this.txtRemindTime.Text=model.RemindTime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="病人格式错误！\\n";	
			}
			if(this.txtRcontent.Text.Trim().Length==0)
			{
				strErr+="内容不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtRemindTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int RID=int.Parse(this.lblRID.Text);
			int PID=int.Parse(this.txtPID.Text);
			string Rcontent=this.txtRcontent.Text;
			DateTime RemindTime=DateTime.Parse(this.txtRemindTime.Text);


			YCF_Server.Model.RemindRecord model=new YCF_Server.Model.RemindRecord();
			model.RID=RID;
			model.PID=PID;
			model.Rcontent=Rcontent;
			model.RemindTime=RemindTime;

			YCF_Server.BLL.RemindRecord bll=new YCF_Server.BLL.RemindRecord();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
