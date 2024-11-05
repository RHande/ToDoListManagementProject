using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Models.Entities;

namespace ToDoList.Repository.Configurations;

public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        builder.ToTable("ToDos").HasKey(t => t.Id);
        builder.Property(t=>t.Id).HasColumnName("ToDoId");
        builder.Property(t => t.Title).HasColumnName("Title");
        builder.Property(t => t.Description).HasColumnName("Description");
        builder.Property(t => t.StartDate).HasColumnName("StartDate");
        builder.Property(t => t.EndDate).HasColumnName("EndDate");
        builder.Property(t => t.Completed).HasColumnName("Completed");
        builder.Property(t => t.Priority).HasColumnName("Priority");
        builder.Property(t => t.CategoryId).HasColumnName("CategoryId");
        builder.Property(t => t.UserId).HasColumnName("UserId");
        builder.Property(t=>t.CreatedTime).HasColumnName("CreatedTime");
        builder.Property(t=>t.UpdatedTime).HasColumnName("UpdatedTime");
        
        builder.HasOne(t => t.Category).WithMany(c => c.ToDos).HasForeignKey(t => t.CategoryId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(t => t.User).WithMany(u => u.ToDos).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.NoAction);
        
        builder.Navigation(t => t.Category).AutoInclude();
        builder.Navigation(t => t.User).AutoInclude();
        
    }
}