using System;
using System.Linq;
using firstDotNetProj.classes;

namespace firstDotNetProj
{
    class Program
    {
        static PostRepository repository = new PostRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();
            while (userOption.ToUpper() != "X")
            {
                switch (userOption.ToUpper())
                {
                    case "1":
                        ListArt();
                        break;
                    case "2":
                        InsertArt();
                        break;
                    case "3":
                        UpdateArt();
                        break;
                    case "4":
                        DeleteArt();
                        break;
                    case "5":
                        ViewArt();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
        }
        public static void InsertArt()
        {
            int ind = 0;
            Console.WriteLine("Write a title: ");
            string insTitle = Console.ReadLine();
            Console.WriteLine("Write a description: ");
            string insDesc = Console.ReadLine();
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                if (i != 0)
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
                }
            }
            Console.WriteLine("Choose one of the above or insert C to cancel");
            string GetGenreOption = Console.ReadLine();
            int[] insGenre = { 0, 0, 0, 0, 0, 0 };
            while (GetGenreOption.ToUpper() != "C" && ind < 6)//mostra as opcoes
            {
                insGenre[ind] = int.Parse(GetGenreOption);
                if (ind < 5)
                {
                    Console.WriteLine("Choose one more of the above or insert C to cancel");

                    GetGenreOption = Console.ReadLine();
                }
                ind++;
            }
            DateTime createdAt = DateTime.Now;
            //cria o objeto igualando as variaveis de cima pros parametros do objeto
            Post newPost = new Post(id: repository.nextId(),
                                    title: insTitle,
                                    description: insDesc,
                                    date: createdAt,
                                    genre: new Genre[6] { (Genre)0, (Genre)0, (Genre)0, (Genre)0, (Genre)0, (Genre)0 }
                                    );

            for (int gen = 0; gen < insGenre.Length; gen++)
            {
                newPost.Genre[gen] = (Genre)insGenre[gen];
            }
            repository.insert(newPost);
        }
        public static void ListArt()
        {
            Console.WriteLine("Listing Art Gallery:");
            Console.WriteLine("");
            var list = repository.List();
            if (list.Count <= 0)
            {
                Console.WriteLine("There are no Arts posted yet");
                return;
            }
            foreach (var art in list)
            {
                var deleted = art.returnDeleted();
                Console.WriteLine("#ID {0}: - {1} {2}", art.returnId(), art.returnTitle(), (deleted ? "*Deleted*" : ""));
            }

        }

        public static void DeleteArt()
        {
            Console.WriteLine("Type the post Id to delete: ");
            int postId = int.Parse(Console.ReadLine());
            repository.erase(postId);
        }

        public static void ViewArt()
        {
            Console.WriteLine("Type the post Id to view: ");
            int postId = int.Parse(Console.ReadLine());

            var post = repository.returbById(postId);
            Console.WriteLine(post);
        }

        public static void UpdateArt()
        {
            Console.WriteLine("Type the post Id");
            int postId = int.Parse(Console.ReadLine());
            int ind = 0;
            Console.WriteLine("Write a title: ");
            string insTitle = Console.ReadLine();
            Console.WriteLine("Write a description: ");
            string insDesc = Console.ReadLine();
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                if (i != 0)
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
                }
            }
            Console.WriteLine("Choose one of the above or insert C to cancel");
            string GetGenreOption = Console.ReadLine();
            int[] insGenre = { 0, 0, 0, 0, 0, 0 };
            while (GetGenreOption.ToUpper() != "C" && ind < 5)//mostra as opcoes
            {
                insGenre[ind] = int.Parse(GetGenreOption);
                Console.WriteLine("Choose one more of the above or insert C to cancel");
                GetGenreOption = Console.ReadLine();
                ind++;
            }
            DateTime createdAt = DateTime.Now;
            //cria o objeto igualando as variaveis de cima pros parametros do objeto
            Post updatedPost = new Post(id: postId,
                                    title: insTitle,
                                    description: insDesc,
                                    date: createdAt,
                                    genre: new Genre[6] { (Genre)0, (Genre)0, (Genre)0, (Genre)0, (Genre)0, (Genre)0 }
                                    );

            foreach (int gen in insGenre)
            {
                updatedPost.Genre[gen] = (Genre)insGenre[gen];
            }
            repository.update(postId, updatedPost);
        }

        public static string GetUserOption()
        {
            Console.WriteLine("Welcome, chose an option below: ");
            Console.WriteLine("1 - List Art Gallery");
            Console.WriteLine("2 - Insert new Art");
            Console.WriteLine("3 - Update an Art");
            Console.WriteLine("4 - Delete an Art");
            Console.WriteLine("5 - View Art");
            Console.WriteLine("C - Clear screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine();
            Console.WriteLine();


            return userOption;


        }
    }
}
