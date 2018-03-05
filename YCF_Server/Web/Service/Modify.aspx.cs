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
namespace YCF_Server.Web.Service
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int SID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(SID);
				}
			}
		}
			
	private void ShowInfo(int SID)
	{
		YCF_Server.BLL.Service bll=new YCF_Server.BLL.Service();
		YCF_Server.Model.Service model=bll.GetModel(SID);
		this.lblSID.Text=model.SID.ToString();
		this.txtSName.Text=model.SName;
		this.txtStartTime.Text=model.StartTime.ToString();
		this.txtEndTime.Text=model.EndTime.ToString();
		this.txtFrequency.Text=model.Frequency.ToString();
		this.txtMagnitude.Text=model.Magnitude.ToString();
		this.txtStandard.Text=model.Standard;
		this.txtSTID.Text=model.STID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtSName.Text.Trim().Length==0)
			{
				strErr+="服务名称不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtStartTime.Text))
			{
				strErr+="开始时间格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtEndTime.Text))
			{
				strErr+="结束时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtFrequency.Text))
			{
				strErr+="次数频率格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtMagnitude.Text))
			{
				strErr+="量值格式错误！\\n";	
			}
			if(this.txtStandard.Text.Trim().Length==0)
			{
				strErr+="标准不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtSTID.Text))
			{
				strErr+="外键-服务类型格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int SID=int.Parse(this.lblSID.Text);
			string SName=this.txtSName.Text;
			DateTime StartTime=DateTime.Parse(this.txtStartTime.Text);
			DateTime EndTime=DateTime.Parse(this.txtEndTime.Text);
			int Frequency=int.Parse(this.txtFrequency.Text);
			int Magnitude=int.Parse(this.txtMagnitude.Text);
			string Standard=this.txtStandard.Text;
			int STID=int.Parse(this.txtSTID.Text);


			YCF_Server.Model.Service model=new YCF_Server.Model.Service();
			model.SID=SID;
			model.SName=SName;
			model.StartTime=StartTime;
			model.EndTime=EndTime;
			model.Frequency=Frequency;
			model.Magnitude=Magnitude;
			model.Standard=Standard;
			model.STID=STID;

			YCF_Server.BLL.Service bll=new YCF_Server.BLL.Service();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
