using ASP_Core_EF.Models;
using ASP_Core_EF.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Core_EF.Repository
{
    public class EnrollmentRepository : IEnrollment
    {
        private DB_Context db;
        public EnrollmentRepository(DB_Context _db)
        {
            db = _db;
        }
        //Commented by Reza: Getting all the Enrollments from the Database in the following line 
        public IEnumerable<Enrollment> GetEnrollments => db.Enrollments.Include(s=>s.Students).Include(c=>c.Courses);
        public void Add(Enrollment _Enrollment)
        {
            db.Enrollments.Add(_Enrollment);
            db.SaveChanges();
        }

        public Enrollment GetEnrollment(int? Id)
        {
            Enrollment dbEntity = db.Enrollments.Find(Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            Enrollment dbEntity = db.Enrollments.Find(Id);
            db.Enrollments.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}

