﻿using ASP_Core_EF.Models;
using ASP_Core_EF.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Core_EF.Repository
{
    public class StudentRepository : IStudent
    {
        private DB_Context db;
        public StudentRepository(DB_Context _db)
        {
            db = _db;
        }
        //Commented by Reza: Getting all the students from the Database in the following line 
        public IEnumerable<Student> GetStudents => db.Students.Include(global => global.Genders);
        public void Add(Student _Student)
        {
            db.Students.Add(_Student);
            db.SaveChanges();
        }

        public Student GetStudent(int? Id)
        {
            Student dbEntity = db.Students.Include(e => e.Enrollments)
                                            .ThenInclude(c => c.Courses)
                                            .Include(g => g.Genders)
                                            .SingleOrDefault(m => m.StudentId == Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            Student dbEntity = db.Students.Find(Id);
            db.Students.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
