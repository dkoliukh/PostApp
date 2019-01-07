using Microsoft.EntityFrameworkCore;
using PostApp.Models.Database;
using System;
using System.Linq;
using System.Reflection;

namespace PostApp.Models
{
	#region Class : AppDbContext
	public class AppDbContext : DbContext
	{
		#region Properties : Database
		public DbSet<Contact> Contact { get; set; }
		
		public DbSet<PaymentCard> PaymentCard { get; set; }
		
		public DbSet<PaymentSystem> PaymentSystem { get; set; }

		public DbSet<Address> Address { get; set; }

		#region Properties : Lookups
		[Lookup]
		public DbSet<Country> County { get; set; }

		[Lookup]
		public DbSet<City> City { get; set; }

		[Lookup]
		public DbSet<Street> Street { get; set; }
		#endregion
		#endregion

		#region Constructor
		public AppDbContext(DbContextOptions options) : base(options) { }
		#endregion

		#region Methods : Public
		public DbSet<Lookup> GetLookupByName(string name)
		{
			PropertyInfo result = this.GetType()?.GetProperties()
				?.Where(a => Attribute.IsDefined(a, typeof(LookupAttribute)))
				?.FirstOrDefault();
			return result?.GetValue(this) as DbSet<Lookup>;
		}
		#endregion

		#region Methods : Protected
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Ignore<Lookup>();
			modelBuilder.Ignore<BaseEntity>();
			base.OnModelCreating(modelBuilder);
		}
		#endregion
	}
	#endregion
}