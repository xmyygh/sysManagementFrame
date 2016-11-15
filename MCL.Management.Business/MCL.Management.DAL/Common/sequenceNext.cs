using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace MCL.Management.DAL
{
    public class sequenceNext
    {
        public object GetSequence(string _SequenceName)
        {
            string sbsql = " SELECT CURRENT_VALUE AS ID FROM SYSSEQUENCE WHERE NAME='" + _SequenceName + "'";
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), null);
            return _ScalarData;
        }

        public int UpdateSequence(string _SequenceName, string _CurrrntValue)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" UPDATE SYSSEQUENCE SET");
            sbsql.Append(" CURRENT_VALUE ='" + _CurrrntValue + "'");
            sbsql.Append(" WHERE NAME='" + _SequenceName + "'");
            int _UpdateRow = DbHelp.Execute(@sbsql.ToString(), null, null, null, System.Data.CommandType.Text);
            return _UpdateRow;
        }
    }
}
