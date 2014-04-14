using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterTheList
{
    class myFuntionsClass
    {

        public List<string> filterByChar(List<string> theList, char theChar)
        {
            List<string> filteredList = new List<string>();
            for (int cnt = 0; cnt < theList.Count; cnt++)
            {
                if (Convert.ToChar(theList[cnt].Substring(0, 1).ToString()) == theChar)
                {
                    filteredList.Add(theList[cnt].ToString());
                }
            }

            return filteredList;
        }
    }
}
