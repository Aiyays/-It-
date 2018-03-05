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
namespace YCF_Server.Web.EmpSchedule
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ESID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ESID);
				}
			}
		}
			
	private void ShowInfo(int ESID)
	{
		YCF_Server.BLL.EmpSchedule bll=new YCF_Server.BLL.EmpSchedule();
		YCF_Server.Model.EmpSchedule model=bll.GetModel(ESID);
		this.lblESID.Text=model.ESID.ToString();
		this.txtEID.Text=model.EID.ToString();
		this.txtSID.Text=model.SID.ToString();
		this.txtDataTime.Text=model.DataTime;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtEID.Text))
			{
				strErr+="员工表格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtSID.Text))
			{
				strErr+="排班表格式错误！\\n";	
			}
			if(this.txtDataTime.Text.Trim().Length==0)
			{
				strErr+="排版时间不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ESID=int.Parse(this.lblESID.Text);
			int EID=int.Parse(this.txtEID.Text);
			int SID=int.Parse(this.txtSID.Text);
			string DataTime=this.txtDataTime.Text;


			YCF_Server.Model.EmpSchedule model=new YCF_Server.Model.EmpSchedule();
			model.ESID=ESID;
			model.EID=EID;
			model.SID=SID;
			model.DataTime=DataTime;

			YCF_Server.BLL.EmpSchedule bll=new YCF_Server.BLL.EmpSchedule();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
