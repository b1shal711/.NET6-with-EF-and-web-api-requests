namespace NavTech.Data
{
    public class DataContext :  DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<navTech> orderdb { get; set; }

    }
}
