using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReqSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReqSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AcademicProgram> AcademicPrograms { get; set; }
        public DbSet<Department> Addresses { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<FileAttachment> FileAttachments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<ReqUser> ReqUsers { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<StateContract> StateContracts { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<ReqSystem.Models.Address> Address { get; set; }
        public DbSet<ReqSystem.Models.CompetingItem> CompetingItem { get; set; }


    }
}
