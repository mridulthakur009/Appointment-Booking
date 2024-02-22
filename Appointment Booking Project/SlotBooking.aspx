<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlotBooking.aspx.cs" Inherits="WebApplication1.slot_booking.SlotBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>Slot Booking</title>
</head>
<body>
    <center>
        <form id="form1" runat="server">
            <div>
                <asp:Label runat="server" Text="SLOT BOOKING"
                    Font-Bold="True" Font-Italic="True" Font-Names="Bahnschrift SemiBold Condensed"
                    Font-Size="Larger"></asp:Label>
                <br />
            </div>
            <div>
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" OnDayRender="CalenderPreviousDate" Font-Names="poppins"
                    Font-Size="15pt" ForeColor="Black" Height="260px" Width="478px" NextPrevFormat="FullMonth" TitleFormat="Month">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="15pt" ForeColor="#333333" Height="10pt" />
                    <DayStyle Width="14%" />
                    <NextPrevStyle Font-Size="12pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                    <TodayDayStyle BackColor="#CCCC99" />
                </asp:Calendar>
            </div>
            <br />
            <br />
            <div>
                <asp:Label ID="Label1" runat="server" Text="Appointment Duration"></asp:Label><br />
                <br />
                <asp:DropDownList ID="AppointmentDurationList" runat="server"
                    DataTextField="SlotDuration"
                    DataValueField="SlotId"
                    AppendDataBoundItems="true">
                    <asp:ListItem Selected="False">---- Select Duration ----</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Appointment Time"></asp:Label><br />
                <br />
                <asp:DropDownList ID="AppointmentTimeList" runat="server"
                    DataValueField="TimeId"
                    DataTextField="Time"
                    AppendDataBoundItems="true">
                    <asp:ListItem Selected="False">---- Select Slot ----</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Book Your Slot" OnClick="Button1_Click" CssClass="btn btn-success" />
                <br />
                <br />
            </div>
        </form>
    </center>
    <p>
&nbsp;</p>
</body>
</html>
