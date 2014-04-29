using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Web;
using BinarySearchTree.Web.Models.Query;

namespace BinarySearchTree.Web.DbContext
{
    public interface IBinarySearchTreeReadContext
    {
        IDbSet<BinarySearchTreeNodeQuery> BinarySearchTreeNodeQueries { get; set; }
    }

    public class BinarySearchTreeReadContext : System.Data.Entity.DbContext, IBinarySearchTreeReadContext
    {
        public IDbSet<BinarySearchTreeNodeQuery> BinarySearchTreeNodeQueries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BinarySearchTreeNodeQuery>().HasKey(model => model.Id);
            modelBuilder.Entity<BinarySearchTreeNodeQuery>().ToTable("v_Nodes");
            //modelBuilder.Entity<NonWorkDayMessage>().ToTable("NonWorkDay");
            //modelBuilder.Entity<NonWorkDayMessage>().HasKey(model => model.Id);


            //modelBuilder.Entity<LeadTimeQuery>().ToTable("v_LeadTime");
            //modelBuilder.Entity<LeadTimeQuery>().HasKey(model => model.Id);
            //modelBuilder.Entity<LeadTimeQuery>().Ignore(model => model.NonWorkDays);

            //modelBuilder.Entity<ItemQuery>().HasKey(model => model.ItemCode);
            //modelBuilder.Entity<ItemQuery>().ToTable("v_Item");
        }

        public override int SaveChanges()
        {
            throw new AccessViolationException("You cannot modify the readonly context.");
        }
    }
}