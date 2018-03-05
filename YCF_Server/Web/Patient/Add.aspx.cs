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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
