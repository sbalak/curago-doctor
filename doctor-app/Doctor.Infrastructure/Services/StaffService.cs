using Microsoft.EntityFrameworkCore;
using Doctor.Data;
using System.Runtime.CompilerServices;
using System.Numerics;
using Microsoft.IdentityModel.Tokens;
using Doctor.Infrastructure;

namespace Doctor.Infrastructure
{
    public class StaffService : IStaffService
    {
        private readonly DoctorContext _context;

        public StaffService(DoctorContext context)
        {
            _context = context;
        }

        public async Task<HttpModel> Create(string firstName, string lastName, string phone, int experience, string postCode, string registerInterest, int specialityId)
        {
            try
            {
                var http = new HttpModel();


                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(registerInterest) || specialityId <= 0)
                {
                    http.status = "failure";
                    http.message = "All fields are mandatory. Please complete the form to continue";
                }
                else
                {
                    if (RegexValidator.IsValidPhone(phone) && RegexValidator.IsValidPostcode(postCode))
                    {
                        var duplicate = await _context.Staffs.Where(x => x.Phone == phone).FirstOrDefaultAsync();

                        if (duplicate == null)
                        {
                            var staff = new Staff();

                            staff.FirstName = firstName;
                            staff.LastName = lastName;
                            staff.Phone = phone;
                            staff.Experience = experience;
                            staff.Postcode = postCode;
                            staff.RegisterInterest = registerInterest;
                            staff.PrimarySpecialityId = specialityId;
                            staff.DateCreated = DateTime.Now;

                            await _context.Staffs.AddAsync(staff);
                            await _context.SaveChangesAsync();

                            http.status = "success";
                            http.message = "Hey there! Thanks for registering your interest, we'll get back to you soon.";
                        }
                        else
                        {
                            http.status = "success";
                            http.message = "You have already registered your interest. We will get back to you soon!";
                        }
                    }
                    else
                    {
                        http.status = "failure";
                        http.message = "Please make sure to enter phone number (9444XXXXXX) & postcode (5XX5XX) in correct format";
                    }
                }
                return http;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
