using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hozor.DataLayer.Models
{
    public partial class Hozor_DBContext : DbContext
    {
        public Hozor_DBContext()
        {
        }

        public Hozor_DBContext(DbContextOptions<Hozor_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CAudits> CAudits { get; set; }
        public virtual DbSet<CAuditTrailFactorys> CAuditTrailFactorys { get; set; }
        public virtual DbSet<CEmployees> CEmployees { get; set; }
        public virtual DbSet<CompanyPropertis> CompanyPropertis { get; set; }
        public virtual DbSet<CRoleAccesses> CRoleAccesses { get; set; }
        public virtual DbSet<CRoles> CRoles { get; set; }
        public virtual DbSet<CSections> CSections { get; set; }
        public virtual DbSet<CSentryLocations> CSentryLocations { get; set; }
        public virtual DbSet<CUsers> CUsers { get; set; }
        public virtual DbSet<CUsersRoles> CUsersRoles { get; set; }
        public virtual DbSet<CWorkFlows> CWorkFlows { get; set; }
        public virtual DbSet<EventCarKilometers> EventCarKilometers { get; set; }
        public virtual DbSet<EventControlLoadings> EventControlLoadings { get; set; }
        public virtual DbSet<EventControlLooks> EventControlLooks { get; set; }
        public virtual DbSet<EventControlServices> EventControlServices { get; set; }
        public virtual DbSet<EventControlWorkNighits> EventControlWorkNighits { get; set; }
        public virtual DbSet<EventEventList> EventEventList { get; set; }
        public virtual DbSet<EventEventOthers> EventEventOthers { get; set; }
        public virtual DbSet<EventGuardLists> EventGuardLists { get; set; }
        public virtual DbSet<EventGuardPositions> EventGuardPositions { get; set; }
        public virtual DbSet<EventGuardShift> EventGuardShift { get; set; }
        public virtual DbSet<EventGuardStatus> EventGuardStatus { get; set; }
        public virtual DbSet<EventInspects> EventInspects { get; set; }
        public virtual DbSet<EventLookPositions> EventLookPositions { get; set; }
        public virtual DbSet<EventObjectDeliverys> EventObjectDeliverys { get; set; }
        public virtual DbSet<EventObjects> EventObjects { get; set; }
        public virtual DbSet<EventPatrol> EventPatrol { get; set; }
        public virtual DbSet<EventShiftDeliveryes> EventShiftDeliveryes { get; set; }
        public virtual DbSet<EventShiftHead> EventShiftHead { get; set; }
        public virtual DbSet<EventShiftName> EventShiftName { get; set; }
        public virtual DbSet<EventShifts> EventShifts { get; set; }
        public virtual DbSet<PoBillOfLodings> PoBillOfLodings { get; set; }
        public virtual DbSet<PoBlmachines> PoBlmachines { get; set; }
        public virtual DbSet<PoProductExit> PoProductExit { get; set; }
        public virtual DbSet<PoProducts> PoProducts { get; set; }
        public virtual DbSet<TcAgencyes> TcAgencyes { get; set; }
        public virtual DbSet<TcAgencyTraffics> TcAgencyTraffics { get; set; }
        public virtual DbSet<TcCargoTransports> TcCargoTransports { get; set; }
        public virtual DbSet<TcCargoTransportTraffics> TcCargoTransportTraffics { get; set; }
        public virtual DbSet<TcCompanys> TcCompanys { get; set; }
        public virtual DbSet<TcCompanyTraffics> TcCompanyTraffics { get; set; }
        public virtual DbSet<TcComrades> TcComrades { get; set; }
        public virtual DbSet<TcOthers> TcOthers { get; set; }
        public virtual DbSet<TcOtherTraffics> TcOtherTraffics { get; set; }
        public virtual DbSet<TcTrafficCars> TcTrafficCars { get; set; }
        public virtual DbSet<TeCar> TeCar { get; set; }
        public virtual DbSet<TeDate> TeDate { get; set; }
        public virtual DbSet<TeTraffic> TeTraffic { get; set; }
        public virtual DbSet<TmEmployeeMeetings> TmEmployeeMeetings { get; set; }
        public virtual DbSet<TmVisitorMeetings> TmVisitorMeetings { get; set; }
        public virtual DbSet<TvVisitorComrades> TvVisitorComrades { get; set; }
        public virtual DbSet<TvVisitors> TvVisitors { get; set; }
        public virtual DbSet<TvVisitorTraffic> TvVisitorTraffic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=Hozor_DB; User id=sa;Password=25101387");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CAudits>(entity =>
            {
                entity.ToTable("C_Audits");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(150);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(250);
            });

            modelBuilder.Entity<CAuditTrailFactorys>(entity =>
            {
                entity.ToTable("C_AuditTrailFactorys");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IpAddress).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CEmployees>(entity =>
            {
                entity.ToTable("C_Employees");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FerstName).HasMaxLength(100);

                entity.Property(e => e.ImageName).HasMaxLength(100);

                entity.Property(e => e.Job).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.Property(e => e.Section).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<CompanyPropertis>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyName).HasMaxLength(200);

                entity.Property(e => e.Logo).HasMaxLength(200);

                entity.Property(e => e.StartMessage).HasMaxLength(250);
            });

            modelBuilder.Entity<CRoleAccesses>(entity =>
            {
                entity.ToTable("C_RoleAccesses");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Controller)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.CRoleAccesses)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_C_RoleAccesses_C_Roles");
            });

            modelBuilder.Entity<CRoles>(entity =>
            {
                entity.ToTable("C_Roles");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RoleTitle)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<CSections>(entity =>
            {
                entity.ToTable("C_Sections");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CSentryLocations>(entity =>
            {
                entity.ToTable("C_SentryLocations");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Slname)
                    .HasColumnName("SLName")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CUsers>(entity =>
            {
                entity.ToTable("C_Users");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<CUsersRoles>(entity =>
            {
                entity.ToTable("C_UsersRoles");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<CWorkFlows>(entity =>
            {
                entity.ToTable("C_WorkFlows");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

                entity.Property(e => e.ApprovalUserName).HasMaxLength(100);

                entity.Property(e => e.ConfirmDate).HasColumnType("datetime");

                entity.Property(e => e.ConfirmUserName).HasMaxLength(100);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.SentryLocation).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.Property(e => e.WorkFlowClass).HasMaxLength(150);

                entity.Property(e => e.WriteDate).HasColumnType("datetime");

                entity.Property(e => e.WriteUserName).HasMaxLength(100);
            });

            modelBuilder.Entity<EventCarKilometers>(entity =>
            {
                entity.ToTable("Event_CarKilometers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarCompanyId).HasColumnName("CarCompanyID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.CarCompany)
                    .WithMany(p => p.EventCarKilometers)
                    .HasForeignKey(d => d.CarCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_CarKilometers_TC_Companys");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EventCarKilometers)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_CarKilometers_Event_Shifts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventCarKilometers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Event_CarKilometers_C_Users");
            });

            modelBuilder.Entity<EventControlLoadings>(entity =>
            {
                entity.ToTable("Event_ControlLoadings");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.LoadingPosition).HasMaxLength(100);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EventControlLoadings)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ControlLoadings_C_Employees");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EventControlLoadings)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ControlLoadings_Event_Shifts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventControlLoadings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ControlLoadings_C_Users");
            });

            modelBuilder.Entity<EventControlLooks>(entity =>
            {
                entity.ToTable("Event_ControlLooks");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.LookPositionId).HasColumnName("LookPositionID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EventControlLooks)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ControlLooks_C_Employees");

                entity.HasOne(d => d.LookPosition)
                    .WithMany(p => p.EventControlLooks)
                    .HasForeignKey(d => d.LookPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ControlLooks_Event_LookPositions");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EventControlLooks)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ControlLooks_Event_Shifts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventControlLooks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ControlLooks_C_Users");
            });

            modelBuilder.Entity<EventControlServices>(entity =>
            {
                entity.ToTable("Event_ControlServices");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EventControlServices)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ControlServices_C_Employees");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EventControlServices)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ControlServices_Event_Shifts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventControlServices)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ControlServices_C_Users");
            });

            modelBuilder.Entity<EventControlWorkNighits>(entity =>
            {
                entity.ToTable("Event_ControlWorkNighits");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EventControlWorkNighits)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ControlWorkNighits_C_Employees");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EventControlWorkNighits)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ControlWorkNighits_Event_Shifts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventControlWorkNighits)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ControlWorkNighits_C_Users");
            });

            modelBuilder.Entity<EventEventList>(entity =>
            {
                entity.ToTable("Event_EventList");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Titel).HasMaxLength(200);
            });

            modelBuilder.Entity<EventEventOthers>(entity =>
            {
                entity.ToTable("Event_EventOthers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.Titel).HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EventEventOthers)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_EventOthers_Event_Shifts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventEventOthers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_EventOthers_C_Users");
            });

            modelBuilder.Entity<EventGuardLists>(entity =>
            {
                entity.ToTable("Event_GuardLists");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.GuardPositionId).HasColumnName("GuardPositionID");

                entity.Property(e => e.Pas).HasMaxLength(50);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EventGuardLists)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_GuardLists_C_Employees");

                entity.HasOne(d => d.GuardPosition)
                    .WithMany(p => p.EventGuardLists)
                    .HasForeignKey(d => d.GuardPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_GuardLists_Event_GuardLists");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EventGuardLists)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_GuardLists_Event_Shifts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventGuardLists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_GuardLists_C_Users");
            });

            modelBuilder.Entity<EventGuardPositions>(entity =>
            {
                entity.ToTable("Event_GuardPositions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<EventGuardShift>(entity =>
            {
                entity.ToTable("Event_GuardShift");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Job).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber1).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber2).HasMaxLength(50);

                entity.Property(e => e.ShiftNameId).HasColumnName("ShiftNameID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EventGuardShift)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_GuardShift_C_Employees");

                entity.HasOne(d => d.ShiftName)
                    .WithMany(p => p.EventGuardShift)
                    .HasForeignKey(d => d.ShiftNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_GuardShift_Event_ShiftName");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventGuardShift)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_GuardShift_C_Users");
            });

            modelBuilder.Entity<EventGuardStatus>(entity =>
            {
                entity.ToTable("Event_GuardStatus");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.Titel).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EventGuardStatus)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_GuardStatus_C_Employees");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EventGuardStatus)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_GuardStatus_Event_Shifts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventGuardStatus)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_GuardStatus_C_Users");
            });

            modelBuilder.Entity<EventInspects>(entity =>
            {
                entity.ToTable("Event_Inspects");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Belonging1).HasMaxLength(200);

                entity.Property(e => e.Belonging2).HasMaxLength(200);

                entity.Property(e => e.Belonging3).HasMaxLength(200);

                entity.Property(e => e.Bodily1).HasMaxLength(200);

                entity.Property(e => e.Bodily2).HasMaxLength(200);

                entity.Property(e => e.Bodily3).HasMaxLength(200);

                entity.Property(e => e.Bodily4).HasMaxLength(200);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EventInspects)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Inspects_Event_Shifts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventInspects)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Inspects_Event_Inspects");
            });

            modelBuilder.Entity<EventLookPositions>(entity =>
            {
                entity.ToTable("Event_LookPositions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LookPosition)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EventObjectDeliverys>(entity =>
            {
                entity.ToTable("Event_ObjectDeliverys");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

                entity.Property(e => e.ShiftDeliveryId).HasColumnName("ShiftDeliveryID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.EventObjectDeliverys)
                    .HasForeignKey(d => d.ObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ObjectDeliverys_Event_Objects");

                entity.HasOne(d => d.ShiftDelivery)
                    .WithMany(p => p.EventObjectDeliverys)
                    .HasForeignKey(d => d.ShiftDeliveryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ObjectDeliverys_Event_ShiftDeliveryes");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EventObjectDeliverys)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_ObjectDeliverys_Event_Shifts");
            });

            modelBuilder.Entity<EventObjects>(entity =>
            {
                entity.ToTable("Event_Objects");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ObjectName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<EventPatrol>(entity =>
            {
                entity.ToTable("Event_Patrol");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PatrolPosition)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EventPatrol)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Patrol_C_Employees");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EventPatrol)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Patrol_Event_Shifts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventPatrol)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Patrol_C_Users");
            });

            modelBuilder.Entity<EventShiftDeliveryes>(entity =>
            {
                entity.ToTable("Event_ShiftDeliveryes");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Delivery).HasMaxLength(150);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.Transferee).HasMaxLength(150);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EventShiftDeliveryes)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_Event_ShiftDeliveryes_Event_Shifts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventShiftDeliveryes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Event_ShiftDeliveryes_C_Users");
            });

            modelBuilder.Entity<EventShiftHead>(entity =>
            {
                entity.ToTable("Event_ShiftHead");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ShiftHed)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<EventShiftName>(entity =>
            {
                entity.ToTable("Event_ShiftName");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EventShifts>(entity =>
            {
                entity.ToTable("Event_Shifts");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ShiftHeadId).HasColumnName("ShiftHeadID");

                entity.Property(e => e.ShiftNameId).HasColumnName("ShiftNameID");

                entity.Property(e => e.WorkFlowId).HasColumnName("WorkFlowID");

                entity.HasOne(d => d.ShiftHead)
                    .WithMany(p => p.EventShifts)
                    .HasForeignKey(d => d.ShiftHeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Shifts_Event_ShiftHead");

                entity.HasOne(d => d.ShiftName)
                    .WithMany(p => p.EventShifts)
                    .HasForeignKey(d => d.ShiftNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Shifts_Event_ShiftName");

                entity.HasOne(d => d.WorkFlow)
                    .WithMany(p => p.EventShifts)
                    .HasForeignKey(d => d.WorkFlowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Shifts_C_WorkFlows");
            });

            modelBuilder.Entity<PoBillOfLodings>(entity =>
            {
                entity.ToTable("PO_BillOfLodings");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BlmachinesId).HasColumnName("BLMachinesID");

                entity.Property(e => e.Blnumber)
                    .IsRequired()
                    .HasColumnName("BLNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.DateExportation).HasColumnType("datetime");

                entity.Property(e => e.DateOk)
                    .HasColumnName("DateOK")
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Blmachines)
                    .WithMany(p => p.PoBillOfLodings)
                    .HasForeignKey(d => d.BlmachinesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PO_BillOfLodings_PO_BLMachines");
            });

            modelBuilder.Entity<PoBlmachines>(entity =>
            {
                entity.ToTable("PO_BLMachines");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DriverName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.MachineName).HasMaxLength(150);

                entity.Property(e => e.MachineNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PoProductExit>(entity =>
            {
                entity.ToTable("PO_ProductExit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CardExitNum).HasMaxLength(20);

                entity.Property(e => e.ChassisNum).HasMaxLength(40);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Expellant).HasMaxLength(100);

                entity.Property(e => e.PlaqueNum).HasMaxLength(20);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.WorkFlowId).HasColumnName("WorkFlowID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PoProductExit)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PO_ProductExit_PO_Products");

                entity.HasOne(d => d.WorkFlow)
                    .WithMany(p => p.PoProductExit)
                    .HasForeignKey(d => d.WorkFlowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PO_ProductExit_C_WorkFlows");
            });

            modelBuilder.Entity<PoProducts>(entity =>
            {
                entity.ToTable("PO_Products");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DateStart).HasColumnType("datetime");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<TcAgencyes>(entity =>
            {
                entity.ToTable("TC_Agencyes");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarColor).HasMaxLength(50);

                entity.Property(e => e.CarName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CarNumber).HasMaxLength(20);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DriverFamily)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DriverName).HasMaxLength(50);

                entity.Property(e => e.DriverNationalId)
                    .HasColumnName("DriverNationalID")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TcAgencyTraffics>(entity =>
            {
                entity.ToTable("TC_AgencyTraffics");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.ArrivalDoor).HasMaxLength(50);

                entity.Property(e => e.ArrivalUserName).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Destination).HasMaxLength(100);

                entity.Property(e => e.ExitDoor).HasMaxLength(50);

                entity.Property(e => e.ExitUserName).HasMaxLength(50);

                entity.Property(e => e.TrafficCarId).HasColumnName("TrafficCarID");

                entity.Property(e => e.WorkFlowId).HasColumnName("WorkFlowID");

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.TcAgencyTraffics)
                    .HasForeignKey(d => d.AgencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_AgencyTraffics_TC_Agencyes");

                entity.HasOne(d => d.TrafficCar)
                    .WithMany(p => p.TcAgencyTraffics)
                    .HasForeignKey(d => d.TrafficCarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_AgencyTraffics_TC_TrafficCars");

                entity.HasOne(d => d.WorkFlow)
                    .WithMany(p => p.TcAgencyTraffics)
                    .HasForeignKey(d => d.WorkFlowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_AgencyTraffics_C_WorkFlows");
            });

            modelBuilder.Entity<TcCargoTransports>(entity =>
            {
                entity.ToTable("TC_CargoTransports");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CarNumber).HasMaxLength(20);

                entity.Property(e => e.DriverFamily)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DriverName).HasMaxLength(50);

                entity.Property(e => e.DriverNationalId)
                    .HasColumnName("DriverNationalID")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TcCargoTransportTraffics>(entity =>
            {
                entity.ToTable("TC_CargoTransportTraffics");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.ArrivalDoor).HasMaxLength(50);

                entity.Property(e => e.ArrivalUserName).HasMaxLength(50);

                entity.Property(e => e.CargoName).HasMaxLength(100);

                entity.Property(e => e.CargoTransportId).HasColumnName("CargoTransportID");

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.ExitDate).HasColumnType("date");

                entity.Property(e => e.ExitDoor).HasMaxLength(50);

                entity.Property(e => e.ExitUserName).HasMaxLength(50);

                entity.Property(e => e.TrafficCarId).HasColumnName("TrafficCarID");

                entity.Property(e => e.WorkFlowId).HasColumnName("WorkFlowID");

                entity.HasOne(d => d.CargoTransport)
                    .WithMany(p => p.TcCargoTransportTraffics)
                    .HasForeignKey(d => d.CargoTransportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_CargoTransportTraffics_TC_CargoTransports");

                entity.HasOne(d => d.TrafficCar)
                    .WithMany(p => p.TcCargoTransportTraffics)
                    .HasForeignKey(d => d.TrafficCarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_CargoTransportTraffics_TC_TrafficCars");

                entity.HasOne(d => d.WorkFlow)
                    .WithMany(p => p.TcCargoTransportTraffics)
                    .HasForeignKey(d => d.WorkFlowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_CargoTransportTraffics_C_WorkFlows");
            });

            modelBuilder.Entity<TcCompanys>(entity =>
            {
                entity.ToTable("TC_Companys");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarColor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CarName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CarNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Section)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TcCompanyTraffics>(entity =>
            {
                entity.ToTable("TC_CompanyTraffics");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.ArrivalDoor).HasMaxLength(50);

                entity.Property(e => e.ArrivalUserName).HasMaxLength(50);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Destination).HasMaxLength(100);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ExitDate).HasColumnType("date");

                entity.Property(e => e.ExitDoor).HasMaxLength(50);

                entity.Property(e => e.ExitUserName).HasMaxLength(50);

                entity.Property(e => e.TrafficCarId).HasColumnName("TrafficCarID");

                entity.Property(e => e.WorkFlowId).HasColumnName("WorkFlowID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TcCompanyTraffics)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_CompanyTraffics_TC_Companys");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TcCompanyTraffics)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_CompanyTraffics_C_Employees");

                entity.HasOne(d => d.TrafficCar)
                    .WithMany(p => p.TcCompanyTraffics)
                    .HasForeignKey(d => d.TrafficCarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_CompanyTraffics_TC_TrafficCars");

                entity.HasOne(d => d.WorkFlow)
                    .WithMany(p => p.TcCompanyTraffics)
                    .HasForeignKey(d => d.WorkFlowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_CompanyTraffics_C_WorkFlows");
            });

            modelBuilder.Entity<TcComrades>(entity =>
            {
                entity.ToTable("TC_Comrades");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ComradeFamily)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ComradeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ComradeSection)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.TrafficCarId).HasColumnName("TrafficCarID");

                entity.HasOne(d => d.TrafficCar)
                    .WithMany(p => p.TcComrades)
                    .HasForeignKey(d => d.TrafficCarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_Comrades_TC_TrafficCars");
            });

            modelBuilder.Entity<TcOthers>(entity =>
            {
                entity.ToTable("TC_Others");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CarNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Company).HasMaxLength(150);
            });

            modelBuilder.Entity<TcOtherTraffics>(entity =>
            {
                entity.ToTable("TC_OtherTraffics");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.ArrivalDoor).HasMaxLength(50);

                entity.Property(e => e.ArrivalDriverName).HasMaxLength(150);

                entity.Property(e => e.ArrivalDriverNationalId).HasMaxLength(12);

                entity.Property(e => e.ArrivalUserName).HasMaxLength(50);

                entity.Property(e => e.ExitDate).HasColumnType("date");

                entity.Property(e => e.ExitDoor).HasMaxLength(50);

                entity.Property(e => e.ExitDriverName).HasMaxLength(150);

                entity.Property(e => e.ExitDriverNationalId).HasMaxLength(12);

                entity.Property(e => e.ExitUserName).HasMaxLength(50);

                entity.Property(e => e.OtherId).HasColumnName("OtherID");

                entity.Property(e => e.TrafficCause).HasMaxLength(100);

                entity.Property(e => e.WorkFlowId).HasColumnName("WorkFlowID");

                entity.HasOne(d => d.Other)
                    .WithMany(p => p.TcOtherTraffics)
                    .HasForeignKey(d => d.OtherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_OtherTraffics_TC_Others");

                entity.HasOne(d => d.WorkFlow)
                    .WithMany(p => p.TcOtherTraffics)
                    .HasForeignKey(d => d.WorkFlowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_OtherTraffics_C_WorkFlows");
            });

            modelBuilder.Entity<TcTrafficCars>(entity =>
            {
                entity.ToTable("TC_TrafficCars");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<TeCar>(entity =>
            {
                entity.ToTable("TE_Car");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarClass)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CarNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TeDate>(entity =>
            {
                entity.HasKey(e => e.Date);

                entity.ToTable("TE_Date");

                entity.Property(e => e.Date)
                    .HasMaxLength(15)
                    .ValueGeneratedNever();

                entity.Property(e => e.Day)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MinthEnd)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.MonthStart)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.WeekEnd).HasMaxLength(15);

                entity.Property(e => e.WeekStart).HasMaxLength(15);

                entity.Property(e => e.YearEnd)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.YearStart)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<TeTraffic>(entity =>
            {
                entity.ToTable("TE_Traffic");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArrivalDoor1).HasMaxLength(100);

                entity.Property(e => e.ArrivalDoor2).HasMaxLength(100);

                entity.Property(e => e.ArrivalDoor3).HasMaxLength(100);

                entity.Property(e => e.ArrivalDoor4).HasMaxLength(100);

                entity.Property(e => e.ArrivalFinal).HasMaxLength(15);

                entity.Property(e => e.ArrivalTime1).HasMaxLength(15);

                entity.Property(e => e.ArrivalTime2).HasMaxLength(15);

                entity.Property(e => e.ArrivalTime3).HasMaxLength(15);

                entity.Property(e => e.ArrivalTime4).HasMaxLength(15);

                entity.Property(e => e.ArrivalTraffic1).HasMaxLength(20);

                entity.Property(e => e.ArrivalTraffic2).HasMaxLength(20);

                entity.Property(e => e.ArrivalTraffic3).HasMaxLength(20);

                entity.Property(e => e.ArrivalTraffic4).HasMaxLength(20);

                entity.Property(e => e.ArrivalTrafficFinal).HasMaxLength(20);

                entity.Property(e => e.ArrivalUser1).HasMaxLength(100);

                entity.Property(e => e.ArrivalUser2).HasMaxLength(100);

                entity.Property(e => e.ArrivalUser3).HasMaxLength(100);

                entity.Property(e => e.ArrivalUser4).HasMaxLength(100);

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ExitDoor1).HasMaxLength(100);

                entity.Property(e => e.ExitDoor2).HasMaxLength(100);

                entity.Property(e => e.ExitDoor3).HasMaxLength(100);

                entity.Property(e => e.ExitDoor4).HasMaxLength(100);

                entity.Property(e => e.ExitFinal).HasMaxLength(15);

                entity.Property(e => e.ExitReoprt1).HasMaxLength(15);

                entity.Property(e => e.ExitReoprt2).HasMaxLength(15);

                entity.Property(e => e.ExitReoprt3).HasMaxLength(15);

                entity.Property(e => e.ExitTime1).HasMaxLength(15);

                entity.Property(e => e.ExitTime2).HasMaxLength(15);

                entity.Property(e => e.ExitTime3).HasMaxLength(15);

                entity.Property(e => e.ExitTime4).HasMaxLength(15);

                entity.Property(e => e.ExitTraffic1).HasMaxLength(20);

                entity.Property(e => e.ExitTraffic2).HasMaxLength(20);

                entity.Property(e => e.ExitTraffic3).HasMaxLength(20);

                entity.Property(e => e.ExitTraffic4).HasMaxLength(20);

                entity.Property(e => e.ExitTrafficFinal).HasMaxLength(20);

                entity.Property(e => e.ExitUser1).HasMaxLength(100);

                entity.Property(e => e.ExitUser2).HasMaxLength(100);

                entity.Property(e => e.ExitUser3).HasMaxLength(100);

                entity.Property(e => e.ExitUser4).HasMaxLength(100);

                entity.Property(e => e.WorkFlowId).HasColumnName("WorkFlowID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.TeTraffic)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TE_Traffic_TE_Car");

                entity.HasOne(d => d.DateNavigation)
                    .WithMany(p => p.TeTraffic)
                    .HasForeignKey(d => d.Date)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TE_Traffic_TE_Date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TeTraffic)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TE_Traffic_C_Employees");
            });

            modelBuilder.Entity<TmEmployeeMeetings>(entity =>
            {
                entity.ToTable("TM_EmployeeMeetings");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EndUserName).HasMaxLength(100);

                entity.Property(e => e.HostId).HasColumnName("HostID");

                entity.Property(e => e.MeeterId).HasColumnName("MeeterID");

                entity.Property(e => e.StartUserName).HasMaxLength(100);

                entity.Property(e => e.WorkFlowId).HasColumnName("WorkFlowID");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.TmEmployeeMeetingsHost)
                    .HasForeignKey(d => d.HostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TM_EmploeeMeetings_C_Employees1");

                entity.HasOne(d => d.Meeter)
                    .WithMany(p => p.TmEmployeeMeetingsMeeter)
                    .HasForeignKey(d => d.MeeterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TM_EmploeeMeetings_C_Employees");

                entity.HasOne(d => d.WorkFlow)
                    .WithMany(p => p.TmEmployeeMeetings)
                    .HasForeignKey(d => d.WorkFlowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TM_EmploeeMeetings_C_WorkFlows");
            });

            modelBuilder.Entity<TmVisitorMeetings>(entity =>
            {
                entity.ToTable("TM_VisitorMeetings");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmploeeyId).HasColumnName("EmploeeyID");

                entity.Property(e => e.EndUserName).HasMaxLength(100);

                entity.Property(e => e.StartUserName).HasMaxLength(100);

                entity.Property(e => e.VisitorId).HasColumnName("VisitorID");

                entity.Property(e => e.WorkFlowId).HasColumnName("WorkFlowID");

                entity.HasOne(d => d.Emploeey)
                    .WithMany(p => p.TmVisitorMeetings)
                    .HasForeignKey(d => d.EmploeeyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TM_VisitorMeetings_C_Employees");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.TmVisitorMeetings)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TM_VisitorMeetings_TV_Visitors");

                entity.HasOne(d => d.WorkFlow)
                    .WithMany(p => p.TmVisitorMeetings)
                    .HasForeignKey(d => d.WorkFlowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TM_VisitorMeetings_C_WorkFlows");
            });

            modelBuilder.Entity<TvVisitorComrades>(entity =>
            {
                entity.ToTable("TV_VisitorComrades");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.NationalId).HasMaxLength(10);

                entity.Property(e => e.VisitorTrafficId).HasColumnName("VisitorTrafficID");

                entity.HasOne(d => d.VisitorTraffic)
                    .WithMany(p => p.TvVisitorComrades)
                    .HasForeignKey(d => d.VisitorTrafficId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TV_VisitorComrades_TV_VisitorComrades");
            });

            modelBuilder.Entity<TvVisitors>(entity =>
            {
                entity.ToTable("TV_Visitors");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Car).HasMaxLength(50);

                entity.Property(e => e.CarNumber).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.Family).HasMaxLength(100);

                entity.Property(e => e.Image).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NationalId)
                    .HasColumnName("NationalID")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TvVisitorTraffic>(entity =>
            {
                entity.ToTable("TV_VisitorTraffic");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.ArrivalDoor).HasMaxLength(50);

                entity.Property(e => e.ArrivalUserName).HasMaxLength(50);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ExitDate).HasColumnType("date");

                entity.Property(e => e.ExitDoor).HasMaxLength(50);

                entity.Property(e => e.ExitUserName).HasMaxLength(50);

                entity.Property(e => e.VisitorId).HasColumnName("VisitorID");

                entity.Property(e => e.WorkFlowId).HasColumnName("WorkFlowID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TvVisitorTraffic)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TV_VisitorTraffic_C_Employees");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.TvVisitorTraffic)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TV_VisitorTraffic_TV_Visitors");

                entity.HasOne(d => d.WorkFlow)
                    .WithMany(p => p.TvVisitorTraffic)
                    .HasForeignKey(d => d.WorkFlowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TV_VisitorTraffic_C_WorkFlows");
            });
        }
    }
}
