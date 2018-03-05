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
namespace YCF_Server.Web.SLevel
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int LID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(LID);
				}
			}
		}
			
	private void ShowInfo(int LID)
	{
		YCF_Server.BLL.SLevel bll=new YCF_Server.BLL.SLevel();
		YCF_Server.Model.SLevel model=bll.GetModel(LID);
		this.lblLID.Text=model.LID.ToString();
		this.txtSLevel.Text=model.SLevel;
		this.txtLTID.Text=model.LTID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtSLevel.Text.Trim().Length==0)
			{
				strErr+="服务级别不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtLTID.Text))
			{
				strErr+="外键-级别类型格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int LID=int.Parse(this.lblLID.Text);
			string SLevel=this.txtSLevel.Text;
			int LTID=int.Parse(this.txtLTID.Text);


			YCF_Server.Model.SLevel model=new YCF_Server.Model.SLevel();
			model.LID=LID;
			model.SLevel=SLevel;
			model.LTID=LTID;

			YCF_Server.BLL.SLevel bll=new YCF_Server.BLL.SLevel();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
