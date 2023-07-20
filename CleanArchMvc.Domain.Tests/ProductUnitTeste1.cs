using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name","Product Descption",50,100,"minha imagem",1);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();


        }

        [Fact(DisplayName = "Create Product With Valid negative Value")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Descption", 50, 100, "minha imagem", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid ID value.");


        }

        [Fact(DisplayName = "Create Product Short Name")]
        public void CreateProduct_ShortName_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1,"Pr", "Product Descption", 50, 100, "minha imagem", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, manimum 3 characters");


        }

        [Fact(DisplayName = "Create Product Missing Name Value")]
        public void CreateProduct_EmptyNameVAlue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1,  "", "Product Descption", 50, 100, "minha imagem", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");


        }

        [Fact(DisplayName = "Create Product NULL Name Value")]
        public void CreateProduct_NullNameVAlue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Product Descption", 50, 100, "minha imagem", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");


        }

        [Fact(DisplayName = "Create Product too long image")]
        public void CreateProduct_TooLongImage_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "Product Name", "Product Descption", 50, 100, "ghjghjghjghjghjghghjghjjkljljljlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllljghjghjghjghjghjghjghjghjghjghjghjghjghjghjghghjghghjghjghjghjghjghjghjghjghjghjghjghjghjghghjjhjkhjkhjkhjkhjkhjkhjkhjkhjkhjkhjkhkghghjghghjghjghjghghghjghjghjghjghjghjghjghjghjghjghjghjghjghjghjghjghjghjghjghjghjgh", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name , too long, maximum 250 characters");

        }

        [Fact(DisplayName = "Create Product Stock Invalid")]
        public void CreateProduct_NegativeStock_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Product Name", "Product Descption", 50, -50, "minha imagem", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");


        }

        [Fact(DisplayName = "Create Product price Invalid")]
        public void CreateProduct_InvalidPrice_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Descption", -10, 50, "minha imagem", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");


        }
    }
}