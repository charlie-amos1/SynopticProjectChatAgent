namespace SynopticProjectChatAgent.Controllers
{
    public class InputValidation
    {
        public bool ValidateInput(string input, List<string> categoryFilter, string viewName)
        {

            if (input != null)
            {
                if (categoryFilter.Contains(input))
                {
                    return true;
                }

            }
            return false;
        }
    }
}