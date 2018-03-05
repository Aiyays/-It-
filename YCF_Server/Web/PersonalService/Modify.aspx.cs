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
namespace YCF_Server.Web.PersonalService
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int PSID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(PSID);
				}
			}
		}
			
	private void ShowInfo(int PSID)
	{
		YCF_Server.BLL.PersonalService bll=new YCF_Server.BLL.PersonalService();
		YCF_Server.Model.PersonalService model=bll.GetModel(PSID);
		this.lblPSID.Text=model.PSID.ToString();
		this.txtPID.Text=model.PID.ToString();
		this.txtGID.Text=model.GID.ToString();
		this.txtSID.Text=model.SID.ToString();
		this.txtPTime.Text=model.PTime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="外键-病人格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtGID.Text))
			{
				strErr+="外键-组格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtSID.Text))
			{
				strErr+="外键-服务格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtPTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int PSID=int.Parse(this.lblPSID.Text);
			int PID=int.Parse(this.txtPID.Text);
			int GID=int.Parse(this.txtGID.Text);
			int SID=int.Parse(this.txtSID.Text);
			DateTime PTime=DateTime.Parse(this.txtPTime.Text);


			YCF_Server.Model.PersonalService model=new YCF_Server.Model.PersonalService();
			model.PSID=PSID;
			model.PID=PID;
			model.GID=GID;
			model.SID=SID;
			model.PTime=PTime;

			YCF_Server.BLL.PersonalService bll=new YCF_Server.BLL.PersonalService();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
