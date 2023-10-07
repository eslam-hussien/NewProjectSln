using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NewProject
{
	public partial class Model1 : DbContext
	{
		public Model1()
			: base("name=Model1")
		{
		}

		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Export> Exports { get; set; }
		public virtual DbSet<ExportLog> ExportLogs { get; set; }
		public virtual DbSet<Import> Imports { get; set; }
		public virtual DbSet<ImportLog> ImportLogs { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Store> Stores { get; set; }
		public virtual DbSet<Supplier> Suppliers { get; set; }
		public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
		public virtual DbSet<Transfer> Transfers { get; set; }
		public virtual DbSet<Unit> Units { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>()
				.HasMany(e => e.Exports)
				.WithOptional(e => e.Customer)
				.HasForeignKey(e => e.FK_CustomerID);

			modelBuilder.Entity<Employee>()
				.HasMany(e => e.Stores)
				.WithRequired(e => e.Employee)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Export>()
				.HasMany(e => e.ExportLogs)
				.WithOptional(e => e.Export)
				.HasForeignKey(e => e.FK_ExportID);

			modelBuilder.Entity<Import>()
				.HasMany(e => e.ImportLogs)
				.WithOptional(e => e.Import)
				.HasForeignKey(e => e.FK_Import);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.ExportLogs)
				.WithOptional(e => e.Product)
				.HasForeignKey(e => e.FK_ProductID);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.ImportLogs)
				.WithRequired(e => e.Product)
				.HasForeignKey(e => e.FK_ProductID)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.Transfers)
				.WithOptional(e => e.Product)
				.HasForeignKey(e => e.FK_ProductID);

			modelBuilder.Entity<Store>()
				.HasMany(e => e.Imports)
				.WithOptional(e => e.Store)
				.HasForeignKey(e => e.FK_StoreID);

			modelBuilder.Entity<Store>()
				.HasMany(e => e.Transfers)
				.WithOptional(e => e.Store)
				.HasForeignKey(e => e.FK_FromStoreID);

			modelBuilder.Entity<Store>()
				.HasMany(e => e.Transfers1)
				.WithOptional(e => e.Store1)
				.HasForeignKey(e => e.FK_ToStoreID);

			modelBuilder.Entity<Supplier>()
				.HasMany(e => e.ExportLogs)
				.WithOptional(e => e.Supplier)
				.HasForeignKey(e => e.FK_SupplierID);

			modelBuilder.Entity<Supplier>()
				.HasMany(e => e.ImportLogs)
				.WithRequired(e => e.Supplier)
				.HasForeignKey(e => e.FK_SupplierID)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Supplier>()
				.HasMany(e => e.Transfers)
				.WithOptional(e => e.Supplier)
				.HasForeignKey(e => e.FK_SupplierID);

			modelBuilder.Entity<Unit>()
				.HasMany(e => e.Products)
				.WithRequired(e => e.Unit)
				.HasForeignKey(e => e.FK_UnitID)
				.WillCascadeOnDelete(false);
		}
	}
}
