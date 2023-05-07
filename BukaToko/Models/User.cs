﻿using System;
using System.Collections.Generic;

namespace BukaToko.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public int WalletId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Wallet Wallet { get; set; } = null!;
}
