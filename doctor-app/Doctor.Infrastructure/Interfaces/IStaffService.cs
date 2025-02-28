namespace Doctor.Infrastructure
{
    public interface IStaffService
    {
        Task<bool> CreateInterest(string firstName, string lastName, string phone, string email);
    }
}
