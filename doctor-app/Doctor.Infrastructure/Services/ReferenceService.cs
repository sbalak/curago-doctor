using Microsoft.EntityFrameworkCore;
using Doctor.Data;

namespace Doctor.Infrastructure
{
    public class ReferenceService : IReferenceService
    {
        private readonly DoctorContext _context;

        public ReferenceService(DoctorContext context)
        {
            _context = context;
        }

        public async Task<List<SpecialityModel>> GetSpecialities()
        {
            var specialities = await _context.Specialities
                                             .Select(m => new SpecialityModel
                                                {
                                                    Id = m.Id,
                                                    Name = m.Name,
                                                    CorrespondingRole = m.CorrespondingRole,
                                                    Image = m.Image,
                                                    Description = m.Description
                                                })
                                             .ToListAsync();
            return specialities;
        }

        public async Task<List<SymptomModel>> GetSymptoms()
        {
            var symptoms = await _context.Symptoms
                                         .Select(m => new SymptomModel
                                             {
                                                 Id = m.Id,
                                                 Name = m.Name,
                                                 Image = m.Image,
                                                 Description = m.Description
                                             })
                                         .ToListAsync();
            return symptoms;
        }
    }
}
