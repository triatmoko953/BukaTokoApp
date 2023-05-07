﻿using System;
using System.Collections.Generic;

namespace BukaToko.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int Stock { get; set; }

    public string Description { get; set; } = null!;

    public bool Deleted { get; set; }
}
