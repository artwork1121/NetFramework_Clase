using NET.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccDatos
{
    public class MyContext : DbContext
    {
        public MyContext() : base("Data Source=localhost;Initial Catalog=NET_Framework;Integrated Security=True")
        {
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder
				.Conventions
				.Remove<PluralizingTableNameConvention>();
			base.OnModelCreating(modelBuilder);
		}

		private void FixEfProviderServicesProblem()
		{
			// The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
			// for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
			// Make sure the provider assembly is available to the running application. 
			// See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
			var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
		}

		public DbSet<Adress> Adresses { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Company> Companys { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Sale> Sales { get; set; }
		public DbSet<SaleLine> SaleLines { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Provincia> Provincias { get; set; }
		public DbSet<Localidad> Localidades { get; set; }
	}    
}
