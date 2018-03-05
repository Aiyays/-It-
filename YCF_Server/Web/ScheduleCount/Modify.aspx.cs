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
namespace YCF_Server.Web.ScheduleCount
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int SCID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(SCID);
				}
			}
		}
			
	private void ShowInfo(int SCID)
	{
		YCF_Server.BLL.ScheduleCount bll=new YCF_Server.BLL.ScheduleCount();
		YCF_Server.Model.ScheduleCount model=bll.GetModel(SCID);
		this.lblSCID.Text=model.SCID.ToString();
		this.txtName.Text=model.Name;
		this.txtStartTime.Text=model.StartTime;
		this.txtEndTime.Text=model.EndTime;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="班次名不能为空！\\n";	
			}
			if(this.txtStartTime.Text.Trim().Length==0)
			{
				strErr+="班次开始时间不能为空！\\n";	
			}
			if(this.txtEndTime.Text.Trim().Length==0)
			{
				strErr+="班次结束时间不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int SCID=int.Parse(this.lblSCID.Text);
			string Name=this.txtName.Text;
			string StartTime=this.txtStartTime.Text;
			string EndTime=this.txtEndTime.Text;


			YCF_Server.Model.ScheduleCount model=new YCF_Server.Model.ScheduleCount();
			model.SCID=SCID;
			model.Name=Name;
			model.StartTime=StartTime;
			model.EndTime=EndTime;

			YCF_Server.BLL.ScheduleCount bll=new YCF_Server.BLL.ScheduleCount();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
