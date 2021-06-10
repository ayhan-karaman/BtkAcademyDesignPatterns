using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
       
            productDirector.GenerateProduct(builder);
            var model = builder.GetModel();
            Console.WriteLine
                (
                model.Id + "\n" +
                model.CategoryName + "\n"+
                model.DiscountApplied + "\n" +
                model.DiscountPrice + "\n" +
                model.ProductName + "\n" +
                model.UnitPrice 
                );




            Console.ReadLine();
        }
    }

    class ProductWiewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }
  abstract  class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductWiewModel GetModel();

    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductWiewModel model = new ProductWiewModel();
        public override void ApplyDiscount()
        {
            model.DiscountPrice = model.UnitPrice * (decimal)0.90;
            model.DiscountApplied = true;
        }

        public override ProductWiewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Cahi";
            model.UnitPrice = 20;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductWiewModel model = new ProductWiewModel();
        public override void ApplyDiscount()
        {
            model.DiscountPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductWiewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Cahi";
            model.UnitPrice = 20;
        }
    }
    class  ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
