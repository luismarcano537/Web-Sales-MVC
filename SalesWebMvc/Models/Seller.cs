using System;
using SalesWebMvc.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Error: {0} Size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Birth Day")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [EmailAddress(ErrorMessage ="Enter a valid email address")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        public Department Department { get; set; }
        public int DepartmentID { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord Sr)
        {
            Sales.Add(Sr);
        }

        public void RemoveSales(SalesRecord Sr)
        {
            Sales.Remove(Sr);
        }

        public double TotalSales(DateTime Initial, DateTime Final)
        {
            return Sales.Where(Sr => Sr.Date >= Initial && Sr.Date <= Final).Sum(Sr => Sr.Amount);
        }
    }
}
