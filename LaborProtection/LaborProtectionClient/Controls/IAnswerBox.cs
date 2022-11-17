using LaborProtectionClient.Data;

namespace LaborProtectionClient.Controls
{
    public interface IAnswerBox
    {
        public bool IsCorrect { get; }
        Answer Answer { get; set; }
    }
}