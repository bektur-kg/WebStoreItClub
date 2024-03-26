using Microsoft.EntityFrameworkCore;
using Swagger.Model;
using WebStore.Model;

namespace WebStore
{
    /// <summary>
    /// Представляет контекст базы данных приложения.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Набор данных пользователей.
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<MainCategory> MainCategory { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<ShoppingCarts> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartProducts> ShoppingCartProducts { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Добавьте логгирование запросов EF
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Установка коллации для всех таблиц в базе данных
            modelBuilder.UseCollation("Latin1_General_100_CI_AS_SC_UTF8");

            // Указываем, что Id должен генерироваться при добавлении записи
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<SubCategory>()
                .HasOne(sc => sc.MainCategory)
                .WithMany(mc => mc.SubCategory)
                .HasForeignKey(sc => sc.MainCategoryId);

            modelBuilder.Entity<ShoppingCartProducts>()
                .HasKey(sp => new { sp.ShoppingCartId, sp.ProductId });

            modelBuilder.Entity<ShoppingCartProducts>()
                .HasOne(sp => sp.ShoppingCarts)
                .WithMany(sc => sc.ShoppingCartProducts)
                .HasForeignKey(sp => sp.ShoppingCartId);

            modelBuilder.Entity<ShoppingCartProducts>()
                .HasOne(sp => sp.Product)
                .WithMany(p => p.ShoppingCartProducts)
                .HasForeignKey(sp => sp.ProductId);


            modelBuilder.Entity<Product>()
                .HasOne(p => p.SubCategory)
                .WithMany(sc => sc.Product)
                .HasForeignKey(p => p.SubCategoryId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Reviews)  // Один продукт имеет много отзывов
                .WithOne(r => r.Product)  // Отзыв относится к одному продукту
                .HasForeignKey(r => r.ProductId)  // Внешний ключ в таблице Reviews
                .IsRequired(false); // Отзывы могут быть null

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ShoppingCartProducts)  // Один продукт может быть в нескольких корзинах
                .WithOne(sp => sp.Product)  // Каждый элемент корзины относится к одному продукту
                .HasForeignKey(sp => sp.ProductId)  // Внешний ключ в таблице ShoppingCartProducts
                .IsRequired(false);  // Элементы корзины могут быть null

        }
    }
}
