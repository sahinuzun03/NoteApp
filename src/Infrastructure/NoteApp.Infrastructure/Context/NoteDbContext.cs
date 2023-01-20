using Microsoft.EntityFrameworkCore;
using NoteApp.Domain.Entities;
using NoteApp.Infrastructure.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Infrastructure.Context
{
    public class NoteDbContext :DbContext
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
