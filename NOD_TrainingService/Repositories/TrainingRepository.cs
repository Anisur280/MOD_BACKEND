using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD_TrainingService.Context;
using MOD_TrainingService.Models;

namespace MOD_TrainingService.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly TrainingContext _context;
        public TrainingRepository(TrainingContext context)
        {
            _context = context;
        }
        public List<Training> CompletedTraining(string MentorId)
        {
            var obj = _context.Trainings.Where(s => s.MentorId == MentorId && s.Status == "Complete").ToList();
            return obj;
        }

        public List<Training> CurrentTraining(string MentorId)
        {
            var obj = _context.Trainings.Where(s => s.MentorId == MentorId && s.Status == "Current").ToList();
            return obj;
        }
        public void Add(Training item)
        {
            _context.Trainings.Add(item);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var item = _context.Trainings.Find(id);
            _context.Trainings.Remove(item);
            _context.SaveChanges();
        }

        public IList<Training> GetAll()
        {
            return _context.Trainings.ToList();
        }

        public void Update(Training item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
