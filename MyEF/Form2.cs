using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyEF.Entities;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MyEF
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnBindGrid_Click(object sender, EventArgs e)
        {
            Form1 frm = new MyEF.Form1();
            frm.ShowDialog();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (var context = new BloggingContext())
            {
                //add
                var blog1 = new Blog { Name = "ADO.NET Blog" };
                context.Blogs.Add(blog1);
                context.SaveChanges();

                //state
                var blog2 = new Blog { Name = "My Blog" };
                context.Entry(blog2).State = EntityState.Added;
                context.SaveChanges();

                // Add a new User by setting a reference from a tracked Blog
                var blog3 = context.Blogs.Find(2);
                var blog3post = new Post { Title = "entity-framework" };
                try
                {
                    // Add a new Post by adding to the collection of a tracked Blog
                    blog3.Posts.Add(blog3post);

                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    var errors = ex.EntityValidationErrors.ToList();
                    var errMsgs = errors.SelectMany(m => m.ValidationErrors).Select(x => x.ErrorMessage).ToList();
                    blog3post.Content = "add a required content";
                    context.SaveChanges();
                }


                //Disabling automatic detection of changes

                //If you are tracking a lot of entities in your context and you call one of these methods many times in a loop, 
                //then you may get significant performance improvements by turning off detection of changes for the duration of the loop.

                var aLotOfBlogs = new List<Blog>();
                aLotOfBlogs.Add(new Blog { Name = "Blog1" });
                aLotOfBlogs.Add(new Blog { Name = "Blog2" });
                aLotOfBlogs.Add(new Blog { Name = "Blog3" });
                try
                {
                    // turn off detection of changes 
                    context.Configuration.AutoDetectChangesEnabled = false;

                    // Make many calls in a loop
                    foreach (var blog in aLotOfBlogs)
                    {
                        context.Blogs.Add(blog);
                    }
                }
                finally
                {
                    context.Configuration.AutoDetectChangesEnabled = true;
                }

                context.SaveChanges();
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            using (var context = new BloggingContext())
            {
                // Query for all blogs with names starting with B
                var blogs = from b in context.Blogs
                            where b.Name.StartsWith("M")
                            select b;

                // Query for the Blog named ADO.NET Blog
                var blog1 = context.Blogs
                                .Where(b => b.Name == "ADO.NET Blog")
                                .FirstOrDefault();



                // Will hit the database
                var blog2 = context.Blogs.Find(3);

                // Will return the same instance without hitting the database
                var blogAgain = context.Blogs.Find(3);

                context.Blogs.Add(new Blog { BlogId = -1 });

                // Will find the new blog even though it does not exist in the database
                var newBlog = context.Blogs.Find(-1);

                // Will find a Post which has a int primary key
                var post = context.Posts.Find(2);



                //Sometimes you may want to get entities back from a query but not have those entities be tracked by the context.
                //This may result in better performance when querying for large numbers of entities in read - only scenarios.
                //A new extension method AsNoTracking allows any query to be run in this way.For example:

                // Query for all blogs without tracking them
                var blogs1 = context.Blogs.AsNoTracking();

                // Query for some blogs without tracking them
                var blogs2 = context.Blogs
                                    .Where(b => b.Name.Contains(".NET"))
                                    .AsNoTracking()
                                    .ToList();



                //The SqlQuery method on DbSet allows a raw SQL query to be written that will return entity instances.
                //The returned objects will be tracked by the context just as they would be if they were returned by a LINQ query.
                var blogs3 = context.Blogs.SqlQuery("SELECT * FROM dbo.Blogs").ToList();


                //You can use DbSet.SqlQuery to load entities from the results of a stored procedure. 
                //var blogs = context.Blogs.SqlQuery("dbo.GetBlogs").ToList();


                //A SQL query returning instances of any type, including primitive types, 
                //can be created using the SqlQuery method on the Database class
                var blogNames = context.Database.SqlQuery<string>(
                           "SELECT Name FROM dbo.Blogs").ToList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var context = new BloggingContext())
            {
                //Non-query commands can be sent to the database using the ExecuteSqlCommand method on Database
                context.Database.ExecuteSqlCommand(
                        "UPDATE dbo.Blogs SET Name = 'Another Name' WHERE BlogId = 1");



                var blog1 = context.Blogs.Find(3);

                // Read the current value of the Name property
                string currentName1 = context.Entry(blog1).Property(u => u.Name).CurrentValue;

                // Set the Name property to a new value
                //Setting the property value like this will only mark the property as modified if the new value is different from the old value.
                //When a property value is set in this way the change is automatically detected even if AutoDetectChanges is turned off.
                context.Entry(blog1).Property(u => u.Name).CurrentValue = "My Fancy Blog";

                // Read the current value of the Name property using a string for the property name
                object currentName2 = context.Entry(blog1).Property("Name").CurrentValue;

                // Set the Name property to a new value using a string for the property name
                context.Entry(blog1).Property("Name").CurrentValue = "My Boring Blog " + DateTime.Now.ToShortTimeString();

                var nameIsModified1 = context.Entry(blog1).Property(u => u.Name).IsModified;
                var idIsModified1 = context.Entry(blog1).Property(u => u.BlogId).IsModified;

                // Use a string for the property name
                var nameIsModified2 = context.Entry(blog1).Property("Name").IsModified;

                context.SaveChanges();




                //The example below shows how to read the current values, the original values, 
                //and the values actually in the database for all mapped properties of an entity

                //The current values are the values that the properties of the entity currently contain. 
                //The original values are the values that were read from the database when the entity was queried. 
                //The database values are the values as they are currently stored in the database. 
                //Getting the database values is useful when the values in the database may have changed 
                //since the entity was queried such as when a concurrent edit to the database has been made by another user
                var blog2 = context.Blogs.Find(1);

                var org1 = context.Entry(blog2).OriginalValues["Name"];//Another Name
                var orgBlog = new Blog { BlogId = 1, Name = "new org blog" };
                //The current or original values of a tracked entity can be updated by copying values from another objec
                context.Entry(blog2).OriginalValues.SetValues(orgBlog);

                // Make a modification to Name in the tracked entity
                blog2.Name = "My Cool Blog";

                // Make a modification to Name in the database
                context.Database.ExecuteSqlCommand("update dbo.Blogs set Name = 'My Boring Blog' where BlogId = 1");

                var cur = context.Entry(blog2).CurrentValues["Name"];//My Cool Blog
                var org2 = context.Entry(blog2).OriginalValues["Name"];//new org blog
                var db = context.Entry(blog2).GetDatabaseValues()["Name"];//My Boring Blog

                //The DbPropertyValues object returned from CurrentValues, OriginalValues, or GetDatabaseValues 
                //can be used to create a clone of the entity. 
                //This clone will contain the property values from the DbPropertyValues object used to create it.
                var clonedBlog = context.Entry(blog2).GetDatabaseValues().ToObject();

                //Sometimes it may be easier to use instances of your entity type for this. 
                var databaseValuesAsBlog = (Blog)context.Entry(blog2).GetDatabaseValues().ToObject();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnLazyLoading_Click(object sender, EventArgs e)
        {
            using (var context = new BloggingContext())
            {
                //Entity Framework supports three ways to load related data - eager loading, lazy loading and explicit loading. 

                //Lazy Loading

                //Lazy loading is the process whereby an entity or collection of entities is automatically loaded from the database 
                //the first time that a property referring to the entity/ entities is accessed.
                var blog6 = context.Blogs.Find(1);

                //Lazy loading can be turned off for all entities in the context by setting a flag on the Configuration property.
                //context.Configuration.LazyLoadingEnabled = false;

                //the related Posts will be loaded the first time the Posts navigation property is accessed:
                var blog6posts = blog6.Posts;


                //azy loading and serialization don’t mix well,
                //It’s a good practice to turn lazy loading off before you serialize an entity.

                //Lazy loading of the Posts collection can be turned off by making the Posts property non-virtual:
                //like: public ICollection<Post> Posts { get; set; } 
            }
        }

        private void btnExplicitLoading_Click(object sender, EventArgs e)
        {
            using (var context = new BloggingContext())
            {
                //Entity Framework supports three ways to load related data - eager loading, lazy loading and explicit loading. 

                //Explicitly Loading
                //Even with lazy loading disabled it is still possible to lazily load related entities, 
                //but it must be done with an explicit call.
                //To do so you use the Load method on the related entity’s entry.

                var post2 = context.Posts.Find(1);

                // Load the blog related to a given post.
                context.Entry(post2).Reference(p => p.Blog).Load();

                // Load the blog related to a given post using a string.
                context.Entry(post2).Reference("Blog").Load();

                var blog7 = context.Blogs.Find(1);

                // Load the posts related to a given blog.
                context.Entry(blog7).Collection(p => p.Posts).Load();

                // Load the posts related to a given blog
                // using a string to specify the relationship.
                context.Entry(blog7).Collection("Posts").Load();


                var blog = context.Blogs.Find(2);

                // Load the posts with the 'entity-framework' tag related to a given blog.
                var xx = context.Entry(blog)
                        .Collection(b => b.Posts)
                        .Query()
                        .Where(p => p.Title == "entity-framework")
                        .ToList();

                // Load the posts with the 'entity-framework' tag related to a given blog
                // using a string to specify the relationship.
                context.Entry(blog)
                       .Collection<Post>("Posts")
                       .Query()
                       .Where(p => p.Title.Contains("How"))
                       .Load();//?????

                // Count how many posts the blog has.
                var postCount = context.Entry(blog)
                                       .Collection(b => b.Posts)
                                       .Query()
                                       .Count();
            }
        }

        private void btnEagerLoading_Click(object sender, EventArgs e)
        {
            using (var context = new BloggingContext())
            {
                //Entity Framework supports three ways to load related data - eager loading, lazy loading and explicit loading. 

                //Eagerly Loading
                //Eager loading is the process whereby a query for one type of entity also loads related entities as part of the query.
                //Eager loading is achieved by use of the Include method.For example, 
                //the queries below will load blogs and all the posts related to each blog.

                // Load all blogs and related posts.
                var blogs4 = context.Blogs
                                    .Include(b => b.Posts)
                                    .ToList();

                // Load one blog and its related posts.
                var blog4 = context.Blogs
                                   .Where(b => b.BlogId == 1)
                                   .Include(b => b.Posts)
                                   .FirstOrDefault();

                // Load all blogs and related posts
                // using a string to specify the relationship.
                var blogs5 = context.Blogs
                                    .Include("Posts")
                                    .ToList();

                // Load one blog and its related posts
                // using a string to specify the relationship.
                var blog5 = context.Blogs
                                   .Where(b => b.BlogId == 1)
                                   .Include("Posts")
                                   .FirstOrDefault();
            }
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            //Starting with EF6 the framework now provides:

            //Database.BeginTransaction()
            //An easier method for a user to start and complete transactions themselves within an existing DbContext 
            //– allowing several operations to be combined within the same transaction and hence either all committed or all rolled back as one.
            //It also allows the user to more easily specify the isolation level for the transaction.

            using (var context = new BloggingContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand(
                        @"UPDATE Blogs SET Name = 'Entity blog'" +
                            " WHERE Name ='My Boring Blog' "
                        );

                    var query = context.Posts.Where(p => p.Blog.Name == "Entity blog");
                    foreach (var post in query)
                    {
                        post.Title += "[Cool Blog]";
                    }

                    context.SaveChanges();

                    dbContextTransaction.Commit();
                }
            }

            //Database.UseTransaction()
            //which allows the DbContext to use a transaction which was started outside of the Entity Framework.

        }
    }
}