namespace SynopticProjectChatAgent.Helper
{
    public class StringInputValidator
    {
        public bool CheckForValidInputs(List<string> filterOption, string input)
        {
            if (!filterOption.Contains(input))
            {
                return false;
            }
            return true;
        }
    }
}
