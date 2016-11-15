using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCL.Management.DAL;

namespace MCL.Management.BLL
{
    public class SQID
    {
        public static string GetID()
        {
            string nextid = string.Empty;
            sequenceNext sq = new sequenceNext();
            try
            {
                string id = sq.GetSequence("ID").ToString();
                char[] chars = id.ToCharArray();
                int next = 1;
                for (int i = chars.Length - 1; i >= 0; i--)
                {
                    if (int.Parse(chars[i].ToString()) + next >= 10)
                    {
                        nextid = ((int.Parse(chars[i].ToString()) + next) % 10).ToString() + nextid;
                        next = 1;
                    }
                    else
                    {
                        nextid = (int.Parse(chars[i].ToString()) + next).ToString() + nextid;
                        next = 0;
                    }
                }

                if (nextid.Length > 20)
                {
                    nextid = Guid.NewGuid().ToString();
                }
                else
                {
                    sq.UpdateSequence("ID", nextid);

                    string temp = string.Empty;
                    for (int j = 0; j < 20 - nextid.Length; j++)
                    {
                        temp += "0";
                    }
                    nextid = temp + nextid;
                }
            }
            catch
            {
                nextid = Guid.NewGuid().ToString();
            }
            return nextid;
        }
    }
}
