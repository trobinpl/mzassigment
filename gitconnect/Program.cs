using gitconnect.Infrastructure.Connector.GitHub;
using gitconnect.Infrastructure.Connector.GitHub.User;
using gitconnect.Infrastructure.GitHubRepository;
using gitconnect.Model;
using System;
using System.Threading.Tasks;

namespace gitconnect
{
    class Program
    {
        public static void Main(string[] args)
        {
            Run(args).GetAwaiter().GetResult();

            Console.ReadLine();
        }

        static async Task Run(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide username to search as parameter");
                return;
            }

            string username = args[0];

            IUserRepository userRepository = new UserRepository(new UserRequest());
            User user = await userRepository.GetUser(username);
            Console.WriteLine(user);
            
        }
    }
}
