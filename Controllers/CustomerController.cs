using MarketApi.DTOs.Customer;
using MarketApi.DTOs.ProductDTOs;
using MarketApi.Interfacies;
using MarketApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _repository;
        public CustomerController(IRepository<Customer> repository)
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
        [HttpGet("{id:Guid}")]
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
        public IActionResult Post(CustomerRequest customer)
        {
            var product = new Customer
            {
                Name = customer.Name,
                AddressId = customer.AddressId,
                PhoneNumber = customer.PhoneNumber
            };
            _repository.Add(product);
            return Created("", product);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var deleteCustomer = _repository.GetById(id);
                if (deleteCustomer != null)
                {
                    _repository.Remove(deleteCustomer.Id);
                    return Ok(deleteCustomer);
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
        public IActionResult Put(Guid id, CustomerRequest customer)
        {
            try
            {
                var product = new Customer
                {
                    Name = customer.Name,
                    AddressId = customer.AddressId,
                    PhoneNumber = customer.PhoneNumber
                };
                _repository.Update(id, product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
