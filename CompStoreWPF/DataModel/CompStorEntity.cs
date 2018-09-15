namespace CompStoreWPF.DataModel
{
    using System;
    using System.Data.Entity;
    
    using System.Linq;

    public class CompStorEntity : DbContext
    {
        // Your context has been configured to use a 'CompStorEntity' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CompStoreWPF.DataModel.CompStorEntity' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CompStorEntity' 
        // connection string in the application configuration file.
        //public CompStorEntity()
        //    : base("name=CompStorEntity")
        //{
        public CompStorEntity(string CompStorEntity)
            : base(CompStorEntity)
        {
        }

        public CompStorEntity()
            : base("name=CompStorEntity")
        {
        }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<HardDisk> HardDisks { get; set; }

        public virtual DbSet<Motherboard> Motherboards { get; set; }

        public virtual DbSet<Processor> Processors { get; set; }

        public virtual DbSet<RAM> RAMs { get; set; }

        public virtual DbSet<VideoCard> VideoCards { get; set; }

        public DbSet<Monitor> Monitors { get; set; }

    }

}