using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        // Это свойство будет связано с формой через asp-for
        [BindProperty(SupportsGet = true)] // SupportsGet=true позволяет работать с GET-запрос

        public SearchRequest? Searchrequest { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Searchrequest ??= new SearchRequest
            {
                DepartureDate = DateTime.Today,
                Passengers = 1,
                TravelClass = "Economy"
            };
        }

        // Класс для модели данных формы (его лучше вынести в отдельный файл в папке Models)
        public class SearchRequest
        {
            [Required(ErrorMessage = "Поле 'Откуда' обязательно для заполнения")]
            [Display(Name = "Откуда")]
            public string? From { get; set; }

            [Required(ErrorMessage = "Поле 'Куда' обязательно для заполнения")]
            [Display(Name = "Куда")]
            public string? To { get; set; }

            [Required(ErrorMessage = "Поле 'Дата вылета' обязательно для заполнения")]
            [Display(Name = "Дата вылета")]
            [DataType(DataType.Date)]
            public DateTime DepartureDate { get; set; } = DateTime.Today;

            [Display(Name = "Дата возвращения")]
            [DataType(DataType.Date)]
            public DateTime? ReturnDate { get; set; }

            [Required(ErrorMessage = "Укажите количество пассажиров")]
            [Range(1, 9, ErrorMessage = "Количество пассажиров от 1 до 9")]
            [Display(Name = "Пассажиры")]
            public int Passengers { get; set; } = 1;

            [Display(Name = "Класс обслуживания")]
            public string TravelClass { get; set; } = "Economy";
        }
    }
}
