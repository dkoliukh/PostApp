using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostApp.Models
{
	#region Class : PaymentCard
	public class PaymentCard : BaseEntity
	{
		#region Properties : Database
		public string Holder { get; set; }

		public string Number { get; set; }

		public string ValidTo { get; set; }

		public string CVV { get; set; }

		[ForeignKey("PaymentSystem")]
		public Guid? PaymentSystemId { get; set; }
		#endregion

		public virtual PaymentSystem PaymentSystem { get; set; }
	}
	#endregion
}