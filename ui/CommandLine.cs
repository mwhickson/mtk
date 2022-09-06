using mtk.services;

namespace mtk.ui
{

    public class CommandLine
    {
        private mtk.services.Environment _currentEnvironment;
        public mtk.services.Environment CurrentEnvironment
        {
            get { return _currentEnvironment; }
            set { _currentEnvironment = value; }
        }

        public CommandLine(mtk.services.Environment e)
        {
            CurrentEnvironment = e;

            if (_currentEnvironment == null)
            {
                _currentEnvironment = new mtk.services.Environment();
            }
        }

        public async Task Run()
        {
            string prompt = mtk.services.Environment.GetPrompt(CurrentEnvironment.CurrentContext);
            string userInput = "";

            while (!userInput.ToLowerInvariant().Equals("quit"))
            {
                Console.Write(prompt);

                try
                {
                    string? temp = Console.ReadLine();

                    if (temp != null)
                    {
                        userInput = temp.Trim().ToLowerInvariant();

                        // get context switch

                        switch (userInput)
                        {
                            case "exit":
                                CurrentEnvironment.CurrentContext = services.Environment.Context.None;
                                prompt = mtk.services.Environment.GetPrompt(CurrentEnvironment.CurrentContext);
                                break;

                            case "help":
                                // TODO: 
                                break;

                            case "web":
                                CurrentEnvironment.CurrentContext = services.Environment.Context.Web;
                                prompt = mtk.services.Environment.GetPrompt(CurrentEnvironment.CurrentContext);
                                break;

                            case "quit":
                                // PASS:
                                break;

                            default:
                                // PASS: 
                                break;
                        }

                        // perform action
                        // Console.Write(prompt);

                        // switch (CurrentEnvironment.CurrentContext)
                        // {
                        //     case services.Environment.Context.Games:
                        //         break;
                                
                        //     case services.Environment.Context.Random:
                        //         break;

                        //     case services.Environment.Context.Text:
                        //         break;

                        //     case services.Environment.Context.Utility:
                        //         break;

                        //     case services.Environment.Context.Web:
                        //         Console.Write("Enter URL: ");
                        //         temp = Console.ReadLine();

                        //         if (temp != null)
                        //         {
                        //             string url = temp;
                        //             string content = await mtk.services.Web.Fetch(url);

                        //             Console.WriteLine(content);
                        //         }
                                
                        //         break;

                        //     default:
                        //         // PASS:
                        //         break;
                        // }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
    }

}