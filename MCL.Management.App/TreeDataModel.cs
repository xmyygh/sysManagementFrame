using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCL.Management.App
{
    public class TreeDataModel
    {
        public string id
        {
            get;
            set;
        }
        public string text
        {
            get;
            set;
        }

        public string parentId
        {
            get;
            set;
        }
        public List<TreeDataModel> nodes
        {
            get;
            set;
        }
    }
}
