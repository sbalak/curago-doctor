using Doctor.Data;
using Doctor.Infrastructure;

namespace Doctor.Infrastructure
{
    public interface IStaffService
    {
        Task<HttpModel> Create(string firstName, string lastName, string phone, int experience, string postCode, string registerInterest, int specialityId);
    }
}
