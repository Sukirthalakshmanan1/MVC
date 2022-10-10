using BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DAL2
    {
        public bool Insert(subjects school)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdInsert = new SqlCommand("insert into subjects(subjects_id,subjects_name) values(@subjects_id,@subjects_name)", cn);
            cmdInsert.Parameters.AddWithValue("@subjects_id", school.subjects_id);
            cmdInsert.Parameters.AddWithValue("@subjects_name", school.subjects_name);
            
            /*SqlCommand cmdInserts = new SqlCommand("insert into member(member_id,member_name) values(@member_id,@member_name)", cn);
            cmdInserts.Parameters.AddWithValue("@member_id", employee.memberid);
            cmdInserts.Parameters.AddWithValue("@member_name", employee.membername); */


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
        public bool Update(subjects school)
        {

            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdUpdate = new SqlCommand("[dbo].[Updatesubjects]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@p_subid", school.subjects_id);
            cmdUpdate.Parameters.AddWithValue("@p_subname", school.subjects_name);
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
          public subjects Find(int id)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdSelect = new SqlCommand("[dbo].sp_Findsubject", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_subid", id);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_name";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 50;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);


            




            cn.Open();
            cmdSelect.ExecuteNonQuery();

           subjects found = new subjects();

            found.subjects_name = p1.Value.ToString();
           // found.student_class = Convert.ToInt32(p2.Value);





            cn.Close();
            cn.Dispose();


            return found;



        }
        public List<subjects> List()
        {
            //  SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);

            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdlist = new SqlCommand("select subjects_id,subjects_name from subjects", cn);

            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<subjects> emplist = new List<subjects>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    subjects bal = new subjects();
                    bal.subjects_id = Convert.ToInt32(dr["subjects_id"]);
                    bal.subjects_name = dr["subjects_name"].ToString();
                    

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

            SqlCommand cmdDelete = new SqlCommand("[dbo].sp_Deletesubjects", cn);
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
