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
namespace YCF_Server.Web.PersonalEquipment
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int PEID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(PEID);
				}
			}
		}
			
	private void ShowInfo(int PEID)
	{
		YCF_Server.BLL.PersonalEquipment bll=new YCF_Server.BLL.PersonalEquipment();
		YCF_Server.Model.PersonalEquipment model=bll.GetModel(PEID);
		this.lblPEID.Text=model.PEID.ToString();
		this.txtEID.Text=model.EID.ToString();
		this.txtPID.Text=model.PID.ToString();
		this.txtEmpID.Text=model.EmpID.ToString();
		this.txtGID.Text=model.GID.ToString();
		this.txtPTime.Text=model.PTime.ToString();
		this.txtNumber.Text=model.Number.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtEID.Text))
			{
				strErr+="外键-设备格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="外键-病人格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtEmpID.Text))
			{
				strErr+="外键-员工格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtGID.Text))
			{
				strErr+="外键-组格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtPTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtNumber.Text))
			{
				strErr+="数量格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int PEID=int.Parse(this.lblPEID.Text);
			int EID=int.Parse(this.txtEID.Text);
			int PID=int.Parse(this.txtPID.Text);
			int EmpID=int.Parse(this.txtEmpID.Text);
			int GID=int.Parse(this.txtGID.Text);
			DateTime PTime=DateTime.Parse(this.txtPTime.Text);
			int Number=int.Parse(this.txtNumber.Text);


			YCF_Server.Model.PersonalEquipment model=new YCF_Server.Model.PersonalEquipment();
			model.PEID=PEID;
			model.EID=EID;
			model.PID=PID;
			model.EmpID=EmpID;
			model.GID=GID;
			model.PTime=PTime;
			model.Number=Number;

			YCF_Server.BLL.PersonalEquipment bll=new YCF_Server.BLL.PersonalEquipment();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
