using LaborProtectionClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborProtectionClient.ViewModel
{
    public class TestViewModel
    {
        private Test test;

        public Question CurrentQuestion { get; set; }


        public TestViewModel(Test test)
        {
            this.test = test;
        }

    }
}
