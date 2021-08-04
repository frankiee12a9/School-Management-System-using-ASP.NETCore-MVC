using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
	public class ApplicationDbContext : IdentityDbContext<AppUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}


		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<CourseAssignment> CourseAssigments { get; set; }
		public DbSet<Enrollment> CourseEnrollments { get; set; }
		public DbSet<CourseFileUpload> CourseFileUploads { get; set; }
		public DbSet<Department> Departments { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.HasDefaultSchema("Identity");


			builder.Entity<Department>().HasData(
				new Department { DepartmentID = 2201, DepartmentName = "Computer Science Dept"},
				new Department { DepartmentID = 2202, DepartmentName = "Mathematics Dept"},
				new Department { DepartmentID = 2203, DepartmentName = "Language and Trade Dept"}
			);

			builder.Entity<IdentityUser>(entity =>
			{
				entity.ToTable(name: "User");
			});

			builder.Entity<IdentityRole>(entity =>
			{
				entity.ToTable(name: "Role");
			});

			builder.Entity<IdentityUserRole<string>>(entity =>
			{
				entity.ToTable(name: "UserRoles");
			});

			builder.Entity<IdentityUserClaim<string>>(entity =>
			{
				entity.ToTable(name: "UserClaims");
			});

			builder.Entity<IdentityUserLogin<string>>(entity =>
			{
				entity.ToTable(name: "UserLogins");
			});

			builder.Entity<IdentityRoleClaim<string>>(entity =>
			{
				entity.ToTable(name: "RoleClaims");
			});

			builder.Entity<IdentityUserToken<string>>(entity =>
			{
				entity.ToTable(name: "UserTokens");
			});


			builder.Entity<CourseAssignment>()
				.HasKey(ca => new { ca.CourseId, ca.LecturerId });

			builder.Entity<CourseAssignment>()
				.HasOne(cu => cu.Course)
				.WithMany(c => c.CourseAssignments)
				.HasForeignKey(cu => cu.CourseId);

			builder.Entity<CourseAssignment>()
				.HasOne(cu => cu.Lecturer)
				.WithMany(u => u.CourseAssignments)
				.HasForeignKey(cu => cu.LecturerId);

			builder.Entity<Enrollment>()
				.HasKey(e => new { e.CourseId, e.StudentId });

			builder.Entity<Enrollment>()
				.HasOne(c => c.Course)
				.WithMany(e => e.Enrollments)
				.HasForeignKey(fk => fk.CourseId);

			builder.Entity<Enrollment>()
				.HasOne(s => s.Student)
				.WithMany(e => e.Enrollments)
				.HasForeignKey(fk => fk.StudentId);
		}
	}
}
