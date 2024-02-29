// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

namespace ICS.DAL.Entities;

public record Admin : User
{
    public new required string Login { get; set; }

}
