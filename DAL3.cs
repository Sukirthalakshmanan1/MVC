using BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL3
    {
        public bool Insert(Class1 school)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdInsert = new SqlCommand("insert into Class1(Room_no,class_strength) values(@Room_no,@class_strength)", cn);
            cmdInsert.Parameters.AddWithValue("@Room_no", school.Room_no);
            cmdInsert.Parameters.AddWithValue("@class_strength", school.class_strength);

            

            cn.Open();
            int i = cmdInsert.ExecuteNonQuery();

            bool status = false;

            if (i == 1)
            {
                status = true;
            }

            cn.Close();//finally
            cn.Dispose();//finally
            return status;



        }
        public bool Update(Class1 school)
        {

            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdUpdate = new SqlCommand("[dbo].[UpdatesClass1]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@p_stuid", school.Room_no);
            cmdUpdate.Parameters.AddWithValue("@p_stuclass", school.class_strength);
            cn.Open();
            int s = cmdUpdate.ExecuteNonQuery();
            bool statusd = false;
            if (s == 1)
            {
                statusd = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return statusd;

        }
        public Class1 Find(int id)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdSelect = new SqlCommand("[dbo].sp_FindClass1", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_stuid", id);

           /* SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_name";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 50;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);*/

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@p_stuclass";
            p2.SqlDbType = System.Data.SqlDbType.Int;
            p2.Size = 20;
            p2.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p2);





            cn.Open();
            cmdSelect.ExecuteNonQuery();

            Class1 found = new Class1();

            //found. = p1.Value.ToString();
             found.class_strength = Convert.ToInt32(p2.Value);





            cn.Close();
            cn.Dispose();


            return found;



        }
        public List<Class1> List()
        {
            //  SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);

            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdlist = new SqlCommand("select Room_no,class_strength from Class1", cn);

            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<Class1> emplist = new List<Class1>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Class1 bal = new Class1();
                    bal.Room_no = Convert.ToInt32(dr["Room_no"]);
                    bal.class_strength = Convert.ToInt32(dr["class_strength"]);


                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
        public bool Delete(int stuid)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdDelete = new SqlCommand("[dbo].sp_Delete", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_id", stuid);
            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return status;

        }

    }
}
