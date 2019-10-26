<%@ Page Language="C#"MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="LeasedSlips.aspx.cs" Inherits="Lab_2.LeasedSlips" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 



        <div>
            <h1>Select a Dock</h1>
            <br />

            <asp:DropDownList ID="dockDropDownList" runat="server" AutoPostBack="True" DataSourceID="dockTableObjectDataSource" DataTextField="Name" DataValueField="ID" Font-Bold="True" Font-Size="Larger" OnSelectedIndexChanged="dockDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:ObjectDataSource ID="dockTableObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocks" TypeName="Lab_2.Code.DockDB"></asp:ObjectDataSource>
            <br />
            <asp:GridView  ID="gvSelectedDockSlips" runat="server" AutoGenerateColumns="False" DataSourceID="slipTableObjectDataSource" OnSelectedIndexChanged="gvSelectedDockSlips_SelectedIndexChanged" AllowPaging="True" CssClass="table table-condensed table-hover"  Width="550px" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign ="Center">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                    <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                    <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
                    <asp:BoundField DataField="DockID" HeaderText="Dock ID" SortExpression="DockID" />
                    <asp:CommandField ShowSelectButton="True" />
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
            <asp:ObjectDataSource ID="slipTableObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSlipsByDocks" TypeName="Lab_2.Code.SlipDB">
                <SelectParameters>
                    <asp:ControlParameter ControlID="dockDropDownList" Name="dockID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:Button ID="selectSlipButton" runat="server" Text="LEase" OnClick="selectSlipButton_Click" style="margin-left: 0px" Height="47px" Width="203px" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="leaseTableObjectDataSource" CssClass="table table-bordered table-condensed table-hover" Width="316px" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign ="Center" AllowPaging="True">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Lease Number" SortExpression="ID" />
                    <asp:BoundField DataField="SlipID" HeaderText="Slip Number" SortExpression="SlipID" />
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
            <asp:ObjectDataSource ID="leaseTableObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerLeases" TypeName="Lab_2.Code.LeaseDB"></asp:ObjectDataSource>
            <br />
            <br />
            <br />
        </div>


    </asp:Content>
