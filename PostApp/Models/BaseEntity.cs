using System;
using System.ComponentModel.DataAnnotations;

namespace PostApp.Models
{
	public class BaseEntity
	{
		[Key]
		public Guid Id { get; set; }
	}
}