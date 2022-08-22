using ApiAplication.Controllers;
using ApiAplication.Data;
using ApiAplication.Dtos.CategoryDtos;
using ApiAplication.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace TestApiProject
{
    //public class Tests
    //{
    //    private readonly IMapper _mapper;
    //    private readonly AppDbContext _context;

    //    [Test]
    //    public void GetReturnsProductWithSameId()
    //    {
    //        int id = 2;
    //        Category category = new Category()
    //        {

    //            Name = "Lorem",
    //            Id = id,
    //        };
    //        var mockValidator = new Mock<AppDbContext>();
    //        var mockValidatorMapper = new Mock<IMapper>();
          
    //        var evaluator = new CategoryController(_context, _mapper);

           
           
    //        CategoryReturnDto categoryReturnDto = mockValidatorMapper.Object.Map<CategoryReturnDto>(category);
    //        var appResult = evaluator.GetOne(id);
    //        Assert.AreEqual(appResult, categoryReturnDto);
    //   }
    //}
}