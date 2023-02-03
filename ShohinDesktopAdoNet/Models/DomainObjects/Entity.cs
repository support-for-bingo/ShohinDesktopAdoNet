using System.Diagnostics;

namespace ShohinDesktopAdoNet.Models.DomainObjects
{
    public abstract class Entity<T>
    {
        public abstract bool Equals(T other);

        protected void IsNull(object? value)
        {
            if (value == null)
            {
                StackFrame frame = new StackFrame(1);
                string className = frame.GetMethod()!.ReflectedType!.Name;
                throw new DomainObjectException($"{className}はnullです。");
            }
        }
    }
}