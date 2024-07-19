using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Biblioteca.Data;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
