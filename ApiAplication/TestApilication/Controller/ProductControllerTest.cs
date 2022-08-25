using ApiAplication.Data;
using AutoMapper;
using FakeItEasy;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApilication.Controller
{
   public  class ProductControllerTest
    {

        private readonly AppDbContext _context;
        public static IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public ProductControllerTest()
        {
            _context = A.Fake<AppDbContext>();
            _env = A.Fake<IWebHostEnvironment>();
            _mapper = A.Fake<IMapper>();
        }
    }
}
