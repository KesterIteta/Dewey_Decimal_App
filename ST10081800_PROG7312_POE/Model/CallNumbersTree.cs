using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10081800_PROG7312_POE.Model
{
    public class CallNumbersTree
    {
        public List<CallNumberCategoryFirstLevel> categories { get; set; }
    }

    public class CallNumberCategoryFirstLevel
    {
        public string description { get; set; }
        public int code { get; set; }
        public List<CallNumberCategorySecondLevel> subcategories { get; set; }
    }

    public class CallNumberCategorySecondLevel
    {
        public string description { get; set; }
        public int code { get; set; }
        public List<CallNumberCategoryThirdLevel> subcategories { get; set; }
    }

    public class CallNumberCategoryThirdLevel
    {
        public string description { get; set; }
        public int code { get; set; }
    }
}
