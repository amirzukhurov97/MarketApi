
using MarketApi.DTOs.Organization;
using MarketApi.DTOs.OrganizationRequest;
using MarketApi.Interfacies;
using MarketApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IRepository<Organization> _repository;
        public OrganizationController(IRepository<Organization> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var сustomerList = _repository.GetAll();
                if (сustomerList == null || !сustomerList.Any())
                {
                    return BadRequest("Don't have customers");
                }
                return Ok(сustomerList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var сustomerList = _repository.GetById(id);
                if (сustomerList == null)
                {
                    return BadRequest($"With id ={id} Don't have customers");
                }
                return Ok(сustomerList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Post(OrganizationRequest organization)
        {
            var organizationPost = new Organization
            {
                Name = organization.Name,
                AddressId = organization.AddressId,
                PhoneNumber = organization.PhoneNumber
            };
            _repository.Add(organizationPost);
            return Created("", organizationPost);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var deleteOrganization = _repository.GetById(id);
                if (deleteOrganization != null)
                {
                    _repository.Remove(deleteOrganization.Id);
                    return Ok(deleteOrganization);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Guid id, OrganizationUpdateRequest organization)
        {
            try
            {
                var organizationUpdate = new Organization
                {
                    Name = organization.Name,
                    AddressId = organization.AddressId,
                    PhoneNumber = organization.PhoneNumber
                };
                _repository.Update(id, organizationUpdate);
                return Ok(organizationUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
