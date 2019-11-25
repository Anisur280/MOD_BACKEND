using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD_UserService.Context;
using MOD_UserService.Models;

namespace MOD_UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public void Add(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var item = _context.Users.Find(id);
            _context.Users.Remove(item);
            _context.SaveChanges();
        }

        public void BlockUser(string id)
        {
            var item = _context.Users.Find(id);
            if (item.Active)
            {
                item.Active = !item.Active;

            }
            else
            {
                item.Active = !item.Active;
            }
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Update(User item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        public List<Mentor> SearchMentor(string PrimarySkills, string TimeSlot)
        {
            var obj = _context.Mentors.Where(s => s.PrimarySkills== PrimarySkills || s.TimeSlot == TimeSlot).ToList();
            return obj;
        }
        public void ResetPassword(string Email, string NewPass)
        {
            var obj = _context.Users.SingleOrDefault(i => i.Email==Email);
            obj.Password =NewPass;
            _context.SaveChanges();
        }
    }
}
