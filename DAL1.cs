using BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL1
    {
        public bool Insert(student school)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdInsert = new SqlCommand("insert into student(student_id,student_name,student_class) values(@student_id,@student_name,@student_class)", cn);
            cmdInsert.Parameters.AddWithValue("@student_id", school.student_id);
            cmdInsert.Parameters.AddWithValue("@student_name", school.student_name);
            cmdInsert.Parameters.AddWithValue("@student_class", school.student_class);

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
        public bool Update(student school)
        {

            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdUpdate = new SqlCommand("[dbo].[Updatestudent]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@p_stuid", school.student_id);
            cmdUpdate.Parameters.AddWithValue("@p_stuname", school.student_name);
            cmdUpdate.Parameters.AddWithValue("@p_stuclass", school.student_class);
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
        
        public student Find(int id)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdSelect = new SqlCommand("[dbo].sp_Findstudent", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_stuid", id);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_name";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 10;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);


            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@p_stuclass";
            p2.SqlDbType = System.Data.SqlDbType.Int;
            p2.Size = 20;
            p2.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p2);





            cn.Open();
            cmdSelect.ExecuteNonQuery();

            student found = new student();

            found.student_name = p1.Value.ToString();
            found.student_class = Convert.ToInt32(p2.Value);





            cn.Close();
            cn.Dispose();


            return found;



        }
        public List<student> List()
        {
            

            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdlist = new SqlCommand("select student_id,student_name,student_class from student", cn);

            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<student> emplist = new List<student>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    student bal = new student();
                    bal.student_id = Convert.ToInt32(dr["student_id"]);
                    bal.student_name = dr["student_name"].ToString();
                    bal.student_class = Convert.ToInt32(dr["student_class"]);

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

            SqlCommand cmdDelete = new SqlCommand("[dbo].sp_Deletestudent", cn);
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
