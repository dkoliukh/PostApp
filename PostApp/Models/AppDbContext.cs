using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace PostApp.Models
{
	public class AppDbContext : DbContext
	{
		public DbSet<Contact> Contact { get; set; }
		
		public DbSet<PaymentCard> PaymentCard { get; set; }
		
		public DbSet<PaymentSystem> PaymentSystem { get; set; }

		[Lookup]
		public DbSet<Country> County { get; set; }

		[Lookup]
		public DbSet<City> City { get; set; }

		public AppDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Lookup> GetLookupByName(string name)
		{
			PropertyInfo result = this.GetType()?.GetProperties()
				?.Where(a => Attribute.IsDefined(a, typeof(LookupAttribute)))
				?.FirstOrDefault();
			return result?.GetValue(this) as DbSet<Lookup>;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Ignore<Lookup>();
			modelBuilder.Ignore<BaseEntity>();
			base.OnModelCreating(modelBuilder);
		}
	}
}