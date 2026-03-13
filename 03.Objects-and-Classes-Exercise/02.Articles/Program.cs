namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] articleInfo = input.Split(", ").ToArray();

            string title = articleInfo[0];
            string content = articleInfo[1];
            string author = articleInfo[2];

            Article myArticle = new Article(title, content, author);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine()
                                         .Split(": ")
                                         .ToArray();

                string command = cmdArg[0];
                string token = cmdArg[1];

                if (command == "Edit")
                {
                    myArticle.Edit(token);
                }
                else if (command == "ChangeAuthor")
                {
                    myArticle.ChangeAuthor(token);
                }
                else if (command == "Rename")
                {
                    myArticle.Rename(token);
                }
            }

            Console.WriteLine(myArticle.ToString());

            List<int> jsdhaskj
        }
    }
}
