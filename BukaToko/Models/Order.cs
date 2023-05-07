using System;
using System.Collections.Generic;

namespace BukaToko.Models;

public partial class Order
{
    public int Id { get; set; }

    public int CartId { get; set; }

    public int UserId { get; set; }

    public bool Shipped { get; set; }

    public bool Checkout { get; set; }

    public bool Shipped { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
