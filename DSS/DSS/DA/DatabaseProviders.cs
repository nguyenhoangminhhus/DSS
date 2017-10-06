using DSS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSS.DA
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

    }
}
