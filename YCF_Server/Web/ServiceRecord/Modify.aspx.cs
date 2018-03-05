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
namespace YCF_Server.Web.ServiceRecord
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
		YCF_Server.BLL.ServiceRecord bll=new YCF_Server.BLL.ServiceRecord();
		YCF_Server.Model.ServiceRecord model=bll.GetModel(RID);
		this.lblRID.Text=model.RID.ToString();
		this.txtRTime.Text=model.RTime.ToString();
		this.txtEvaluate.Text=model.Evaluate;
		this.txtPicture.Text=model.Picture;
		this.txtEID.Text=model.EID.ToString();
		this.txtPID.Text=model.PID.ToString();
		this.txtSID.Text=model.SID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtRTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}
			if(this.txtEvaluate.Text.Trim().Length==0)
			{
				strErr+="评价不能为空！\\n";	
			}
			if(this.txtPicture.Text.Trim().Length==0)
			{
				strErr+="照片不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtEID.Text))
			{
				strErr+="外键-员工格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="外键-病人格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtSID.Text))
			{
				strErr+="外键-服务格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int RID=int.Parse(this.lblRID.Text);
			DateTime RTime=DateTime.Parse(this.txtRTime.Text);
			string Evaluate=this.txtEvaluate.Text;
			string Picture=this.txtPicture.Text;
			int EID=int.Parse(this.txtEID.Text);
			int PID=int.Parse(this.txtPID.Text);
			int SID=int.Parse(this.txtSID.Text);


			YCF_Server.Model.ServiceRecord model=new YCF_Server.Model.ServiceRecord();
			model.RID=RID;
			model.RTime=RTime;
			model.Evaluate=Evaluate;
			model.Picture=Picture;
			model.EID=EID;
			model.PID=PID;
			model.SID=SID;

			YCF_Server.BLL.ServiceRecord bll=new YCF_Server.BLL.ServiceRecord();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
