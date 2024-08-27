using System;
using LanguageExt.Common;

namespace inventory_control.front.Models;

[Flags]
public enum UserPermissions 
{
    Read,
    Write,
    Manage,
    ReadWrite = Read | Write,
    Full = Read | Write | Manage
}

public record User(string Name, UserPermissions Permissions, string Token, string RefreshToken);