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
namespace YCF_Server.Web.Patient
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int PID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(PID);
				}
			}
		}
			
	private void ShowInfo(int PID)
	{
		YCF_Server.BLL.Patient bll=new YCF_Server.BLL.Patient();
		YCF_Server.Model.Patient model=bll.GetModel(PID);
		this.lblPID.Text=model.PID.ToString();
		this.txtBailorID.Text=model.BailorID.ToString();
		this.txtRelationship.Text=model.Relationship;
		this.txtCheckInTime.Text=model.CheckInTime.ToString();
		this.txtOutTime.Text=model.OutTime.ToString();
		this.txtEmergencyContact.Text=model.EmergencyContact;
		this.txtECTEL.Text=model.ECTEL;
		this.txtBloodType.Text=model.BloodType;
		this.txtHeight.Text=model.Height;
		this.txtUID.Text=model.UID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtBailorID.Text))
			{
				strErr+="外键-用户表UID格式错误！\\n";	
			}
			if(this.txtRelationship.Text.Trim().Length==0)
			{
				strErr+="关系不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtCheckInTime.Text))
			{
				strErr+="入住时间格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtOutTime.Text))
			{
				strErr+="出院时间格式错误！\\n";	
			}
			if(this.txtEmergencyContact.Text.Trim().Length==0)
			{
				strErr+="紧急联系人不能为空！\\n";	
			}
			if(this.txtECTEL.Text.Trim().Length==0)
			{
				strErr+="紧急联系电话不能为空！\\n";	
			}
			if(this.txtBloodType.Text.Trim().Length==0)
			{
				strErr+="血型不能为空！\\n";	
			}
			if(this.txtHeight.Text.Trim().Length==0)
			{
				strErr+="身高不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtUID.Text))
			{
				strErr+="外键-用户表格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int PID=int.Parse(this.lblPID.Text);
			int BailorID=int.Parse(this.txtBailorID.Text);
			string Relationship=this.txtRelationship.Text;
			DateTime CheckInTime=DateTime.Parse(this.txtCheckInTime.Text);
			DateTime OutTime=DateTime.Parse(this.txtOutTime.Text);
			string EmergencyContact=this.txtEmergencyContact.Text;
			string ECTEL=this.txtECTEL.Text;
			string BloodType=this.txtBloodType.Text;
			string Height=this.txtHeight.Text;
			int UID=int.Parse(this.txtUID.Text);


			YCF_Server.Model.Patient model=new YCF_Server.Model.Patient();
			model.PID=PID;
			model.BailorID=BailorID;
			model.Relationship=Relationship;
			model.CheckInTime=CheckInTime;
			model.OutTime=OutTime;
			model.EmergencyContact=EmergencyContact;
			model.ECTEL=ECTEL;
			model.BloodType=BloodType;
			model.Height=Height;
			model.UID=UID;

			YCF_Server.BLL.Patient bll=new YCF_Server.BLL.Patient();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
