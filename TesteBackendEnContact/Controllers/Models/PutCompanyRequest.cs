﻿using System.ComponentModel.DataAnnotations;
using TesteBackendEnContact.Core.Domain.ContactBook.Company;
using TesteBackendEnContact.Core.Interface.ContactBook.Company;

namespace TesteBackendEnContact.Controllers.Models
{
    public class PutCompanyRequest
    {
        public int Id { get; set; }
        [Required]
        public int ContactBookId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICompany ToCompany() => new Company(Id, ContactBookId, Name);
    }
}
