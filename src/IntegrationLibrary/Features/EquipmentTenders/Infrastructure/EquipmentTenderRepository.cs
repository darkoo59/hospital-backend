﻿using IntegrationLibrary.Features.BloodBank.Model;
﻿using IntegrationLibrary.Core.Utility;
using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.Infrastructure.Abstract;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                                            .FirstOrDefault(e => e.Id == id);
        }

        public EquipmentTender GetByIdAndUser(int id, int userId)
        {
            return _context.EquipmentTenders.Include(e => e.TenderRequirements)
                                            .Include(e => e.TenderApplications)
                                            .Where(t => t.TenderApplications.Where(e => e.UserId == userId).FirstOrDefault() == null)
                                            .FirstOrDefault(e => e.Id == id);
        }

        public EquipmentTender GetByIdWithOffers(int id)
        {
            return _context.EquipmentTenders.Include(e => e.TenderRequirements)
                                            .Include(e => e.TenderApplications)
                                            .FirstOrDefault(e => e.Id == id);
        }

        public void Update(EquipmentTender tender)
        {
            _context.Entry(tender).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public ICollection<TenderApplication> GetTenderApplicationsByUser(int userId)
        {
            return _context.TenderApplications.Where(a => a.UserId == userId)
                                              .Include(a => a.EquipmentTender)
                                              .Include(a => a.TenderOffers)
                                              .ThenInclude(o => o.TenderRequirement)
                                              .ToList();
        }

        public ICollection<EquipmentTender> GetAllByUser(int userId)
        {
            return _context.EquipmentTenders.Include(t => t.TenderApplications)
                                            .Include(e => e.TenderRequirements)
                                            .Where(t => t.TenderApplications.Where(e=>e.UserId==userId).FirstOrDefault() == null)
                                            .ToList();
        }

        public void DeleteApplicationByIdAndUser(int id, int userId)
        {
            TenderApplication ta = _context.TenderApplications.Include(e => e.TenderOffers)
                                                              .Include(e => e.EquipmentTender)
                                                              .Where(a => a.Id == id && a.UserId == userId && a.EquipmentTender.State != Enums.TenderState.CLOSED)
                                                              .FirstOrDefault();
            if(ta != null)
            {
                _context.TenderApplications.Remove(ta);
                _context.SaveChanges();
            }
        }

        public TenderApplication GetApplicationById(int id)
        {
            return _context.TenderApplications.Include(a => a.EquipmentTender)
                                              .Include(a => a.TenderOffers)
                                              .ThenInclude(a => a.TenderRequirement)
                                              .Include(a => a.User)
                                              .FirstOrDefault(e => e.Id == id);
        }

        public EquipmentTender GetTenderWithApplicationsById(int id)
        {
            return _context.EquipmentTenders.Include(a => a.TenderApplications).ThenInclude(a => a.User)
                                            .Include(a => a.TenderApplications).ThenInclude(a => a.TenderOffers)
                                            .ThenInclude(a => a.TenderRequirement).FirstOrDefault(e => e.Id == id);
        }

        public void Update(TenderApplication application)
        {
            _context.Entry(application).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public ICollection<TenderApplication> GetAllUsersByTenderEquipmentId(int id)
        {
            return _context.TenderApplications.Include(ta => ta.User)
                .Include(ta => ta.EquipmentTender)
                .Where(ta => ta.EquipmentTenderId == id)
                .ToList();
        }
        
        public ICollection<TenderApplication> GetFinishedApplications(DateRange dr)
        {
            return _context.TenderApplications.Include(e => e.TenderOffers).ThenInclude(e => e.TenderRequirement)
                                              .Include(e => e.User)
                                              .Include(e => e.EquipmentTender)
                                              .Where(ta => ta.HasWon && ta.Finished >= dr.StartDate && ta.Finished <= dr.EndDate)
                                              .ToList();
        }
    }
}
