using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLog.TdTool.Result;

namespace TempLog.TdTool
{
    public interface ITdToolClient
    {
        ListResult GetListResult(); // tdtool --list
    }
}
