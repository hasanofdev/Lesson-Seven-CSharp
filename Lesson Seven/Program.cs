using UserNamespace;
using AdminNamespace;
using PostNamespace;
using NotificationNamespace;
using NetworkNamespace;

namespace CSharp_Seven;

class Program
{
    static void Main()
    {
        Admin admin = new Admin("Admin", "hesenovelsad468@gmail.com", "elsadelman2");
        User user = new User("Elshad", "Hasanov", "hesenovelsad468@gmail.com", "admin");

        admin.Posts = new() { new Post("Animal"), new Post("Football"), new Post("School"), new Post("Nature") };
        //Post post = new Post("Animal");
        //Notification notification = new Notification("Liked",user.name);

        bool flag = true;
        while (flag)
        {
            int select = 0;
            while (true)
            {
                Console.Clear();
                ConsoleKeyInfo key;
                List<string> list = new() { "Login as Admin", "Login as User" };

                for (int i = 0; i < list.Count; i++)
                {
                    if (i == select)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine(list[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.WriteLine(list[i]);
                    }
                }

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                    select++;
                if (key.Key == ConsoleKey.UpArrow)
                    select--;

                if (select == list.Count)
                    select = 0;
                if (select == -1)
                    select = list.Count - 1;

                if (key.Key == ConsoleKey.Enter)
                    break;
            }

            switch (select)
            {
                case 0:
                    flag = Login_as_Admin(admin);
                    if (!flag)
                        Admin_Interface(admin);
                    break;
                case 1:
                    flag = Login_as_User(user);
                    if (!flag)
                        User_Interface(admin,user);
                    break;
            }
        }
    }
    static bool Login_as_Admin(Admin admin)
    {
        Console.Write("Enter Gmail: ");
        string gmail = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        if (admin.email == gmail)
        {
            if (admin.password == password)
                return false;
            else return true;
        }
        else
            return true;
    }
    static bool Login_as_User(User user)
    {
        Console.Write("Enter Gmail: ");
        string gmail = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        if (user.email == gmail)
        {
            if (user.password == password)
                return false;
            else return true;
        }
        else
            return true;
    }
    static void Admin_Interface(Admin admin)
    {
        while (true)
        {
            int select = 0;
            while (true)
            {
                Console.Clear();
                ConsoleKeyInfo key;
                List<string> list = new() { "Show Posts", "Delete post with ID", "Add Post", "Exit" };
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == select)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine(list[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.WriteLine(list[i]);
                    }
                }

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                    select++;
                if (key.Key == ConsoleKey.UpArrow)
                    select--;

                if (select == list.Count)
                    select = 0;
                if (select == -1)
                    select = list.Count - 1;

                if (key.Key == ConsoleKey.Enter)
                    break;
            }

            switch (select)
            {
                case 0:
                    {
                        Console.Clear();
                        admin.Posts.ForEach(post => post.auth = true);
                        admin.Posts.ForEach(post => Console.WriteLine(post));
                        Console.ReadKey();
                        break;
                    }
                case 1:
                    {
                        Console.Clear();
                        Console.Write("Enter ID: ");
                        string? entered_id = Console.ReadLine();
                        Guid temp_id;
                        Guid.TryParse(entered_id, out temp_id);
                        admin.Posts.RemoveAll(post => post.id == temp_id);
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.Write("Enter Post Content: ");
                        string? content = Console.ReadLine();
                        Post post = new Post(content);
                        admin.Posts.Add(post);
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
            }
        }
    }
    static void User_Interface(Admin admin,User user)
    {
        for (int i = 0; i < admin.Posts.Count; i++)
        {
            Console.Clear();
            Console.WriteLine(admin.Posts[i]);
            Console.WriteLine($@"
     Exit - ESC
    Enter - Like   
  LeftArrow - Prev
 RightArrow - Next
");

            ConsoleKeyInfo key = Console.ReadKey();
            admin.Posts[i].ViewCount++;
            if (key.Key == ConsoleKey.RightArrow)
            {
                if (i != admin.Posts.Count - 1)
                    continue;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                if (i != 0)
                    i--;
                i--;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                admin.Posts[i].LikeCount += 1;
                Notification notification = new Notification(admin.Posts[i].Content, user.name);
                Mail.SendNotification(notification);
            }
            else if (key.Key == ConsoleKey.Escape)
                break;

            if (i == admin.Posts.Count - 1)
                i = -1;
        }
    }
}