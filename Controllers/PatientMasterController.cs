using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Task_ITDose.Models;
using Task_ITDose.Repository;

namespace Task_ITDose.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientMasterController : ControllerBase
    {
        private readonly IPatientMaster _patientMaster;
        public PatientMasterController(IPatientMaster patientMaster)
        {
            this._patientMaster = patientMaster;
        }

        [HttpGet ("GetAllRecord")]
        public async Task<IActionResult> GetAllRecord()
        {
            try
            {
                var result = await _patientMaster.GetAllPatient();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            };
        }

        [HttpPost ("CreatePatient")]

        public async Task<IActionResult>CreatePatient(PatientMaster patientMaster)
        {
            try
            {
                await _patientMaster.InsertPatient(patientMaster);
                return Ok($"{patientMaster.Name}  Created Successfully");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPut ("UpdatePatient")]
        public async Task<IActionResult>UpdatePatient(PatientMaster patientMaster)
        {
            try
            {
                await _patientMaster.UpdatetPatient(patientMaster);
                return Ok($"{patientMaster.ID}  Updated SuccessFully");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpDelete ("DeletePatient")]
        public async Task<IActionResult>DeletePatient(int id)
        {
            try
            {
                await _patientMaster.DeletePatient(id);
                return Ok($"{id} Deleted Successfully");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetByIdPatient")]
        public async Task<IActionResult> GetByIdPatient(int id)
        {
            try
            {
                var result = await _patientMaster.GetByIdPatient(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
