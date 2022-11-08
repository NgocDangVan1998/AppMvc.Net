using AppMvc.Net.Models;
using System.Collections.Generic;

namespace AppMvc.Net.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[]
            {
                new ProductModel() {Id=1,Name="Iphone5",Price=3000},
                new ProductModel() {Id=2,Name="IphoneX",Price=30000},
                new ProductModel() {Id=3,Name="Iphone6",Price=4000},
                new ProductModel() {Id=4,Name="Iphone7",Price=5000},
                new ProductModel() {Id=5,Name="Iphone8",Price=6000}
            });
        }
    }
}
