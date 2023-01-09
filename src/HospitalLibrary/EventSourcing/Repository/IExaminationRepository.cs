using HospitalLibrary.EventSourcing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Repository
{
    public interface IExaminationRepository
    {
        Examination FindBy(int id);

        void Add(Examination examination);

        void Save(Examination examination);
        IEnumerable<Object> GetStream(string streamName, int fromVersion, int toVersion);
    }
}
