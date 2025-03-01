using Microsoft.EntityFrameworkCore;
using Doctor.Data;
using System.Runtime.CompilerServices;
using System.Numerics;
using Microsoft.IdentityModel.Tokens;

namespace Doctor.Infrastructure
{
    public class StaffService : IStaffService
    {
        private readonly DoctorContext _context;

        public StaffService(DoctorContext context)
        {
            _context = context;
        }

        public async Task<Staff?> Create(string firstName, string lastName, string phone, int experience, int primarySpecialityId, int? secondarySpecialityId = null)
        {
            try
            {
                var staff = new Staff();

                if (RegexValidator.IsValidPhone(phone))
                {
                    var duplicate = await _context.Staffs.Where(x => x.Phone == phone).FirstOrDefaultAsync();

                    if (duplicate == null)
                    {
                        staff.FirstName = firstName;
                        staff.LastName = lastName;
                        staff.Phone = phone;
                        staff.Experience = experience;
                        staff.PrimarySpecialityId = primarySpecialityId;
                        staff.SecondarySpecialityId = secondarySpecialityId;
                        staff.DateCreated = DateTime.Now;

                        await _context.Staffs.AddAsync(staff);
                        await _context.SaveChangesAsync();

                        return staff;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
