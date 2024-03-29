﻿namespace Bsharp.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using Bsharp.Domain;
    using Bsharp.Repository;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        IBSharpRepository _repo;

        public UsersController(IBSharpRepository repo)
        {
            _repo = repo;
        }

		[HttpGet]
		public IEnumerable<User> Get()
		{
			return _repo.Users();
		}

		[HttpGet("{email}", Name = "GetUser")]
        public IActionResult Get(string email)
		{
            try
            {
                return new ObjectResult(_repo.User(email));
            }
            catch(Exception)
            {
                return new ObjectResult("Could not find user");
            }
		}

        [HttpPost]
        public IActionResult Create(string email, 
                           string handle, 
                           string password)
        {
            //super simple auth here

            var user = new User(Guid.NewGuid(), Guid.NewGuid().ToString(), 
                                handle, email);
            _repo.CreateUser(user);

            return CreatedAtRoute("GetUser", new { email = user.Email}, user);
        }
    }
}
