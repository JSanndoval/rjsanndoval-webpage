using Microsoft.AspNetCore.Mvc;
using ContactForm.Models;
using ContactForm.Services;

namespace ContactForm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly EmailService _emailService;

        public ContactController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool result = await _emailService.SendEmail(model);

            if (result)
                return Ok(new {success = true, message = "Correo enviado"});
            return StatusCode(500, new { success = false, message = "Error al enviar el correo" });
        }
    }
}
