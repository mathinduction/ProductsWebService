﻿using System.ComponentModel.DataAnnotations;

namespace ProductsWebService.Database.Entities
{
    public class Product
    {
        [Key]
        [Required]
        public string Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string ImgUri { set; get; }
        [Required]
        public decimal Price { set; get; }
        public string Description { set; get; }

        public void Update(Product product)
        {
            Name = product.Name;
            ImgUri = product.ImgUri;
            Price = product.Price;
            Description = product.Description;
        }

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            if (product == null)
                return false;

            if (Id == product.Id 
                && Name == product.Name 
                && ImgUri == product.ImgUri 
                && Price == product.Price 
                && Description == product.Description)
                return true;

            return false;
        }
    }
}
