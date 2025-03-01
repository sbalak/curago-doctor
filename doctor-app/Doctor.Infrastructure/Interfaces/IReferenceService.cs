using Doctor.Data;

namespace Doctor.Infrastructure
{
    public interface IReferenceService
    {
        Task<List<SpecialityModel>> GetSpecialities();
        Task<List<SymptomModel>> GetSymptoms();
    }
}
