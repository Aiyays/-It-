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
namespace YCF_Server.Web.LevelType
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int LTID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(LTID);
				}
			}
		}
			
	private void ShowInfo(int LTID)
	{
		YCF_Server.BLL.LevelType bll=new YCF_Server.BLL.LevelType();
		YCF_Server.Model.LevelType model=bll.GetModel(LTID);
		this.lblLTID.Text=model.LTID.ToString();
		this.txtLID.Text=model.LID.ToString();
		this.txtSTID.Text=model.STID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtLID.Text))
			{
				strErr+="外键-级别格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtSTID.Text))
			{
				strErr+="外键-级别类型格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int LTID=int.Parse(this.lblLTID.Text);
			int LID=int.Parse(this.txtLID.Text);
			int STID=int.Parse(this.txtSTID.Text);


			YCF_Server.Model.LevelType model=new YCF_Server.Model.LevelType();
			model.LTID=LTID;
			model.LID=LID;
			model.STID=STID;

			YCF_Server.BLL.LevelType bll=new YCF_Server.BLL.LevelType();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
