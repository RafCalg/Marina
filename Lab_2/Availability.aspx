<%@ Page Language="C#"MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Availability.aspx.cs" Inherits="Lab_2.Availability" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 



        <div>
            <div class="row">
                <div class="col-xs-12 table-responsive">
                   <h1>Dock Information</h1>
                        <asp:DropDownList ID="dockDropDownList" runat="server" AutoPostBack="True" DataSourceID="dockObjectDataSource1" DataTextField="Name" DataValueField="ID" Font-Bold="True" Font-Size="Larger">
                        </asp:DropDownList>
                        <br />
                        <br />
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-condensed table-hover" DataSourceID="selectDockObjectDataSource1" ForeColor="#333333" GridLines="None"  Width="544px" HorizontalAlign ="Center">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="WaterService" HeaderText="Water Service" SortExpression="WaterService" />
                            <asp:BoundField DataField="ElectricalService" HeaderText="Electrical Service" SortExpression="ElectricalService" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="selectDockObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSelectedDocks" TypeName="Lab_2.Code.DockDB">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="dockDropDownList" Name="ID" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    </div>
                </div>
        
            <asp:ObjectDataSource ID="dockObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocks" TypeName="Lab_2.Code.DockDB"></asp:ObjectDataSource>

            <div class="row" >
                <div class="col-xs-12 table-responsive">
                   <h1>Slip Information</h1>
                    <asp:GridView  ID="selectedDockSlips" runat="server" AutoGenerateColumns="False" DataSourceID="slipObjectDataSource1"  AllowPaging="True" CssClass="table table-condensed table-hover"  Width="550px" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign ="Center">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                        <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
                        <asp:BoundField DataField="DockID" HeaderText="Dock ID" SortExpression="DockID" />
                    </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    </div>
                </div>
            <asp:ObjectDataSource ID="slipObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSlipsByDocks" TypeName="Lab_2.Code.SlipDB">
                <SelectParameters>
                    <asp:ControlParameter ControlID="dockDropDownList" Name="dockID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            
            
            <asp:Button ID="goToLoginButton" runat="server" OnClick="goToLoginButton_Click" Text="Login Page" />
            
            
        </div>


    </asp:Content>
