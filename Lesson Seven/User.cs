using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace UserNamespace;
public class User
{
    public Guid id;
    public string name;
    public string surname;
    public string email;
    public string password;

    public User(string name, string surname, string email, string password)
    {
        this.id = Guid.NewGuid();
        this.name = name;
        this.surname = surname;
        this.email = email;
        this.password = password;
    }

    public override string ToString()
    {
        return $@"
ID: {id}
Name: {name}
Surname: {surname}
Email: {email}";
    }
}
