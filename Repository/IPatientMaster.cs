using Task_ITDose.Models;

namespace Task_ITDose.Repository
{
    public interface IPatientMaster
    {
        Task<List<PatientMaster>> GetAllPatient();
        Task<PatientMaster>GetByIdPatient(int id);
        Task InsertPatient(PatientMaster patientMaster);
        Task UpdatetPatient(PatientMaster patientMaster);
        Task DeletePatient(int id );
    }
}
