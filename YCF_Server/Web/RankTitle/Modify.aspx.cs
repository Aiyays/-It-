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
namespace YCF_Server.Web.RankTitle
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int RTID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(RTID);
				}
			}
		}
			
	private void ShowInfo(int RTID)
	{
		YCF_Server.BLL.RankTitle bll=new YCF_Server.BLL.RankTitle();
		YCF_Server.Model.RankTitle model=bll.GetModel(RTID);
		this.lblRTID.Text=model.RTID.ToString();
		this.txtNub.Text=model.Nub.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtNub.Text))
			{
				strErr+="职称的等级格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int RTID=int.Parse(this.lblRTID.Text);
			int Nub=int.Parse(this.txtNub.Text);


			YCF_Server.Model.RankTitle model=new YCF_Server.Model.RankTitle();
			model.RTID=RTID;
			model.Nub=Nub;

			YCF_Server.BLL.RankTitle bll=new YCF_Server.BLL.RankTitle();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
