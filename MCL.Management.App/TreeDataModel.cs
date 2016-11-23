using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCL.Management.App
{
    public class TreeDataModel
    {
        public string Text
        {
            get;
            set;
        }

        public List<TreeDataModel> Nodes
        {
            get;
            set;
        }
    }
}
