using System;
using System.Collections.Generic;

namespace apiii.Models;

public partial class News
{
    public int NewsId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateOnly PublicationDate { get; set; }

    public string Author { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
