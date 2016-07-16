<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ValidationDemo.aspx.cs" Inherits="AFDataValidation.ValidationDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 100%; border-style: inset; border-color: Blue; border-width: thin;">
       <span style="font-size: small">POI : Please check implementation details of Validation
            in class 'ValidationEntity.cs' and 'ValidationDemo.aspx.cs' </span>
    </div>
    <br />
    <br />
    <table>
        <tr>
            <td>
                <span>Name : </span>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <span>Address : </span>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <span>EMail : </span>
            </td>
            <td>
                <asp:TextBox ID="txtEMail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <span>Phone : </span>
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:GridView ID="Employee" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="Employee_PageIndexChanging"
        DataKeyNames="EmpID" OnRowDeleting="Employee_RowDeleting" OnRowCancelingEdit="Employee_RowCancelingEdit"
        OnRowEditing="Employee_RowEditing" OnRowUpdating="Employee_RowUpdating" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="EmpID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="EmpID" Text='<%#Eval("EmpID") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="lblName" Text='<%#Eval("Name") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address">
                <ItemTemplate>
                    <asp:Label ID="lblAddress" Text='<%#Eval("Address") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAddress" Text='<%#Eval("Address") %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EMail">
                <ItemTemplate>
                    <asp:Label ID="lblEMail" Text='<%#Eval("EMail") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEMail" Text='<%#Eval("EMail") %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phone">
                <ItemTemplate>
                    <asp:Label ID="lblPhone" Text='<%#Eval("Phone") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPhone" Text='<%#Eval("Phone") %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEdit" runat="server" CommandName="Edit" ImageUrl="~/Images/edit22x22.png"
                        AlternateText="Edit" CommandArgument='<%#Eval("EmpID") %>'
                        Height="16px" Width="16px" />
                    <asp:ImageButton ID="AFImageButton1" runat="server" CommandName="Delete"
                        ImageUrl="~/Images/delete.png" AlternateText="Delete" CommandArgument='<%#Eval("EmpID") %>'
                        Height="16px" Width="16px" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update" ImageUrl="~/Images/Update.png"
                        AlternateText="Update" Style="margin-left: 22px;" CommandArgument='<%#Eval("EmpID") %>'
                        Height="16px" Width="16px" />
                    <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/delete.png"
                        AlternateText="Cancel" Style="margin-left: 22px;" CommandArgument='<%#Eval("EmpID") %>'
                        Height="16px" Width="16px" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
