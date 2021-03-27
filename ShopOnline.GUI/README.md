#Structure Project
- Data Driven Design (3 layers -> Data - Business(Service) - GUI)
- .Net Framework 5.0

#Structure Data Layer
- AbstractRepository : IRepository
- ProductRepository : AbstractRepository
1) ShopOnlineRepository : IDisposable 
	=> help connect all repositories using same the DBContext instance
2) Or use another way: 
	a) Pass a DBContext instance as a parameter of AbstractRepository's constructor
	EX: public ProductRepository(ShopOnlineDbContext _context) : base (context) {}
	b) Want use another Repository with the same instance, then pass this Context
	EX: CategoryRepository cateRepo = new CategoryRepository(_context);

#Install Entity Framework Core
- Microsoft.EntityFrameworkCore.SqlServer 3.1.10
- Microsoft.EntityFrameworkCore.Design 3.1.10
- Microsoft.EntityFrameworkCore.Tools 3.1.10
  => Enables these commonly used commands (Add-Migration, Drop-Database, Remove-Migration, Scaffold-DbContext, Update-Database...)

#Migration Init
- Use "a design-time factory" class to run
	+ Implement "IDesignTimeDbContextFactory" interface
	=> If a class implementing this interface is found in either the same project as the derived DbContext or in the application's startup project, 
	the tools bypass the other ways of creating the DbContext and use the design-time factory instead.
- Install:
	+ Microsoft.Extensions.Configuration.FileExtensions
	+ Microsoft.Extensions.Configuration.Json

#Migration Commands
	1) Add-Migration <name_migration>   //create new migration
	2) Update-database [–Verbose]   //update db
	3) Update-database <name_migration_without_time>    //revert migration
	5) Script-Migration		//generate SQL for all migrations
	4) Script-Migration -From <name_migration_without_time> -To <name_migration_without_time>	//(from,to]: generate SQL from To_migration
	==>> When execute migration command, the OnModelCreating function in ShopOnlineDBContext will be run.

#Git
	1) Don't need push "package" folder to Git. Visual Studio has feature "Restore Package".

#Knowledge - Mistake
- FLUENT API: https://www.learnentityframeworkcore.com/configuration/fluent-api
	+ Usage:
		0) Overried function in ShopOnlineDBContext "protected override void OnModelCreating(ModelBuilder modelBuilder)"
		1) Create a Configuration class (Ex: SysSettingConfiguration)
		2) Implement "IEntityTypeConfiguration<SysSetting>" interface
		3) Define property: ToTable(), HasKey(), IsRequired(),...
		4) Apply to OnModelCreating function "modelBuilder.ApplyConfiguration(new CartConfiguration());"
	+ Relation One-to-One
	+ Relation One-to-Zero-or-One
	+ Relation One-to-Many: Product-Cart, Order-OrderDetail
		- One(A) to Many(B) 
		=> Write configuration inside (B)
		1) Table (A): public ICollection<OrderDetail> OrderDetails { get; set; }
		2) Table (B): public Order Order { get; set; }
		3) Inside Config (B): builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
	+ Relation Many-to-Many: Category-Product, User-Role
		- Many(A) to Many(B) 
		=> Create a new Table(C)
		1) Table(C) have all primary keys of both tables
		2) Relation becomes: One(A and B) to Many(C) 
		==>> write both config of (A,B) inside (C)
	+ Self-Relation: Category, SysFeature
		- Table (A):
			+ public Category ParentCategory { get; set; }
			+ public ICollection<Category> ChildrenCategories { get; set; }
		- Inside Config (A): builder.HasMany(s => s.ChildrenCategories).WithOne(s => s.ParentCategory).HasForeignKey(s => s.ParentId);

- SEEDING DATA (Init Data):
	+ Workflow:
		1) Change the value of Primary key (included: DateTime.Now, Guid.NewGuid()). 
		   Because EF core uses it to check if any changes made to the record. 
		   then the migration script will DELETE and RECREATE all the related records.
		2) Change the value of Non-Primary key. Data will be updated.
	+ Implement by:
		1) putting func in the OnModelCreating function.
		2) creating migration
	+ Two ways to seeding:
		1) Write directly in OnModelCreating func
		2) Use "Extension Method" to create Seed func for "ModelBuilder" class
		public static class class_name
		{
			public static void new_func_name(this ModelBuider modelBuilder) {}
		}
	+ Revert Migration is still effect








