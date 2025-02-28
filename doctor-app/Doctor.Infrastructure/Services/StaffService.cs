using Microsoft.EntityFrameworkCore;
using Doctor.Data;
using System.Runtime.CompilerServices;

namespace Doctor.Infrastructure
{
    public class StaffService : IStaffService
    {
        private readonly DoctorContext _context;

        public StaffService(DoctorContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateInterest(string firstName, string lastName, string phone, string email)
        {
            try
            {
                if (RegexValidator.IsValidPhone(phone) && RegexValidator.IsValidEmail(email))
                {
                    StaffInterest staffInterest = new StaffInterest()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Phone = phone,
                        Email = email,
                        DateCreated = DateTime.Now
                    };

                    await _context.StaffInterests.AddAsync(staffInterest);
                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
