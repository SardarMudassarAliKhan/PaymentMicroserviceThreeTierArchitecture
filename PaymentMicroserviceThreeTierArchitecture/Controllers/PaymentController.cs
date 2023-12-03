using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentMicroserviceThreeTierArchitecture_BAL.IPaymentService;
using PaymentMicroserviceThreeTierArchitecture_DAL.ApplicationContext;
using PaymentMicroserviceThreeTierArchitecture_DAL.Entities;

namespace PaymentMicroserviceThreeTierArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ICustomService<Payment> _customService;
        private readonly ApplicationDbContext _applicationDbContext;
        public PaymentController(ICustomService<Payment> customService,
            ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet(nameof(GetPaymentById))]
        public IActionResult GetPaymentById(int Id)
        {
            var obj = _customService.Get(Id);
            if(obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet(nameof(GetAllPayments))]
        public IActionResult GetAllPayments()
        {
            var obj = _customService.GetAll();
            if(obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpPost(nameof(CreatePaymentItem))]
        public IActionResult CreatePaymentItem(Payment student)
        {
            if(student != null)
            {
                _customService.Insert(student);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }

        [HttpPost(nameof(UpdatePaymentItem))]
        public IActionResult UpdatePaymentItem(Payment student)
        {
            if(student != null)
            {
                _customService.Update(student);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete(nameof(DeletePaymentItem))]
        public IActionResult DeletePaymentItem(Payment student)
        {
            if(student != null)
            {
                _customService.Delete(student);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

    }
}
