using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using System;
using System.Threading.Tasks;

namespace OrderConsumer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IBus _bus;

		//Usamos a interface IBus configurada no arquivo Startup endPoint
		//e injetamos o objeto IBus no construtor do controlador
		public OrderController(IBus bus)
		{
			_bus = bus;
		}

		[HttpPost]
		public async Task<IActionResult> CreateTicket(Ticket ticket)
		{
			if (ticket != null)
			{
				//Definindo uma data e hora para a reserva
				ticket.Booked = DateTime.Now;

				//Definimos o nome da Fila como orderTicketQueue e criamos uma 
				//nova url: rabbitmq://localhost/orderTicketQueue
				//Se a fila nao existir o RabbitMQ vai criar para nós
				Uri uri = new Uri("rabbitmq://localhost/orderTicketQueue");

				//Obtém um endpoint para o qual vamos enviar o objeto Ticket(Shared.Model)
				var endPoint = await _bus.GetSendEndpoint(uri);

				//Envia a mensagem para a fila do RabbitMQ
				await endPoint.Send(ticket);

				return Ok();
			}

			return BadRequest();
		}
	}
}
