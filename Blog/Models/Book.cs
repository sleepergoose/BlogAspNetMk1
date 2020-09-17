using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Models
{
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название книги")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Автор книги")]
        public string Author { get; set; }


        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Описание книги")]
        public string Description { get; set; }


        public byte[] CoverImage { get; set; }
    }
}