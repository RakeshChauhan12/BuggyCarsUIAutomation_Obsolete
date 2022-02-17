using BuggyCarsUIAutomation.DataModel;
using BuggyCarsUIAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsUIAutomation.Utilities
{
    public static class BuggyCars
    {
        private static BuggyCarsData _BuggyCarsData;
        public static BuggyCarsData BuggyCarsData
        {
            get
            {
                if(_BuggyCarsData == null)
                {
                    _BuggyCarsData = new BuggyCarsData();
                }
                return _BuggyCarsData;
            }
            set
            {
                _BuggyCarsData = value;
            }
        }

        public static BuggyCarsLoginPage BuggyCarsLoginPage
        {
            get
            {
                return new BuggyCarsLoginPage();
            }
        }

        public static BuggyCarsRegistrationPage BuggyCarsRegistrationPage
        {
            get
            {
                return new BuggyCarsRegistrationPage();
            }
        }

        public static BuggyCarsHomePage BuggyCarsHomePage
        {
            get
            {
                return new BuggyCarsHomePage();
            }
        }

        public static BuggyCarsPopularMakeListPage BuggyCarsPopularMakeListPage
        {
            get
            {
                return new BuggyCarsPopularMakeListPage();
            }
        }
    }
}
