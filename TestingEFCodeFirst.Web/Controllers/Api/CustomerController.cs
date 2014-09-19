﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingEFCodeFirst.Services;

namespace TestingEFCodeFirst.Web.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public HttpResponseMessage GetCustomers()
        {
            var customers = _customerService.GetList();
            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

        [HttpGet]
        public HttpResponseMessage GetCustomer(int id)
        {
            var customer = _customerService.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        [HttpPut]
        public HttpResponseMessage UpdateCustomer(Customer customer)
        {
            _customerService.Update(customer);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }


        [HttpPost]
        public HttpResponseMessage SaveCustomer(Customer customer)
        {
            _customerService.Save(customer);
            return Request.CreateResponse(HttpStatusCode.Created, customer);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteCustomer(Customer customer)
        {
            _customerService.Delete(customer);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}