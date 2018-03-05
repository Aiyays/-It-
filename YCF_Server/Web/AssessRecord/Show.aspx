<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="YCF_Server.Web.AssessRecord.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		主键ID 自增
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		姓名
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		性别
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSex" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		档案号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFN" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		生日
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBirthDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		病床号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTheBed" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		评估日期
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblValuationDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		评估员
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblEvaluator" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		登记员
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRegistrar" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		登记日期
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRecordData" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BADL指数
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBADL" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LADL指数
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLADL" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LSP指数
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLSP" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		系统评估
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSysEvaluation" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		综合评估（评估人员进行评估）
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAssessment" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户ID（被评估人员ID）-外
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		护理等级分配备注
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblComment" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




