using System;
using System.Collections.Generic;

namespace Biblioteca.Data;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Authorid { get; set; }

    public virtual Author Author { get; set; } = null!;
}
