namespace CompStoreWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cases", "CaseName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.HardDisks", "HardDiskName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Monitors", "MonitorName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Motherboards", "MotherboardName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Processors", "ProcessorName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.RAMs", "RAMName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.VideoCards", "VideoCardName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VideoCards", "VideoCardName", c => c.String(maxLength: 50));
            AlterColumn("dbo.RAMs", "RAMName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Processors", "ProcessorName", c => c.String(maxLength: 40));
            AlterColumn("dbo.Motherboards", "MotherboardName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Monitors", "MonitorName", c => c.String(maxLength: 50));
            AlterColumn("dbo.HardDisks", "HardDiskName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Cases", "CaseName", c => c.String(maxLength: 50));
        }
    }
}
