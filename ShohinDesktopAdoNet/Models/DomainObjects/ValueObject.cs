using System.Diagnostics;
using System.Text;

namespace ShohinDesktopAdoNet.Models.DomainObjects
{
    public abstract class ValueObject<VO> : IEquatable<VO>
    {
        protected abstract bool RunEquals(VO other);

        public bool Equals(VO? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return RunEquals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((VO)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected void IsNull(object? value)
        {
            if (value == null)
            {
                StackFrame frame = new StackFrame(1);
                string className = frame.GetMethod()!.ReflectedType!.Name;
                throw new DomainObjectException($"{className}はnullです。");
            }
        }

        protected void IsEmpty(string? value)
        {
            if (value == string.Empty)
            {
                throw new DomainObjectException("商品が選択されていませんのでIDを取得できませんでした。");
            }
        }

        protected void IsByteOvered(string value, int maxByteLength)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var count = Encoding.GetEncoding("Shift_JIS").GetByteCount(value);
            if (count > maxByteLength)
            {
                throw new DomainObjectException($"{maxByteLength}バイトを超えた文字列が代入されました。");
            }
        }
    }
}