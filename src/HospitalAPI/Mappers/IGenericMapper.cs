using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public interface IGenericMapper<Model, DTO>
    {
        Model ToModel(DTO dto);
        List<Model> ToModel(List<DTO> dto);
        DTO ToDTO(Model model);
        List<DTO> ToDTO(List<Model> model);
    }
}
