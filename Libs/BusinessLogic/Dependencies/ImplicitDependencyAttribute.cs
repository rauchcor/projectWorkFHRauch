using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Dependencies
{
    /// <summary>
    /// Used to ensure DLLs are copied for the given type to the actual application.
    /// Why: with dependency injection the build system does not always recognize DLL dependencies and thus 
    /// does not copy some DLLs.
    /// Examples: Entity Framework Driver, Serilog, ...
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class ImplicitDependencyAttribute : Attribute
    {
        public Type ImplicitlyUsedType { get; }

        public ImplicitDependencyAttribute(Type implicitlyUsedType)
        {
            ImplicitlyUsedType = implicitlyUsedType;
        }
    }
}
