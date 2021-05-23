using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model
{
	public class Ticket
	{
		public string Username { get; set; }

		public DateTime Booked { get; set; }

		public string Location { get; set; }
	}
}
