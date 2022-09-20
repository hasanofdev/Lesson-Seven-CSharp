using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostNamespace;
using NotificationNamespace;

namespace AdminNamespace;

internal class Admin
{
    public Guid id;
    public string username;
    public string email;
    public string password;
    public List<Post> Posts;
    public List<Notification> Notifications;

    public Admin(string username, string email, string password)
    {
        this.id = Guid.NewGuid();
        this.username = username;
        this.email = email;
        this.password = password;
    }

    public override string ToString()
    {
        return @$"
Username: {username}
Email: {email}
Password: {password}
";
    }
}
