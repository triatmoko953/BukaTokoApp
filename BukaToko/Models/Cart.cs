using System;
using System.Collections.Generic;

namespace BukaToko.Models;

public partial class Cart
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
