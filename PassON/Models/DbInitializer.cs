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
                dbContext.Categories.AddRange();
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
