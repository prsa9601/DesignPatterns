﻿using Application.Content.Commands;
using Application.FlyWeight.Services;
using Application.GraphicDesign.Services;
using Application.Notification.Commands.SendNotification;
using Application.Order.Command.Finally;
using Application.Payment.Commands;
using Application.Product.Create;
using Application.Report.Commands.ReportAndExport;
using Application.Shape.Commands;
using Application.User.Commands.AddUser;
using Design_Patterns_API.Facade;
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
        private readonly RenderingService _fontRenderingService;
        private readonly ProductService _flyWeightProductService;

        public BaseController(IMediator mediator, RenderingService fontRenderingService, ProductService flyWeightProductService)
        {
            _mediator = mediator;
            _fontRenderingService = fontRenderingService;
            _flyWeightProductService = flyWeightProductService;
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

        [HttpPost("Bridge")]
        public IActionResult BridgeShape()
        {
            try
            {
                var result = _mediator.Send(new ShapePainterCommand());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Composite")]
        public IActionResult CompositeContent()
        {
            try
            {
                var result = _mediator.Send(new CreateContentCommand());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Strategy")]
        public IActionResult StrategyProduct()
        {
            try
            {
                var result = _mediator.Send(new CreateProductCommand());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Decorator")]
        public IActionResult DecoratorNotifier()
        {
            try
            {
                var result = _mediator.Send(
                    new Application.Notifier.Commands.SendNotificationCommand());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Facade")]
        public IActionResult FacadeOrder()
        {
            try
            {
                var _orderFacade = new OrderFacade(new Application.Order.Services.InventoryService(),
                    new Application.Order.Services.PaymentService(),
                    new Application.Order.Services.ShippingService());

                _orderFacade.PlaceOrder("ExampleId", 3,
                    "ExampleId", 10000000, "Tehran");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("FlyWeight")]
        public IActionResult FlyWeightGraphicDesign()
        {
            try
            {
                string result = _fontRenderingService.RenderText(
                    "Text Font Iran Sans", "Default Text", 6);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("FlyWeight2")]
        public IActionResult FlyWeight2()
        {
            try
            {
                var result = _flyWeightProductService.GetProduct(Guid.NewGuid());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
