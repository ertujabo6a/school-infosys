// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

namespace ICS.DAL.Entities;

public record Teacher
{
    public required User User { get; init; }
    public required string UserLogin { get; set; } = string.Empty;

    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    public ICollection<ActivityEntity> Activities { get; set; } = new List<ActivityEntity>();
    
}
