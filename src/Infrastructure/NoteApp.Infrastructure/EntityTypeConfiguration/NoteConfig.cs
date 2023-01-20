using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NoteApp.Infrastructure.EntityTypeConfiguration
{
    public class NoteConfig : BaseEntityConfig<Note>
    {
        public override void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);

            builder.HasMany(x => x.SubNotes)
                .WithOne(x => x.MainNote)
                .HasForeignKey(x => x.MainNoteId)
                .OnDelete(DeleteBehavior.Restrict);

            //İstediğiniz diğer mappingler yapılabilir


            base.Configure(builder);
        }
    }
}
