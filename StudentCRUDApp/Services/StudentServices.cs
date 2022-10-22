using StudentCRUDApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCRUDApp.Services
{
    public class MockDataStore : IDataStore<Student>
    {
        readonly List<Student> student;

        public MockDataStore()
        {
            student = new List<Student>()
            {
                new Student { Id = Guid.NewGuid().ToString(), FirstName = "First item", LastName  = "First item", Gender = 0, DateofBirth = new DateTime(1995,08,01), Comment ="This is an item description." },
                new Student { Id = Guid.NewGuid().ToString(), FirstName = "First item", LastName  = "First item", Gender = 0, DateofBirth = new DateTime(1995,08,01), Comment ="This is an item description." },
                new Student { Id = Guid.NewGuid().ToString(), FirstName = "First item", LastName  = "First item", Gender = 0, DateofBirth = new DateTime(1995,08,01), Comment ="This is an item description." },
                new Student { Id = Guid.NewGuid().ToString(), FirstName = "First item", LastName  = "First item", Gender = 0, DateofBirth = new DateTime(1995,08,01), Comment ="This is an item description." },
                new Student { Id = Guid.NewGuid().ToString(), FirstName = "First item", LastName  = "First item", Gender = 0, DateofBirth = new DateTime(1995,08,01), Comment ="This is an item description." },
                new Student { Id = Guid.NewGuid().ToString(), FirstName = "First item", LastName  = "First item", Gender = 0, DateofBirth = new DateTime(1995,08,01), Comment ="This is an item description." },
                new Student { Id = Guid.NewGuid().ToString(), FirstName = "First item", LastName  = "First item", Gender = 0, DateofBirth = new DateTime(1995,08,01), Comment ="This is an item description." },
                new Student { Id = Guid.NewGuid().ToString(), FirstName = "First item", LastName  = "First item", Gender = 0, DateofBirth = new DateTime(1995,08,01), Comment ="This is an item description." },
                new Student { Id = Guid.NewGuid().ToString(), FirstName = "First item", LastName  = "First item", Gender = 0, DateofBirth = new DateTime(1995,08,01), Comment ="This is an item description." },
            };
        }

        public async Task<bool> AddStudentAsync(Student item)
        {
            student.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateStudentAsync(Student item)
        {
            var oldItem = student.Where((Student arg) => arg.Id == item.Id).FirstOrDefault();
            student.Remove(oldItem);
            student.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteStudentAsync(string id)
        {
            var oldItem = student.Where((Student arg) => arg.Id == id).FirstOrDefault();
            student.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Student> GetStudentAsync(string id)
        {
            return await Task.FromResult(student.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Student>> GetAllStudentAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(student);
        }
    }
}