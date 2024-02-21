<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlotBooking.aspx.cs" Inherits="WebApplication1.slot_booking.SlotBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Slot Booking</title>
</head>
<body>
    <center>
        <form id="form1" runat="server">
            <div>
                <asp:Label runat="server" Text="SLOT BOOKING SYSTEM"
                    Font-Bold="True" Font-Italic="True" Font-Names="Bahnschrift SemiBold Condensed"
                    Font-Size="Larger"></asp:Label>
                <br />
            </div>
            <div>
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" DayNameFormat="Shortest" OnDayRender="Calendar1_DayRender" Font-Names="Verdana"
                    Font-Size="8pt" ForeColor="#003399" Height="200px" Width="299px" BorderWidth="1px" CellPadding="1">
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" BorderColor="#3366CC" BorderWidth="1px" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
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
                    <asp:ListItem Selected="False">---- Select Appointment Duration ----</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Appointment Time"></asp:Label><br />
                <br />
                <asp:DropDownList ID="AppointmentTimeList" runat="server"
                    DataValueField="TimeId"
                    DataTextField="Time"
                    AppendDataBoundItems="true">
                    <asp:ListItem Selected="False">---- Select Appointment Time ----</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Book Your Slot" OnClick="Button1_Click" BackColor="#00CCFF" BorderColor="#FFCCCC" />
                <br />
                <br />
            </div>
        </form>
    </center>
    <p>
&nbsp;</p>
</body>
</html>
