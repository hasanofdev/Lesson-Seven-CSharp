using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationNamespace;

internal class Notification
{
    public Guid id;
    public string Text;
    public DateTime @DateTime;
    public string FromUser;

    public Notification(string text, string fromUser)
    {
        this.id = Guid.NewGuid();
        Text = text;
        DateTime = DateTime.Now;
        FromUser = fromUser;
    }

    public override string ToString()
    {
        return @$"{FromUser} liked the post with {id} on {DateTime}.Post Content: {Text}";
    }
}
