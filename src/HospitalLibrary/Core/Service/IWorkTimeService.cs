using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IWorkTimeService
    {
        IEnumerable<WorkTime> GetAll();
        WorkTime GetById(int id);
        void Create(WorkTime workTime);
        void Update(WorkTime workTime);
        void Delete(WorkTime workTime);
    }
}
