namespace CompStoreWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        CaseId = c.Int(nullable: false, identity: true),
                        CaseName = c.String(),
                        CasePrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CaseId);
            
            CreateTable(
                "dbo.HardDisks",
                c => new
                    {
                        HardDiskId = c.Int(nullable: false, identity: true),
                        HardDiskName = c.String(),
                        HardDiskPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HardDiskId);
            
            CreateTable(
                "dbo.Monitors",
                c => new
                    {
                        MonitorId = c.Int(nullable: false, identity: true),
                        MonitorName = c.String(),
                        MonitorPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MonitorId);
            
            CreateTable(
                "dbo.Motherboards",
                c => new
                    {
                        MotherboardId = c.Int(nullable: false, identity: true),
                        MotherboardName = c.String(),
                        MotherboardPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MotherboardId);
            
            CreateTable(
                "dbo.Processors",
                c => new
                    {
                        ProcessorsId = c.Int(nullable: false, identity: true),
                        ProcessorName = c.String(maxLength: 40),
                        ProcessorPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProcessorsId);
            
            CreateTable(
                "dbo.RAMs",
                c => new
                    {
                        RAMId = c.Int(nullable: false, identity: true),
                        RAMName = c.String(),
                        RAMPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RAMId);
            
            CreateTable(
                "dbo.VideoCards",
                c => new
                    {
                        VideoCardId = c.Int(nullable: false, identity: true),
                        VideoCardName = c.String(),
                        VideoCardPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VideoCardId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VideoCards");
            DropTable("dbo.RAMs");
            DropTable("dbo.Processors");
            DropTable("dbo.Motherboards");
            DropTable("dbo.Monitors");
            DropTable("dbo.HardDisks");
            DropTable("dbo.Cases");
        }
    }
}
