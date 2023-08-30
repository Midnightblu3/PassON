namespace PassON.Models
{
    public class DbInitializer
    {

        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            /**
             * use applicationBuilder to get access to Dbcontext
             */
            PassONDbContext dbContext = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PassONDbContext>();

            if (!dbContext.Categories.Any()){
                //add Categories here
                dbContext.Categories.AddRange( new Category { Name="Electronics", Description ="All kinds of electronics"},
                    new Category { Name= "Viehicle", Description="All kinds of cars"},
                    new Category {  Name="Home improvements", Description = "All kinds of stuff for your house" },
                    new Category {  Name="Tools", Description="All kinds of tools"},
                    new Category {  Name="Clothes", Description = "Filling your wardrobe" });
            }

            if (!dbContext.Items.Any())
            {
                //add Items here
                dbContext.Items.AddRange();

            }

            dbContext.SaveChanges();

        }
    }
}
