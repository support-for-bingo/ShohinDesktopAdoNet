using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShohinDesktopAdoNet.Models.DomainObjects.ShohinValueObjects
{
    /// <summary>値オブジェクト：備考</summary>
    /// <remarks>不変、継承不可</remarks>>
    public sealed class Remarks : ValueObject<Remarks>
    {
        private readonly string _value;
        private const int MAX_BYTE_LENGTH = 255;

        /// <summary>完全コンストラクタ</summary>
        /// <param name="remarks"></param>
        public Remarks(string remarks)
        {
            IsNull(remarks);
            IsEmpty(remarks!);
            IsByteOvered(remarks!, MAX_BYTE_LENGTH);

            _value = remarks;
        }

        /// <summary>ゲッター</summary>
        /// <remarks></remarks>>
        public string Value => _value;

        /// <summary>等値(同一オブジェクト)比較</summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool RunEquals(Remarks other)
        {
            return _value == other.Value;
        }

        /// <summary>再作成</summary>
        /// <param name="rc"></param>
        /// <returns></returns>
        public Remarks Recreate(string rc) => new Remarks(rc);
    }
}