using FluentAssertions;
using CleanArchMvc.Domain.Entities;
using System;
using Xunit;


namespace CleanArchMvc.Domain.Tests;
public class ProductUnitTest1
{
    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product
        (
            1, 
            "Product Name",
            "Product Description",
            9.99m,
            10,
            "https://teste.com.br"
        );

        action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product
        (
            -1, 
            "Product Name",
            "Product Description",
            9.99m,
            10,
            "https://teste.com.br"
        );
        
        action
            .Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact]
    public void CreateProduct_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Product
        (
            1, 
            "Pr",
            "Product Description",
            9.99m,
            10,
            "https://teste.com.br"
        );

        action
            .Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Too short, minimum 3 charecters");
    }

    [Fact]
    public void CreateProduct_EmptyNameValue_DomainExceptionEmptyName()
    {
        Action action = () => new Product
        (
            1, 
            "",
            "Product Description",
            9.99m,
            10,
            "https://teste.com.br"
        );

        action
            .Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact]
    public void CreateProduct_EmptyDescriptionValue_DomainExceptionEmptyDescription()
    {
        Action action = () => new Product
        (
            1, 
            "Product Name",
            "",
            9.99m,
            10,
            "https://teste.com.br"
        );

        action
            .Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description. Description is required");
    }

    [Fact]
    public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
    {
        Action action = () => new Product
        (
            1, 
            "Product Name",
            "Des",
            9.99m,
            10,
            "https://teste.com.br"
        );

        action
            .Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description. Too short, minimum 5 charecters");
    }

    [Fact]
    public void CreateProduct_NegativePriceValue_DomainExceptionInvalidPrice()
    {
        Action action = () => new Product
        (
            1, 
            "Product Name",
            "Product Description",
            -1.15m,
            10,
            "https://teste.com.br"
        );
        
        action
            .Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid price value");
    }

    [Fact]
    public void CreateProduct_NegativeStockValue_DomainExceptionInvalidStock()
    {
        Action action = () => new Product
        (
            1, 
            "Product Name",
            "Product Description",
            1.15m,
            -10,
            "https://teste.com.br"
        );
        
        action
            .Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }

    [Fact]
    public void CreateProduct_LongImageValue_DomainExceptionLongImage()
    {
        Action action = () => new Product
        (
            1, 
            "Product Name",
            "Description",
            9.99m,
            10,
            "https://testetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetesteteste.com.br"
        );

        action
            .Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid image name. Too long, maximum 250 charecters");
    }

}
