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
using System.Windows;

namespace WebApplication1.slot_booking
{
    public partial class SlotBooking : System.Web.UI.Page
    {
        private SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            con = new SqlConnection(CS);
            con.Open();
            if(!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now.Date;
                AppointmentDurationDropDown();                
            }
        }
        public void AppointmentDurationDropDown()
        {
          //SqlCommand cmd = new SqlCommand("SELECT* FROM TimeSlot", con); 
            SqlCommand cmd = new SqlCommand("sp_getSlot", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            AppointmentDurationList.DataSource = reader;
            AppointmentDurationList.DataTextField = "SlotDuration";
            AppointmentDurationList.DataValueField = "SlotId";
            AppointmentDurationList.DataBind();
            reader.Close();           
        }
        public void AppointmentTimeDropDown()
        {
            if(AppointmentDurationList.SelectedItem.Text == "1 hour")
            {
                SqlCommand cmd = new SqlCommand("sp_getDuration", con);
                //SqlCommand cmd = new SqlCommand("SELECT t.*FROM[Time] t left join Appointment a on t.TimeID = a.TimeID AND a.AppointmentDate = @ad WHERE a.AppointmentDate IS NULL", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ad", Calendar1.SelectedDate.Date);
                SqlDataReader reader = cmd.ExecuteReader();
                AppointmentTimeList.DataSource = reader;
                AppointmentTimeList.DataValueField = "TimeId";
                AppointmentTimeList.DataTextField = "Time";

                AppointmentTimeList.DataBind();
                reader.Close();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("sp_getDuration1", con);
                //SqlCommand cmd = new SqlCommand("SELECT t.*FROM[Time] t left join Appointment a on t.TimeID = a.TimeID AND a.AppointmentDate = @ad WHERE a.AppointmentDate IS NULL", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ad", Calendar1.SelectedDate.Date);
                SqlDataReader reader = cmd.ExecuteReader();
                AppointmentTimeList.DataSource = reader;
                AppointmentTimeList.DataValueField = "TimeId";
                AppointmentTimeList.DataTextField = "Time";

                AppointmentTimeList.DataBind();
                reader.Close();
            }
            
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            AppointmentTimeDropDown();
            AppointmentDurationDropDown();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dates = Calendar1.SelectedDate.Date;

                if (AppointmentDurationList.SelectedItem.Text == "1 hour") // then same booked slot should be hidden to user
                {
                    //SqlCommand cmd = new SqlCommand("INSERT INTO Appointment(AppointmentDate,SlotId,TimeId) VALUES(@ad,@sid,@tid)", con);
                    SqlCommand cmd = new SqlCommand("sp_OneHour", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ad", Calendar1.SelectedDate.Date);
                    cmd.Parameters.AddWithValue("@sid", AppointmentDurationList.SelectedValue);
                    cmd.Parameters.AddWithValue("@tid", AppointmentTimeList.SelectedValue);

                    cmd.ExecuteNonQuery();
                    AppointmentTimeDropDown();
                }
                else
                {
                    //SqlCommand cmd = new SqlCommand("'INSERT INTO Appointment(AppointmentDate,SlotId,TimeId) VALUES(@ad,@sid,@tid);'
                    //+'INSERT INTO Appointment(AppointmentDate, SlotId, TimeId) VALUES(@ad, @sid + 1, @tid + 1)'",con);
                    SqlCommand cmd = new SqlCommand("sp_TwoHour", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ad", Calendar1.SelectedDate.Date);
                    cmd.Parameters.AddWithValue("@sid", AppointmentDurationList.SelectedValue);
                    cmd.Parameters.AddWithValue("@tid", AppointmentTimeList.SelectedValue);

                    cmd.ExecuteNonQuery();
                    AppointmentTimeDropDown();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Book the Appointment");   
            }
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
        protected void AppointmentDurationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppointmentTimeDropDown();
        }

















        public void Remove()
        {
            //SqlCommand cmd = new SqlCommand("RemoveAppointment", con);
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