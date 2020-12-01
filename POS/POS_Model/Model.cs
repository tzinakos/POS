using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace POS_Model
{
    public class PosContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=Jino; Initial Catalog=Pos;");
    }

    public class Category
    {

    }

    public class User
    {

    }

    public class UserRole
    {

    }


}
