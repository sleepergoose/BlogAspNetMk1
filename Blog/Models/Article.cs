using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Models
{
    public class Article
    {
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Текст статьи")]
        [AllowHtml]
        public string Text { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Краткое описание статьи")]
        public string ShortDescription { get; set; }
    }

    public enum Category
    {
        CSharp,
        ASP_NET,
        SQL,
        Entity_Framework,
        Other
    }
}

    
    
	
	
	