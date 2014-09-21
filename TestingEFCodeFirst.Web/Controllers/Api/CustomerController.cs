using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingEFCodeFirst.EF;

namespace TestingEFCodeFirst.Web.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private readonly IUnityOfWork<Customer> _unitOfWork;

        public CustomerController(IUnityOfWork<Customer> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public HttpResponseMessage GetCustomers()
        {
            var customers = _unitOfWork.Repository.GetList();
            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

        [HttpGet]
        public HttpResponseMessage GetCustomer(int id)
        {
            var customer = _unitOfWork.Repository.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        [HttpPut]
        public HttpResponseMessage UpdateCustomer(Customer customer)
        {
            _unitOfWork.Repository.Update(customer);
            _unitOfWork.Save();
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }


        [HttpPost]
        public HttpResponseMessage SaveCustomer(Customer customer)
        {
            _unitOfWork.Repository.Insert(customer);
            _unitOfWork.Save();
            return Request.CreateResponse(HttpStatusCode.Created, customer);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteCustomer(Customer customer)
        {
            _unitOfWork.Repository.Delete(customer);
            _unitOfWork.Save();
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _unitOfWork.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
