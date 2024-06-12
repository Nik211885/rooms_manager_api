﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using src.Data;

namespace src.Controllers.Admin.BillServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillServicesController : ControllerBase
    {
        private RoomsManagerDbConText _dbContext;
        private IConfiguration _configuration;
        public BillServicesController(RoomsManagerDbConText dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
    }
}
