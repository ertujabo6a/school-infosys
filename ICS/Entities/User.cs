// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.DAL.Entities;
public abstract record User
{
    protected string Login { get; set; } = string.Empty;
    protected string Password { get; set; } = string.Empty;
    protected string FirstName { get; set; } = string.Empty;
    protected string LastName { get; set; } = string.Empty;
    public DateTime Birth { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;

}
