using DSS_UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSS_UI.DA
{
    public class DatabaseProviders
    {
        private string conString = "Data Source=DESKTOP-O51905Q\\SQLEXPRESS;Initial Catalog=dss;Integrated Security=True";

        public void add(Person person)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Table_Teacher", con);
                da.Fill(dt);
                DataRow r = dt.NewRow();

                r[0] = DBNull.Value;
                r[1] = person.name;
                r[2] = person.sexual;
                r[3] = person.dateofbirth;
                r[4] = person.homtown;
                r[5] = person.position;
                r[6] = person.image;
                r[7] = person.description;

                dt.Rows.Add(r);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                MessageBox.Show("Lưu lại thành công");
            }
        }
        public List<Person> getAllPersion()
        {
            List<Person> personList = new List<Person>();
            try
            {


                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("select * from Table_Teacher", con);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    

                    while (reader.Read())
                    {
                        int id = (int)reader[0];
                        string name = (string)reader[1];
                        string sexual = (string)reader[2];
                        string dateofbirth = ((DateTime)reader[3]).ToString("d");
                        string homtown = (string)reader[4];
                        string position = (string)reader[5];
                        byte[] image = (byte[])reader[6];
                        string description = (string)reader[7];

                        Person p = new Person(id,name, sexual, dateofbirth, homtown, position, image, description);
                        personList.Add(p);

                    }

                    con.Close();

                }
            }
            catch
            {

            }

            return personList;

        }

    }
}
