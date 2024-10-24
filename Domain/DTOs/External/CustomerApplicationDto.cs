using Domain.Entity.Core;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.External
{
    public class CustomerApplicationDto
    {
        public CustomerDto Customer { get; set; }
        public ApplicationDto Application { get; set; }
    }
}
