using cwiczenia_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_8.Models
{
    public interface IDbService
    {
        public List<Doctor> GetDoctors();
        public bool AddDoctor(Doctor d);
        public bool ModifyDoctor(Doctor d);
        public bool DeleteDoctor(Doctor d);
    }
}
