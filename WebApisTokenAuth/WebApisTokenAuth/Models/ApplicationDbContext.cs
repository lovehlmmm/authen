using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApisTokenAuth.Models
{
    public class ApplicationDbContexts
    {
        testauthenEntities db = new testauthenEntities();
        public testauthenEntities ApplicationDbContext { get { return db; } }

    }
}