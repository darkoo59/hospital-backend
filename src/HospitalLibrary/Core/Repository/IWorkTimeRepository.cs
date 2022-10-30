using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository
{
    public interface IWorkTimeRepository
    {
        IEnumerable<WorkTime> GetAll();
        WorkTime GetById(int id);
        void Create(WorkTime workTime);
        void Update(WorkTime workTime);
        void Delete(WorkTime workTime);
    }
}
