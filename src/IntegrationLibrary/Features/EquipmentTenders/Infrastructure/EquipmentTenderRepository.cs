using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.Infrastructure.Abstract;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationLibrary.Features.EquipmentTenders.Infrastructure
{
    public class EquipmentTenderRepository : IEquipmentTenderRepository
    {
        private readonly IntegrationDbContext _context;
        public EquipmentTenderRepository(IntegrationDbContext context)
        {
            _context = context;
        }
        public void Create(EquipmentTender tender)
        {
            _context.EquipmentTenders.Add(tender);
            _context.SaveChanges();
        }

        public ICollection<EquipmentTender> GetAll()
        {
            return _context.EquipmentTenders.Include(e => e.TenderRequirements)
                                            .Include(e => e.TenderApplications)
                                            .ToList();
        }

        public EquipmentTender GetById(int id)
        {
            return _context.EquipmentTenders.Include(e => e.TenderRequirements)
                                            .Include(e => e.TenderApplications)
                                            .FirstOrDefault(e => e.Id == id);
        }
    }
}
