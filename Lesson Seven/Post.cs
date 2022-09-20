using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostNamespace;

internal class Post
{
    public Guid id;
    public string Content;
    public DateTime CreationDateTime;
    public int LikeCount;
    public int ViewCount;
    public bool auth;

    public Post(string content)
    {
        this.id = Guid.NewGuid();
        Content = content;
        CreationDateTime = DateTime.Now;
        LikeCount = 0;
        ViewCount = 0;
        auth = false;
    }

    public override string ToString()
    {
        string temp_id = auth ? this.id.ToString() : "";
        return $@"
{temp_id}
Content: {Content}
CreationDateTime: {CreationDateTime}
LikeCount: {LikeCount}
ViewCount: {ViewCount}
";
    }
}
