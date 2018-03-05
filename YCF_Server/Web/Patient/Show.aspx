<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="YCF_Server.Web.Patient.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		PID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		外键-用户表UID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBailorID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		关系
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRelationship" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		入住时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCheckInTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		出院时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOutTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		紧急联系人
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblEmergencyContact" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		紧急联系电话
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblECTEL" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		血型
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBloodType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		身高
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHeight" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		外键-用户表
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUID" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




