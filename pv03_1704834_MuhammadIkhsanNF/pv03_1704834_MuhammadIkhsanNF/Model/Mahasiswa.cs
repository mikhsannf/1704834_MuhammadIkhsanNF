using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pv03_1704834_MuhammadIkhsanNF.Model
{
    class Mahasiswa
    {
        public int MyProperty { get; set; }

        public Mahasiswa(int id, string nim, string nama)
        {
            id = id;
            nim = nim;
            nama = nama;
        }

        public Mahasiswa()
        {

        }

        public int Id { get; set; }
        public string Nim { get; set; }
        public string Nama { get; set; }
    }
}
