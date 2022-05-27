using OnlineShoppingCenterproject.Core.Entities.Models;
using OnlineShoppingCenterproject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Entities
{
    public class Product : IBaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string ModelNumber { get; set; }
        [Required]
        public string WarrantyCompany { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Foto { get; set; }
        [Required]
        public double UnitPrice { get; set; }
    }
}
