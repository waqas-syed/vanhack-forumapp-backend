﻿using System.Data.Entity.ModelConfiguration;
using ForumApp.Forum.Domain.Model.PostAggregate;

namespace ForumApp.Forum.Infrastructure.Persistence.FluentConfigurations
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            ToTable("comment");
            HasKey(x => x.Id);
            Property(x => x.AuthorEmail).IsRequired().HasMaxLength(100);
            Property(x => x.Text).IsRequired().HasMaxLength(2000);
            HasRequired<Post>(s => s.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId);
        }
    }
}
