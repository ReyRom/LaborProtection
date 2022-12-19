using LaborProtectionClient.Extensions;
using LaborProtectionClient.Model;
using LaborProtectionClient.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LaborProtectionClient.ViewModel
{
    public class TestListViewModel
    {
        public List<Test> Tests { get; set; }

        public Test Test { get; set; }

        public TestListViewModel()
        {
            Tests = new List<Test>();
            foreach (var file in Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "Tests")))
            {
                try
                {
                    Tests.Add(new Test(file));
                }
                catch
                {

                }
            }
            Test = Tests.First();
        }

        Command startTestCommand;
        public Command StartTestCommand
        {
            get
            {
                return startTestCommand ??
                    (startTestCommand = new Command(obj =>
                    {
                        MainViewModel.MainFrame.Navigate(new TestPage((Test)obj));
                    }));
            }
        }
    }
}
