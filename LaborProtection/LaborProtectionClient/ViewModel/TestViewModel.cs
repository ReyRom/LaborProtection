using LaborProtectionClient.Controls;
using LaborProtectionClient.Extensions;
using LaborProtectionClient.Model;

namespace LaborProtectionClient.ViewModel
{
    public class TestViewModel
    {
        private Test test;
        private int qNumber = 0;

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
