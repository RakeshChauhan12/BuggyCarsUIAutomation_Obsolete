using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsUIAutomation.DataModel
{
    /// <summary>
    /// Data model for buggy cars project.
    /// Use this to store and use data between steps.
    /// </summary>
    public class BuggyCarsData
    {
        public Users userDetail;

        public BuggyCarsData()
        {
            userDetail = new Users();
        }
    }
}
