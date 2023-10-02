using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sendmail.Mail;

namespace sendmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public SendMailController(IEmailService service)
        {
            _emailService = service;
        }


        [HttpPost]
        public async Task<IActionResult> SendMail()
        {
            try
            {
                MailRequest mailRequest = new MailRequest();

                mailRequest.ToEmail = "carlosacgr@gmail.com";
                mailRequest.Subject = "Bem vindo ao SendMail";
                mailRequest.Body = GetHtmlContent();

                await _emailService.SendEmailAsync(mailRequest);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }


        private string GetHtmlContent()
        {
            string Response = "<div style=\"width:100%;background-color:#B51D44;color:white;text-align:center;margin:10px\">";
            Response += "<h1>Seja bem vindo ao Event+ !</h1>";
            Response += "<h2>Obrigado por inscrever-se na plataforma Event+</h2>";
            Response += "</div>";
            return Response;
        }
    }
}
