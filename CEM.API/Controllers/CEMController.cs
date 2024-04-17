﻿using CEM.Model.Model;
using CEM.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CEM.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("ReactPolicy")]
    public class CEMController : Controller
    {
        private readonly ICEMService _cemService;
        public CEMController(ICEMService cemService)
        {
            _cemService = cemService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var responseWrapper = new ResponseWrapper();

            var results = await _cemService.RegisterUserAsync(user);
            if (results == null)
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Unable to registered user",
                    Success = false
                };

                return Ok(responseWrapper);
            }
            responseWrapper = new ResponseWrapper
            {
                Message = "Successfully registered",
                Results = results,
                Success = true
            };

            return Ok(responseWrapper);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var responseWrapper = new ResponseWrapper();

            var results = await _cemService.LoginAsync(user.PhoneNo, user.Password);
            if (results.Id == 0)
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Wrong username or password",
                    Success = false
                };

                return Ok(responseWrapper);
            }
            responseWrapper = new ResponseWrapper
            {
                Message = "Successfully login",
                Results = results,
                Success = true
            };

            return Ok(responseWrapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddComplain([FromBody] Complain complain)
        {
            var responseWrapper = new ResponseWrapper();

            var results = await _cemService.AddComplainAsync(complain);
            if (results == null)
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Unable to send your request",
                    Success = false
                };

                return Ok(responseWrapper);
            }
            responseWrapper = new ResponseWrapper
            {
                Message = "Your request has been send seccussfully",
                Results = results,
                Success = true
            };

            return Ok(responseWrapper);
        }

        [HttpPost]
        public IEnumerable<Complain> ComplainListByUserId([FromBody] Complain complain)
        {
            var results = _cemService.GetComplainsByUserId(complain.UserId);

            return results;
        }
    }
}

