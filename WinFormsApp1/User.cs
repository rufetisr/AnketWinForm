using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNum { get; set; }
        public DateTime birthday { get; set; }
        public string Gender { get; set; }

        public override string ToString() => $"{Name}\n{Surname}\n{FatherName}\n{City}\n{Country}\n{PhoneNum}\n{birthday}\n{Gender}\n";
    }
}
