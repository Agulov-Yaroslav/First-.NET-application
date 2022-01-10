using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Заполните поле, пожалуйста")]
        //[Range(1,50, ErrorMessage = "Название темы должно быть от 3 до 50 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Заполните поле, пожалуйста")]
        //[Range(1,500, ErrorMessage = "Описание темы должно быть от 3 до 500 символов")]
        public string About { get; set; }

        public DateTime Created { get; set; }  = DateTime.Now;






    }
}
