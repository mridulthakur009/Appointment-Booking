using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace WebApplication1.slot_booking
{
    public partial class SlotBooking : System.Web.UI.Page
    {
        private SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn = new SqlConnection(CS);
            conn.Open();
            if(!IsPostBack)
            {
                AppointmentDurationDropDown();
                AppointmentTimeDropDown();
            }
        }
        public void AppointmentDurationDropDown()
        {
            SqlCommand cmd = new SqlCommand("sp_getSlot", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            AppointmentDurationList.DataSource = reader;
            AppointmentDurationList.DataBind();
            reader.Close();
            
        }
        public void AppointmentTimeDropDown()
        {
            SqlCommand cmd = new SqlCommand("sp_getDuration", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            AppointmentTimeList.DataSource = reader;
            AppointmentTimeList.DataBind();
            reader.Close();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime dates = Calendar1.SelectedDate.Date;

            if (AppointmentDurationList.SelectedItem.Text == "1") // then same slot book should be hidden to user
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Appointment(AppointmentDate,SlotId,TimeId) VALUES(@ad,@sid,@tid)", conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ad", Calendar1.SelectedDate.Date);
                cmd.Parameters.AddWithValue("@sid", AppointmentDurationList.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@tid", AppointmentTimeList.SelectedItem.Text);


            }
            //if (Calendar1.SelectedDate.Date == DateTime.Today)
            //{
            //    SqlCommand cmd = new SqlCommand("InsertAppointment", conn);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("AppointmentDate", Calendar1.SelectedDate);
            //    cmd.Parameters.AddWithValue("DurationHours",AppointmentDurationList.SelectedItem.Text);
            //    cmd.Parameters.AddWithValue("AppointmentTime", AppointmentTimeList.SelectedItem.Text);
            //    int Isbooked;
            //    if (AppointmentTimeList.SelectedValue == AppointmentTimeList.SelectedValue)
            //    {
            //        Isbooked = 1;
            //    }
            //    else
            //    {
            //        Isbooked = 0;
            //    }
            //    cmd.Parameters.AddWithValue("IsBooked", Isbooked);
            //    cmd.ExecuteNonQuery();
            //    Remove();
            //}
        }

        //Prevent User from Selecting Previous Date
        protected void CalenderPreviousDate(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < System.DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = Color.LightGray;
            }
        }

        public void Remove()
        {
            //SqlCommand cmd = new SqlCommand("RemoveAppointment", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //int SelectedIndex = Convert.ToInt32(AppointmentTimeList.SelectedItem.Value);
            //int AppointmentDuration = Convert.ToInt32(AppointmentDurationList.SelectedItem.Value);
            //cmd.Parameters.AddWithValue("@SelectedIndex", SelectedIndex);
            //cmd.Parameters.AddWithValue("@AppointmentDuration", AppointmentDuration);
            //cmd.ExecuteNonQuery();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //AppointmentTimeList.DataBind();
        }
        //public void Remove()
        //{
        //    int selectedIndex = AppointmentTimeList.SelectedIndex;

        //    if (selectedIndex != -1)
        //    {
        //        AppointmentTimeList.Items.RemoveAt(selectedIndex);
        //        if (Convert.ToInt32(AppointmentDurationList.SelectedItem.Value) == 2 && selectedIndex < AppointmentTimeList.Items.Count)
        //        {
        //            AppointmentTimeList.Items.RemoveAt(selectedIndex);
        //        }
        //        AppointmentTimeList.DataBind();
        //    }
        //}
        //public void remove()
        //{
        //    if (Convert.ToInt32(AppointmentDurationList.SelectedItem.Value) == 2)
        //    {
        //        for (int i = Convert.ToInt32(AppointmentDurationList.SelectedItem.Value); i <= 3; i++)
        //        {
        //            AppointmentTimeList.Items.Remove(AppointmentTimeList.SelectedItem);
        //        }
        //        AppointmentTimeList.DataBind();
        //    }
        //    else
        //    {
        //        AppointmentTimeList.Items.Remove(AppointmentTimeList.SelectedItem);
        //        AppointmentTimeList.DataBind();
        //    }
        //}
        //public void remove()
        //{
        //    if(Convert.ToInt32(AppointmentDurationList.SelectedItem.Value)==2)
        //    {

        //        AppointmentTimeList.Items.Remove(AppointmentTimeList.SelectedItem);
        //        AppointmentTimeList.DataBind();
        //    }
        //    else
        //    {
        //        AppointmentTimeList.Items.Remove(AppointmentTimeList.SelectedItem);
        //        AppointmentTimeList.DataBind();
        //    }
        //}



    }
}