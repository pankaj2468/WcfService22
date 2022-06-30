using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;

namespace WcfService22
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        string connection = ConfigurationManager.ConnectionStrings["xyz"].ConnectionString;
        public string InsertUserDetails(UserDetails userInfo)
        {
          string Message;
            try { 
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                //SqlCommand cmd = new SqlCommand("insert into customer(Name,Email) values(@Name,@Email)", con);
                SqlCommand cmd = new SqlCommand("custominsert",  con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userInfo.userID);
                cmd.Parameters.AddWithValue("@Name", userInfo.name);
                cmd.Parameters.AddWithValue("@Email", userInfo.email);
                

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Message = userInfo.name + " Details inserted successfully";
                }


                else
                {
                    Message = userInfo.name + " Details not inserted successfully";
                }

                con.Close();
            }
            catch (FaultException fex)
            {
                throw fex;
            }
            //Message = userInfo.name + "This user is already exist";
            return Message;
          
            

        }

        public bool DeleteUserDetails(UserDetails userInfo)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                //SqlCommand cmd = new SqlCommand("delete from customer where UserID=@UserID", con);
                SqlCommand cmd = new SqlCommand("customdelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userInfo.userID);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(FaultException fex)
            {
                throw fex;
            }
            return true;
        }

        public DataSet UpdateUserDetails(UserDetails userInfo)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("customupdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userInfo.userID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmd.ExecuteNonQuery();
                con.Close();
                return ds;
            }
            catch (FaultException fex)
            {
                throw fex;
            }
        }

        public void UpdateCustomerTable(UserDetails userInfo)
        {

            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                //SqlCommand cmd = new SqlCommand("update customer set Name=@Name, Email=@Email where UserID=@UserID", con);
                SqlCommand cmd = new SqlCommand("customupdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userInfo.userID);
                cmd.Parameters.AddWithValue("@Name", userInfo.name);
                cmd.Parameters.AddWithValue("@Email", userInfo.email);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(FaultException fex)
            {
                throw fex;
            }
        }
    }
}
