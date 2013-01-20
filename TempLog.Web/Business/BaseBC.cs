using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TempLog.Web.Data;

namespace TempLog.Web.Business
{
    public abstract class BaseBC
    {
        public TempLogContext DbContext { get; set; }

        public BaseBC()
        {
            DbContext = new TempLogContext();
        }
    }
}