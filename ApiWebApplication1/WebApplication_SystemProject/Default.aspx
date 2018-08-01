<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication_SystemProject._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">     
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Тестирование</h3>
    <ol class="round">
        <li class="one">
            <asp:FormView ID="FormView1" runat="server" DataKeyNames="CustomerId" AllowPaging="True" DataSourceID="ObjectDataSource1" Caption="FormView" GridLines="Both" Width="380px">
                <EditItemTemplate>
                    CustomerId:
                    <asp:Label ID="CustomerIdLabel1" runat="server" Text='<%# Eval("CustomerId") %>' />
                    <br />
                    Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Country:
                    <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Country:
                    <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                    <br />
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </InsertItemTemplate>
                <ItemTemplate>
                    CustomerId:
                    <asp:Label ID="CustomerIdLabel" runat="server" Text='<%# Eval("CustomerId") %>' />
                    <br />
                    Name:
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Country:
                    <asp:Label ID="CountryLabel" runat="server" Text='<%# Bind("Country") %>' />
                    <br />
                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                    &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                    &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                </ItemTemplate>
            </asp:FormView>
           
        </li>
        <li class="two">
             <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" 
                 DataKeyNames="CustomerId" RowStyle-HorizontalAlign="Center" BackColor="#999999" BorderStyle="Solid" 
                 BorderWidth="1px" Caption="GridView" AllowPaging="True" Width="384px" ShowFooter="True" OnInit="GridView1_Init" OnLoad="GridView1_Load">
                <Columns>                    
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />                    
                    <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" InsertVisible="False" ReadOnly="True" SortExpression="CustomerId" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />                   
                </Columns>
            <RowStyle HorizontalAlign="Center"></RowStyle>
            </asp:GridView>           
             <asp:ObjectDataSource ID="ObjectDataSource2" TypeName="WcfServiceSystemProject" runat ="server"></asp:ObjectDataSource>
             </li>
       
        <li class="three">                                             
            <asp:FormView ID="FormViewService" runat="server" Caption="WebService" Width="391px" AllowPaging="True" DataKeyNames="CustomerId" OnItemDeleting="ItemDeleting" OnModeChanging="ModeChanging" OnItemInserting="ItemInserting" OnItemUpdating="ItemUpdating" 
                OnPageIndexChanged="FormViewService_PageIndexChanged" emptydatatext="Данных не найдено" GridLines="Both" OnPageIndexChanging="FormViewService_PageIndexChanging">
                <EditItemTemplate>
                    ID: &nbsp;
                    <asp:Label ID="IDLab" runat="server" Text='<%# Eval("CustomerId") %>' />
                    <br />
                    Name: &nbsp;
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Country: &nbsp;
                    <asp:TextBox ID="txtCountry" runat="server" Text='<%# Bind("Country") %>' />
                    <br /> 
                      <br>                     
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    Name:
                    <asp:TextBox ID="TextName" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Country:
                    <asp:TextBox ID="TextCountry" runat="server" Text='<%# Bind("Country") %>' />
                    <br />
                        <br>                    
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </InsertItemTemplate>
                <ItemTemplate>
                    ID: &nbsp;
                    <asp:Label ID="IDLab" runat="server" Text='<%# Eval("CustomerId") %>' />
                    <br />
                    Name: &nbsp;
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Country: &nbsp;
                    <asp:Label ID="CountryLabel" runat="server" Text='<%# Bind("Country") %>' />
                    <br />  
                    <br>                                      
                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                    &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                    &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                </ItemTemplate>
            </asp:FormView>                                  
        </li>
           
        <li class="four">                       
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OnDataBinding="Page_Load" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DataSet1TableAdapters.CustomersTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_CustomerId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                    <asp:Parameter Name="Original_CustomerId" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </li>     
    </ol>
</asp:Content>
