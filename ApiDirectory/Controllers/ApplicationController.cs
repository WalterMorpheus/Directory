using ApiDirectory.Controllers;
using Domain.DTOs.External;
using Service.Services.Core;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class ApplicationController : BaseGenericController<ApplicationDto>
{
    public ApplicationController(GenericService<ApplicationDto> service) : base(service) { }

}
