using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Models
{
    public class Author
    {
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название статьи")]
        public string ArticleTitle { get; set; }
    }
}