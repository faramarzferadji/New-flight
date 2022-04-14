<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FlightBySql_ASP.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asp.Net & MySql Flight Form</title>
        <style type="text/css">
.auto-style1 {
text-align: center;
color: saddlebrown;
}
.auto-style2 {
width: 417px;
}
.auto-style6 {
width: 273px;

}
.auto-style7 {
height: 55px;
width: 273px;
}
.auto-style9 {
width: 1000px;
height: 581px;
}
.auto-style10 {
width: 97px;
}
.auto-style11 {
width: 500px;
}
.auto-style12 {
height: 116px;
}
.stylePanel {
border-radius:50px;
}
.tecboc {
border-radius:10px;
}
        #TextArea1 {
            width: 448px;
            height: 71px;
        }
        .auto-style16 {
            width: 97px;
            height: 29px;
        }
        .auto-style17 {
            width: 273px;
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style9">
          <div><h1 class="auto-style2"> Flight Application by MySql & ASP.NET </h1></div>
        <hr class="auto-style2" />
        <hr class="auto-style2" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <table class="auto-style11">
            <%--<tr "vertical-align:top">--%>
                <td class="auto-style12">
                    <asp:Panel ID="Panelinfo" runat="server" CssClass="stylePanel" BackColor="#CC9900"
                        GroupingText="flight info" Height="100%" Width="45%">
                        <table class="auto-style12">
                            <tr>
                                <td class="auto-style16">
                                    <asp:Label ID="Labelname" runat="server" Text="Full name" AccessKey="c" 
                                        AssociatedControlID="txtName"> </asp:Label>
                                  
                                </td>
                                <td class="auto-style17">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="tecboc" Width="200px"
                                        ></asp:TextBox>
                                       
                                </td>

                            </tr>
                            <tr>
                                <td class="auto-style10">
                                    <asp:Label ID="Labelgender" runat="server" Text="Gender"></asp:Label>
                                </td>
                                <td class="auto-style7">
                                    <asp:RadioButtonList ID="radlistgender" runat="server" AutoPostBack="true"></asp:RadioButtonList>
                                       
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10">
                                    <asp:Label ID="Labelfrom" runat="server" Text="From City"></asp:Label>
                                </td>
                                <td class="auto-style10">
                                    <asp:DropDownList ID="cbocity" runat="server" CssClass="tecboc" AutoPostBack="true"
                                         Width="200px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10">
                                    <asp:Label ID="Labeldist" runat="server" Text="Distanation"></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <asp:ListBox ID="listdist" runat="server" AutoPostBack="true" Width="105px" ></asp:ListBox>
                                      
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Labeldatetime" runat="server" Text="Which day and when?"
                                        CssClass="tecboc" Width="200px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdattime" runat="server" TextMode="DateTimeLocal" ></asp:TextBox>

                                </td>
                            </tr>
                            
                              <tr>
                                <td class="auto-style10">
                                    <asp:Label ID="Labeltrip" runat="server" Text="Trip"></asp:Label>
                                </td>
                                <td class="auto-style7">
                                    <asp:RadioButtonList ID="radlisttrip" runat="server" AutoPostBack="true" OnSelectedIndexChanged="radlisttrip_SelectedIndexChanged"></asp:RadioButtonList>
                                    
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Which day return and when?"
                                        CssClass="tecboc" Width="200px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxreturn" runat="server" TextMode="DateTimeLocal" ></asp:TextBox>

                                </td>
                            </tr>
                              <tr>
                                <td class="auto-style10">
                                    <asp:Label ID="Labelclass" runat="server" Text="Class Flight"></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <asp:ListBox ID="ListBoxfclass" runat="server" AutoPostBack="true" Width="105px" ></asp:ListBox>
                                        
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10">
                                    <asp:Label ID="Labelservice" runat="server" Text="Service Extra"></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <asp:CheckBoxList ID="chkboxlisservice" runat="server" AutoPostBack="true"
                                         Width="105px"></asp:CheckBoxList>
                                </td>
                            </tr>
                          
                           
                           
                        </table>
                    </asp:Panel>

                </td>
            
                 <td >
                    
                     <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1" Height="100%" Width="500px">

                        
                            <asp:Button ID="ButtonSave" runat="server" Text="save" OnClick="ButtonSave_Click" />
                            <asp:Button ID="Delrte" runat="server" Text="Delete" OnClick="Delrte_Click" />
                            <asp:Button ID="Clear" runat="server" Text="Clear" OnClick="Clear_Click" />
                            <asp:Button ID="Insert" runat="server" Text="Insert" OnClick="Insert_Click" />
                             <asp:Button ID="Buttonsearch" runat="server" Text="Search" OnClick="Buttonsearch_Click" />
                         

                     

                           

                     </asp:Panel>
                         <asp:GridView ID="GridView1" runat="server" ShowFooter ="True" FooterStyle-BackColor="Pink" AutoGenerateColumns="false" onRowDataBound="GridView1_RowDataBound" >
                             <Columns>
                                 <asp:BoundField DataField="name" HeaderText="Name" />
                                 <asp:BoundField DataField="fromcity" HeaderText="Depart" />
                                 <asp:BoundField DataField="tocity" HeaderText="Destinatio" />
                                 <asp:BoundField DataField="datego" HeaderText="Departtime" />
                                 <asp:BoundField DataField="datereturn" HeaderText="ReturnTime" />
                                 <asp:BoundField DataField="price" HeaderText="Price" />

                             </Columns>
                         
                         </asp:GridView>
                        
                      
                     
                </td>

             
                 
           

        </table>

    </form>
</body>
</html>
