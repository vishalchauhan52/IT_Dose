using Microsoft.EntityFrameworkCore;
using Task_ITDose.Db_Connection;
using Task_ITDose.Models;

namespace Task_ITDose.Repository
{
    public class PatientMasterService : IPatientMaster
    {
        private readonly AppDbContext _appDbContext;
        public PatientMasterService(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task DeletePatient(int id)
        {
            try
            {
                var result = await _appDbContext.patientMaster.FirstOrDefaultAsync(x => x.ID == id);
                if (result == null)
                {
                    throw new Exception($"{id} Id Not Found");
                }
                _appDbContext.patientMaster.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PatientMaster>> GetAllPatient()
        {
            try
            {
                var result = await _appDbContext.patientMaster.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PatientMaster> GetByIdPatient(int id)
        {
            try
            {
                var result = await _appDbContext.patientMaster.FindAsync(id);
                if (result == null)
                {
                    throw new Exception($"{id}  Id Not Found!!!");
                }
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task InsertPatient(PatientMaster patientMaster)
        {
            try
            {
                await _appDbContext.patientMaster.AddAsync(patientMaster);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task UpdatetPatient(PatientMaster patientMaster)
        {
            try
            {
                var result = await _appDbContext.patientMaster.FirstOrDefaultAsync(x => x.ID == patientMaster.ID);
                if (result == null)
                {
                    throw new Exception($"{patientMaster.ID}  Not Found!!!");
                }

                result.Name = patientMaster.Name;
                result.UpdatedDate = DateTime.Now;
                result.CreatedDate = DateTime.Now;
                result.Age = patientMaster.Age;
                result.Gender = patientMaster.Gender;
                result.Status = patientMaster.Status;
                result.DOB = patientMaster.DOB;
                result.MobileNo = patientMaster.MobileNo;
                _appDbContext.patientMaster.Update(result);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
