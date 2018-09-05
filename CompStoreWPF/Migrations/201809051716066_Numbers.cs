namespace CompStoreWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Numbers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "NumOfCase", c => c.Int(nullable: false));
            AddColumn("dbo.HardDisks", "NumOfHardDisk", c => c.Int(nullable: false));
            AddColumn("dbo.Monitors", "NumOfMonitor", c => c.Int(nullable: false));
            AddColumn("dbo.Motherboards", "NumOfMotherboard", c => c.Int(nullable: false));
            AddColumn("dbo.Processors", "NumOfProcessor", c => c.Int(nullable: false));
            AddColumn("dbo.RAMs", "NumOfRam", c => c.Int(nullable: false));
            AddColumn("dbo.VideoCards", "NumOfVideoCard", c => c.Int(nullable: false));
            AlterColumn("dbo.Cases", "CaseName", c => c.String(maxLength: 50));
            AlterColumn("dbo.HardDisks", "HardDiskName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Monitors", "MonitorName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Motherboards", "MotherboardName", c => c.String(maxLength: 50));
            AlterColumn("dbo.RAMs", "RAMName", c => c.String(maxLength: 50));
            AlterColumn("dbo.VideoCards", "VideoCardName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VideoCards", "VideoCardName", c => c.String());
            AlterColumn("dbo.RAMs", "RAMName", c => c.String());
            AlterColumn("dbo.Motherboards", "MotherboardName", c => c.String());
            AlterColumn("dbo.Monitors", "MonitorName", c => c.String());
            AlterColumn("dbo.HardDisks", "HardDiskName", c => c.String());
            AlterColumn("dbo.Cases", "CaseName", c => c.String());
            DropColumn("dbo.VideoCards", "NumOfVideoCard");
            DropColumn("dbo.RAMs", "NumOfRam");
            DropColumn("dbo.Processors", "NumOfProcessor");
            DropColumn("dbo.Motherboards", "NumOfMotherboard");
            DropColumn("dbo.Monitors", "NumOfMonitor");
            DropColumn("dbo.HardDisks", "NumOfHardDisk");
            DropColumn("dbo.Cases", "NumOfCase");
        }
    }
}
