using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ContactForm.Models;
using System.Threading.Tasks;
using ContactForm.Services;

namespace ContactForm.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EmailService _emailService;

        public IndexModel(ILogger<IndexModel> logger, EmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        [BindProperty]
        public FormModel FormData { get; set; } = new FormModel();

        public string? SuccessMessage { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool enviado = await _emailService.SendEmail(FormData);

            SuccessMessage = enviado ? "Mensaje enviado correctamente" : "Hubo un error al enviar el mensaje.";

            return Page();
        }
    }
}
