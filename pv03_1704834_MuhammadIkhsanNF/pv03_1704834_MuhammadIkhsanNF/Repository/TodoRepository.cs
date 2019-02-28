using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using pv03_1704834_MuhammadIkhsanNF.Model;

namespace pv03_1704834_MuhammadIkhsanNF.Repository
{
    class TodoRepository
    {
        string cs = @"server=localhost;userid=root;database=provis_masterdetail;SslMode=none";

        MySqlConnection conn;
        MySqlDataReader rdr;

        public TodoRepository()
        {
            conn = null;
            rdr = null;
        }

        public List<Todo> getByNim(string nim)
        {
            List<Todo> listTodo = new List<Todo>();

            conn = new MySqlConnection(cs);
            conn.Open();

            string stm = "SELECT * FROM todo where nimMhs = '" + nim + "';";
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Todo temp = new Todo();
                temp.Id = rdr.GetInt32(0);
                temp.NimMhs = rdr.GetString(1);
                temp.Nama = rdr.GetString(2);
                temp.Kategori = rdr.GetString(3);

                listTodo.Add(temp);
            }

            conn.Close();
            return listTodo;
        }

        public void addTodo(Todo todo)
        {
            string cs = @"server=localhost;userid=root;database=provis_masterdetail;SslMode=none";

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO todo(nimMhs, Nama, Kategori) VALUES(@Nim, @Nama, @Kategori)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Nim", todo.NimMhs);
                cmd.Parameters.AddWithValue("@Nama", todo.Nama);
                cmd.Parameters.AddWithValue("@Kategori", todo.Kategori);
                cmd.ExecuteNonQuery();
            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void delTodo(Todo todo)
        {
            string cs = @"server=localhost;userid=root;database=provis_masterdetail;SslMode=none";

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE from todo where Id =@Id";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", todo.Id);
                cmd.ExecuteNonQuery();
            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void updateTodo(Todo todo)
        {
            string cs = @"server=localhost;userid=root;database=provis_masterdetail;SslMode=none";

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE todo SET Nama=@Nama, Kategori = @Kategori where Id = @Id";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", todo.Id);
                cmd.Parameters.AddWithValue("@Nama", todo.Nama);
                cmd.Parameters.AddWithValue("@Kategori", todo.Kategori);
                cmd.ExecuteNonQuery();
            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public int cekNim(string nim)
        {
            conn = new MySqlConnection(cs);
            conn.Open();
            int status = 0;

            string check = "SELECT Id from mahasiswas where Nim ='" + nim + "';";
            MySqlCommand cmd = new MySqlCommand(check, conn);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                status = 1;
            }

            conn.Close();
            return status;
        }
    }
}
