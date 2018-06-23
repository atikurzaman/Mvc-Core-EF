using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Domain
{
    public enum ProductAttributeDisplayType
    {
        [Display(Name = "Select")]
        Select = 0,

        [Display(Name = "List")]
        List = 1,

        [Display(Name = "Numeric")]
        Numeric =2,

        [Display(Name = "Color Picker")]
        Color_Picker =3
    }
    public enum ProductAttributeOrderType
    {
        [Display(Name = "Custom Ordering")]
        Custom_Ordering = 0,
        Name = 1,
        [Display(Name = "Name (Numeric)")]
        Name_Numeric = 2,
        [Display(Name = "Term Id")]
        Term_Id = 3
    }
}
