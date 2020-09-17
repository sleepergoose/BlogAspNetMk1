using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Models
{
    public class Comment
    {
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Имя пользователя")]
        public string User { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Текст комментария")]
        public string Text { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ArticleId { get; set; }
    }
}




	
	