namespace mtk.services
{
    public class Environment
    {
        public enum Context
        {
            None,
            Games,
            Random,
            Text,
            Utility,
            Web

        }

        private Context _currentContext;
        public Context CurrentContext
        {
            get { return _currentContext; }
            set { _currentContext = value; }
        }
        
        public Environment()
        {
            CurrentContext = Context.None;
        }

        public static string GetPrompt(Context c)
        {
            string prompt = "> ";

            switch (c)
            {
                case Context.Games:
                    prompt = "games> ";
                    break;

                case Context.Random:
                    prompt = "random> ";
                    break;

                case Context.Text:
                    prompt = "text> ";
                    break;

                case Context.Utility:
                    prompt = "utility> ";
                    break;

                case Context.Web:
                    prompt = "web> ";
                    break;

                case Context.None: // fall-through
                default:
                    // PASS:
                    break;
            }

            return prompt;
        }
    }
}