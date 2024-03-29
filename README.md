﻿#Structure Project
- Data Driven Design (3 layers -> Data - Business(Service) - GUI)
- .Net 5.0 (Difference: .Net Framework, .Net Core)

#Git
	1) Don't need push "package" folder to Git. Visual Studio has feature "Restore Package".

#Structure Data Layer
- Layer 1: IRepository
- Layer 2: AbstractRepository : IRepository
- Layer 3: "Entity"-Repository : AbstractRepository
1) ShopOnlineRepository : IDisposable 
	+ "_context" variable
	=> help connect all repositories using a same the DBContext instance
2) Or use another way: 
	a) Pass a DBContext instance as a parameter of AbstractRepository's constructor
	EX: public ProductRepository(ShopOnlineDbContext _context) : base (context) {}
	b) Want use another Repository with the same instance, then pass this Context
	EX: CategoryRepository cateRepo = new CategoryRepository(_context);

#Module Backend API
1) [Route("api/[controller]")]
	public class CustomerController : ControllerBase
	=> [controller] meaning name of current controller
	=> Route: api/customer

#Install Entity Framework Core (Data Layer)
- Microsoft.EntityFrameworkCore.SqlServer 3.1.10
- Microsoft.EntityFrameworkCore.Design 3.1.10
- Microsoft.EntityFrameworkCore.Tools 3.1.10 (required: Design package)
  => Enables these commonly used commands (Add-Migration, Drop-Database, 
  Remove-Migration, Scaffold-DbContext, Update-Database...)
  => That's why running migration need to SetStartUpProject to ShopOnline.Data
  => Because ShopOnline.Application doesn't have enough pakages.

#Setup DI for DBContext
- Install packages for Application Layer
	+	Microsoft.EntityFrameworkCore.SqlServer 3.1.10
	+	Microsoft.AspNetCore.Identity.EntityFrameworkCore 3.1.10
- Startup.cs file
	+	using Microsoft.EntityFrameworkCore;
	+	ConfigureServices func
		-	services.AddDbContext<ShopOnlineDBContext>
				(options => options.UseSqlServer("name=ConnectionStrings:ShopOnlineDB"));
	+ ConnectionStrings defined in appsettings.json file

#Migration Init
- Use "a design-time factory" class to run
	+ Implement "IDesignTimeDbContextFactory" interface
	=> If a class implementing this interface is found in either the same project as the derived DbContext 
	or in the application's startup project, the tools bypass the other ways of creating the DbContext 
	and use the design-time factory instead.
- Install:
	+ Microsoft.Extensions.Configuration.FileExtensions 3.1.10
	+ Microsoft.Extensions.Configuration.Json 3.1.10

#Migration Commands
	1) Add-Migration <name_migration>   //create new migration
	2) Update-database [–Verbose]   //update db
	3) Update-database <name_migration_without_time>    //revert migration
	=> "Update-database 0" (REVERT AL migrations) 
	5) Script-Migration		//generate SQL for all migrations
	4) Script-Migration -From <name_migration_without_time> -To <name_migration_without_time>	
	//(from,to]: generate SQL from To_migration
	==>> When execute migration command, the OnModelCreating function in ShopOnlineDBContext will be run.

#Migration Machanism
	1) Run migration commands
	2) Create tables in "DbSet<Table>" list
	3) Apply configuration file in "OnModelCreating" (detail config)

#Knowledge - Mistake
- FLUENT API: https://www.learnentityframeworkcore.com/configuration/fluent-api
	+ Usage:
		0) Overried function in ShopOnlineDBContext "protected override void OnModelCreating(ModelBuilder modelBuilder)"
		1) Create a new Entity Configuration class (Ex: "EntityName"Configuration)
		2) This new class implements "IEntityTypeConfiguration<SysSetting>" interface
		3) Define property: ToTable(), HasKey(), IsRequired(), HasDefaultValue(), ...
		4) Apply to "OnModelCreating" function "modelBuilder.ApplyConfiguration(new CartConfiguration());"
	+ Relation One-to-One
	+ Relation One-to-Zero-or-One
	+ Relation One-to-Many: Product-Cart, Order-OrderDetail, Product-ProductImage
		- One(Order) to Many(OrderDetail) 
		=> Write configuration inside (OrderDetail)
		1) Table (Order): 
		   + public ICollection<OrderDetail> OrderDetails { get; set; }
		2) Table (OrderDetail): 
		   + public Order Order { get; set; }
		3) Inside Config (OrderDetailConfiguration): 
		   + builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
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

#SEEDING DATA (Init Data):
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

#IndentityDbContext
	+ Install package "Microsoft.AspNetCore.Identity"
	+ Inherrit from DbContext => has all feature of DbContext.
	+ Support for identty purpose (Default classes: IdentityUser, IdentityRole, ...). 
	+ Has 3 generic classes with the SAME NAME: 
		1) Class_1 : DbContext (receive 4 => using 4 params)
		=> Need to pass 4 instances of "User, UserClaim, UserLogin, UserTokem" DbSets
		2) Class_2 : Class_1 (receive 7 => using 7 params) [BEST FEXIBLE => can custom 7 DbSets]
		=> Need to pass 7 instances of "Role, UserRole, RoleClaims" + All Class_1 DbSets
		3) Class_3 : Class_2 (receive 2 => using 7 params)
		=> Need to pass 2 instances of "User and Role" and 
			5 remaining Dbsets is default (so you CAN NOT CUSTOM this 5 classes)
	=> So you can use which class you want to use
	=> Why do I use Class_3 ?
		- I can CUSTOM "IdentityUser" and "IdentityRole" classes
	    - That why we MUST declare 5 DbSets (UserClaim, UserLogin, UserToken, UserClaims, UserRole)

#Using context.Database.Migrate() vs context.Database.EnsureCreated()
	+ context.Database.Migrate()
		1) Create Db if it does not already exist
		2) Apply migration files
	+ context.Database.EnsureCreated()
		1) Create Db if it does not already exist
			=> new DB CAN NOT be updated by migrations file.
		2) DON'T Apply migration files

#Install Serilog - Third party in Project
	- Installing NuGet package "Serilog.Extensions.Logging.File" 2.0.0
	- Meaning:
		+ Implementing Logging in .NET CORE SDK needs 2 parts:
			1) LOGGING API:
				+ 3 interfaces: ILogger (can redefine) <= ILoggerFactory (defined) => ILoggerProvider (can redefine) 
				+ A set of APIs create logs
				+ Included in "Microsoft.Extensions.Logging" namespace
			2) LOGGING PROVIDER:
				+ Redefine: ILoggerProvider, ILogger
				+ WHERE to Store or Display logs: Console, File, Debug, ...
				+ Third parties - Providers (collaborated with Microsoft): NLog, Serilog, Log4Net, ...
		+ Implementing Logging in ASP.NET CORE
			- Automatically included when creating project with default providers (Console, Debug)
		+ Log Levels:
			- Trace(0) < Debug < Information < Warning < Error < Critical(5)

#How to run default URL
	+	(LOCAL)launchSettings.json (Choose IIS or Selfhost)
		"launchUrl": "swagger",

#JWT for Authenticate
	+ JWT includes 3 parts seperated by "." -> Header.Payload.Signature
		1) Header (Encode/Decode: Base64url)
			{
				"typ": "JWT",	//type of string
				"alg": "HS256"	//algorithm used for Signature
			}
		2) Payload (Encode/Decode: Base64url)
			{
				//Info we want to save
				"Id", "Name",...
			}
		3) Signature (Encode/NOT Decode: HMAC SHA256)
			= Header + "." + Payload + secrect_key
#Rule of SecrectKey in Project
	+ At least 16 characters because of SymmetricSecurityKey func.
#Supporting classes of Microsoft provide APIs: 
	+ UserManager<TUSER>, SignInManager<TUSER>

#Fluent Validation (Another way of DataAnotation: [Required], [MinLength(10), ...])
	1) Install package: "FluentValidation.AspNetCore"
	2) Meaning:
		+ FluentValidation is a server-side framework.
		+ Does not provide any client-side validation DIRECTLY.
		=> However: NotNull/NotEmpty, Length (Min/Max), ... can generated as meta data 
		and used such as JQuery Validate
	3) Implement:
		+ A new validator class inherrit "AbstractValidator<LoginRequestDto>"
		+ Write everything inside CONSTRUCTOR
		+ Config rule: RuleFor(x => x.Id)....
		+ Declare DI in Startup file
	4) Disadvantaged:
		+ Display multi message at the same time. Have to custom with "If clause" (Similar to DataAnotation)
	5) Advantaged:
		+ Seperate validations from structure code of DTO
		+ Easy ti maintain

# Route vs [HttpGet/Post]
	- Similar: Both are routing URL
	- Difference:
		1) Route
			+ Not Specify HttpVerb, don't know get/post/put...
			+ Often used in Controller name to define BASE URL (Another type: RoutePrefix)
			+ Can be used both ControllerName, ActionName
		2) Http Attribute
			+ Specify action Http: Get/Post/Put...
			+ Only used in ActionName
	- ERROR when using:

		1) "/User/Login" => Will Not Found
		EX:
			public class UserController : Controller
			{
				[HttpGet("Login")]
				public IActionResult Login()
				{
					return View();
				}
			}

		==>> FIXED - first way)

			[Route("User")]
			public class UserController : Controller
			{
				[HttpGet("Login")]
				public IActionResult Login()
				{
					return View();
				}
			}
			
		==>> FIXED - second way)
		
			public class UserController : Controller
			{
				[HttpGet]
				public IActionResult Login()
				{
					return View();
				}
			}

# SOApiHelper
	- A base class with functions that help call to Backend_Api. Instead of writing agains everytime in every function.
	- Why need to pass IHttpClientFactory variable, instead of declaring a variable in SOApiHelper
		=> because it is initialized by DI mechanism of .NetCore
	- Every request except AnonymousRequets need a Token (type JWT) to Identify user.

# LoginController. Why need to seperate Login from UserControlelr ?
	1) I need to get Token to call Backend-API request
		=> To do that I override OnActionExecuting to check Token and use it as a BaseController.
	2) If Login and User are in a same Controller, the Login request will run into the BaseControler.
		=> infinity loop will happen
	3) LoginController don't use BaseController

# SystemContst
	- Contain system_value
	- NOT save Token in Static variable because of every Token is different between Users 
