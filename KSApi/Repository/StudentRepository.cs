using KSApi.Data;
using KSApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyContext myContext;
        public StudentRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //GetAll
        public async Task<IEnumerable<Student>> GetAll()
        {
            return await myContext.Students.ToListAsync();
        }

        //Get
        public async Task<Student> Get(int id)
        {
            return await myContext.Students.FindAsync(id);
        }

        //Add
        public async Task<Student> Add(Student student)
        {
            await myContext.Students.AddAsync(student);
            await myContext.SaveChangesAsync();
            return student;
        }


        //Update
        public async Task<Student> Update(Student newstudent)
        {
            myContext.Entry(newstudent).State = EntityState.Modified;
            await myContext.SaveChangesAsync();
            return newstudent;
        }

        //Delete
        public async Task<Student> Delete(int id)
        {
            var student = await myContext.Students.FindAsync(id);
            myContext.Students.Remove(student);
            await myContext.SaveChangesAsync();
            return student;
        }

    }
}






