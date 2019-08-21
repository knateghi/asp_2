using ASP_Core_EF.Models;
using ASP_Core_EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Core_EF.Repository
{
    public class GenderRepository : IGender
    {
        private DB_Context db;
        public GenderRepository(DB_Context _db)
        {
            db = _db;
        }
        //Commented by Reza: Getting all the Genders from the Database in the following line 
        public IEnumerable<Gender> GetGenders => db.Genders;
        public void Add(Gender _Gender)
        {
            db.Genders.Add(_Gender);
            db.SaveChanges();
        }

        public Gender GetGender(int? Id)
        {
            Gender dbEntity = db.Genders.Find(Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            Gender dbEntity = db.Genders.Find(Id);
            db.Genders.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
