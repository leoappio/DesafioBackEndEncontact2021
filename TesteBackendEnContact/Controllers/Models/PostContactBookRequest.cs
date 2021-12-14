using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain.ContactBook;
using TesteBackendEnContact.Core.Interface.ContactBook;

namespace TesteBackendEnContact.Controllers.Models
{
    public class PostContactBookRequest
    {
        [StringLength(50)]
        public string Name { get; set; }

        public IContactBook ToContactBook() => new ContactBook(Name);
    }
}
