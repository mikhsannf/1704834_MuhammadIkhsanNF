using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pv03_1704834_MuhammadIkhsanNF.Model;
using pv03_1704834_MuhammadIkhsanNF.Repository;

namespace pv03_1704834_MuhammadIkhsanNF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void submitNim_Click(object sender, EventArgs e)
        {
            TodoRepository todo = new TodoRepository();

            tbNim.Enabled = false;

            string nim = tbNim.Text;

            if (todo.cekNim(nim) == 1)
            {
                tbNim.Enabled = false;
                btnAdd.Enabled = true;
                submitNim.Enabled = false;

                dataGridView2.DataSource = todo.getByNim(nim);

            }
            else
            {
                MessageBox.Show("NIM tidak terdaftar");
                tbNim.Text = "";
                tbNim.Focus();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Todo temp = new Todo();

            temp.NimMhs = tbNim.Text;
            temp.Nama = tbNama.Text;
            temp.Kategori = tbKategori.Text;

            TodoRepository todo = new TodoRepository();

            todo.addTodo(temp);

            string nim = tbNim.Text;

            dataGridView2.DataSource = todo.getByNim(nim);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Todo temp = new Todo();
            temp.Id = Convert.ToInt32(txtIdDel.Text);

            TodoRepository todo = new TodoRepository();

            todo.delTodo(temp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Todo temp = new Todo();
            temp.Id = Convert.ToInt32(txtIdUpdate.Text);
            temp.Nama = txtNamaKegiatanUpdate.Text;
            temp.Kategori = txtKategoriKegiatanUpdate.Text;

            TodoRepository todo = new TodoRepository();

            todo.updateTodo(temp);

        }
    }
}
