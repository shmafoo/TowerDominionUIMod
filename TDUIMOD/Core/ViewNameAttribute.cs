using System;

namespace TowerDominionUIMod.Core;

/// <summary>
///     Attribute to tell the ViewModRegistry which view to modify by using the original name.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ViewNameAttribute : Attribute
{
    public ViewNameAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}