using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        // ��� �������� ����� ������� � ������ ����� asp-for
        [BindProperty(SupportsGet = true)] // SupportsGet=true ��������� �������� � GET-������

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

        // ����� ��� ������ ������ ����� (��� ����� ������� � ��������� ���� � ����� Models)
        public class SearchRequest
        {
            [Required(ErrorMessage = "���� '������' ����������� ��� ����������")]
            [Display(Name = "������")]
            public string? From { get; set; }

            [Required(ErrorMessage = "���� '����' ����������� ��� ����������")]
            [Display(Name = "����")]
            public string? To { get; set; }

            [Required(ErrorMessage = "���� '���� ������' ����������� ��� ����������")]
            [Display(Name = "���� ������")]
            [DataType(DataType.Date)]
            public DateTime DepartureDate { get; set; } = DateTime.Today;

            [Display(Name = "���� �����������")]
            [DataType(DataType.Date)]
            public DateTime? ReturnDate { get; set; }

            [Required(ErrorMessage = "������� ���������� ����������")]
            [Range(1, 9, ErrorMessage = "���������� ���������� �� 1 �� 9")]
            [Display(Name = "���������")]
            public int Passengers { get; set; } = 1;

            [Display(Name = "����� ������������")]
            public string TravelClass { get; set; } = "Economy";
        }
    }
}
