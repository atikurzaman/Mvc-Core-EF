using Application.Domain;
using Application.Utility.Extentions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models
{
    public class ProductAttributeViewModel : BaseEntityViewModel
    {
        [Required, MaxLength(128)]
        public string Name { get; set; }

        [Required, MaxLength(128)]
        public string Label { get; set; }

        [Required]
        public ProductAttributeDisplayType Type { get; set; }        
        
        [Display(Name = "Order By"),Required]
        public ProductAttributeOrderType OrderBy { get; set; }

        [Required]
        public Boolean Status { get; set; }
        public List<SelectListItem> AttributeDisplayTypes { get; set; }
        public List<SelectListItem> ProductAttributeOrderTypes { get; set; }
        public ICollection<ProductAttributeItem> ProductAttributeItems { get; set; }
        public ProductAttributeViewModel()
        {           

            AttributeDisplayTypes = new List<SelectListItem>();

            AttributeDisplayTypes.Add(new SelectListItem
            {
                Value = ((int)ProductAttributeDisplayType.Select).ToString(),
                Text = ProductAttributeDisplayType.Select.GetDisplayName()
            });

            AttributeDisplayTypes.Add(new SelectListItem
            {
                Value = ((int)ProductAttributeDisplayType.List).ToString(),
                Text = ProductAttributeDisplayType.List.GetDisplayName()
            });

            AttributeDisplayTypes.Add(new SelectListItem
            {
                Value = ((int)ProductAttributeDisplayType.Color_Picker).ToString(),
                Text = ProductAttributeDisplayType.Color_Picker.GetDisplayName()
            });

            ProductAttributeOrderTypes = new List<SelectListItem>();

            ProductAttributeOrderTypes.Add(new SelectListItem
            {
                Value = ((int)ProductAttributeOrderType.Custom_Ordering).ToString(),
                Text = ProductAttributeOrderType.Custom_Ordering.GetDisplayName()
            });

            ProductAttributeOrderTypes.Add(new SelectListItem
            {
                Value = ((int)ProductAttributeOrderType.Name).ToString(),
                Text = ProductAttributeOrderType.Name.ToString()
            });

            ProductAttributeOrderTypes.Add(new SelectListItem
            {
                Value = ((int)ProductAttributeOrderType.Name_Numeric).ToString(),
                Text = ProductAttributeOrderType.Name_Numeric.GetDisplayName()
            });

            ProductAttributeOrderTypes.Add(new SelectListItem
            {
                Value = ((int)ProductAttributeOrderType.Term_Id).ToString(),
                Text = ProductAttributeOrderType.Term_Id.GetDisplayName()
            });

        }
    }
}
