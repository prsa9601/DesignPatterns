using Application.Notification.Commands.SendNotification;
using Application.Order.Command.Finally;
using Application.Payment.Commands;
using Application.Report.Commands.ReportAndExport;
using Application.User.Commands.AddUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Design_Patterns_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Observer")]
        public IActionResult ObserverFinallyOrder()
        {
            try
            {
                var result = _mediator.Send(new FinallyOrderCommand());
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
   
        [HttpPost("Builder")]
        public IActionResult BuilderAddUser()
        {
            try
            {
                var command = new AddUserCommand()
                {
                    Age = 18,
                    Password = "12345678",
                    UserName = "Parsa"
                };
                var result = _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpPost("AbstractFactory")]
        public IActionResult AbstractFactoryGenerateAndExportReport()
        {
            try
            {
                var result = _mediator.Send(new GenerateAndExportReportCommand());
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpPost("FactoryMethodExampleDesignPatten")]
        public IActionResult FactoryMethodSendNotification()
        {
            try
            {
                var result = _mediator.Send(new SendNotificationCommand()
                {
                    message = default(string),
                    notificationType = Domain.Notification.Enum.NotificationType.sms,
                });
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpPost("Adapter")]
        public IActionResult AdapterPayment()
        {
            try
            {
                var result = _mediator.Send(new PayPaymentCommand());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
