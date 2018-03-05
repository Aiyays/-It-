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
namespace YCF_Server.Web.PensnonalDrug
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int PDID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(PDID);
				}
			}
		}
			
	private void ShowInfo(int PDID)
	{
		YCF_Server.BLL.PensnonalDrug bll=new YCF_Server.BLL.PensnonalDrug();
		YCF_Server.Model.PensnonalDrug model=bll.GetModel(PDID);
		this.lblPDID.Text=model.PDID.ToString();
		this.txtDTime.Text=model.DTime.ToString();
		this.txtFrequency.Text=model.Frequency;
		this.txtDose.Text=model.Dose;
		this.txtDID.Text=model.DID.ToString();
		this.txtEID.Text=model.EID.ToString();
		this.txtPID.Text=model.PID.ToString();
		this.txtIMG.Text=model.IMG;
		this.txtRemark.Text=model.Remark;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtDTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}
			if(this.txtFrequency.Text.Trim().Length==0)
			{
				strErr+="频次不能为空！\\n";	
			}
			if(this.txtDose.Text.Trim().Length==0)
			{
				strErr+="剂量不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtDID.Text))
			{
				strErr+="外键-药品格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtEID.Text))
			{
				strErr+="外键-员工格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="外键-病人格式错误！\\n";	
			}
			if(this.txtIMG.Text.Trim().Length==0)
			{
				strErr+="图片不能为空！\\n";	
			}
			if(this.txtRemark.Text.Trim().Length==0)
			{
				strErr+="Remark不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int PDID=int.Parse(this.lblPDID.Text);
			DateTime DTime=DateTime.Parse(this.txtDTime.Text);
			string Frequency=this.txtFrequency.Text;
			string Dose=this.txtDose.Text;
			int DID=int.Parse(this.txtDID.Text);
			int EID=int.Parse(this.txtEID.Text);
			int PID=int.Parse(this.txtPID.Text);
			string IMG=this.txtIMG.Text;
			string Remark=this.txtRemark.Text;


			YCF_Server.Model.PensnonalDrug model=new YCF_Server.Model.PensnonalDrug();
			model.PDID=PDID;
			model.DTime=DTime;
			model.Frequency=Frequency;
			model.Dose=Dose;
			model.DID=DID;
			model.EID=EID;
			model.PID=PID;
			model.IMG=IMG;
			model.Remark=Remark;

			YCF_Server.BLL.PensnonalDrug bll=new YCF_Server.BLL.PensnonalDrug();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
