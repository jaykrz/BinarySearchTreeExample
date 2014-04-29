using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BinarySearchTree.Domain;
using NextDimension.GenericRepository;

namespace BinarySearchTree.Web.DbContext
{
    public interface IBinarySearchTreeDomainContext
    {
        IDbSet<Tree> Trees { get; set; }
        IDbSet<EventLog> Audit { get; set; }
    }

    public class BinarySearchTreeDomainContext : System.Data.Entity.DbContext, IBinarySearchTreeDomainContext
    {
        public IDbSet<Tree> Trees { get; set; }
        public IDbSet<EventLog> Audit { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tree>().HasKey(model => model.Id);
            modelBuilder.Entity<Tree>().ToTable("Tree");
            modelBuilder.Entity<Node>().HasKey(model => model.Id);
        }
    }
}