﻿using System;
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
namespace YCF_Server.Web.Department
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtEdepartmentName.Text.Trim().Length==0)
			{
				strErr+="部门名称不能为空！\\n";	
			}
			if(this.txtDNumber.Text.Trim().Length==0)
			{
				strErr+="部门编号不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string EdepartmentName=this.txtEdepartmentName.Text;
			string DNumber=this.txtDNumber.Text;

			YCF_Server.Model.Department model=new YCF_Server.Model.Department();
			model.EdepartmentName=EdepartmentName;
			model.DNumber=DNumber;

			YCF_Server.BLL.Department bll=new YCF_Server.BLL.Department();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}