using LaborProtectionClient.Controls;
using LaborProtectionClient.Extensions;
using LaborProtectionClient.Model;
using System.ComponentModel;

namespace LaborProtectionClient.ViewModel
{
    public class TestViewModel:INotifyPropertyChanged
    {
        private Test test;
        private int qNumber = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Question CurrentQuestion
        {
            get => test.Questions[qNumber];
        }

        public TestViewModel(Test test)
        {
            this.test = test;
        }

        public Question Increment()
        {
            if (qNumber == test.Questions.Count-1)
            {
                return null;
            }
            return test.Questions[++qNumber];
        }
    }
}
