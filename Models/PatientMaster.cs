using System.ComponentModel.DataAnnotations;

namespace Task_ITDose.Models
{
    public class PatientMaster
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage ="Please Enter my Mobile Number")]
        [StringLength(10,MinimumLength =10 , ErrorMessage =("Mobile Number must be 10 digits"))]
        [RegularExpression(@"^\d{10}$" , ErrorMessage ="Mobile number fill only Numeric Number")]
        public string MobileNo { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
