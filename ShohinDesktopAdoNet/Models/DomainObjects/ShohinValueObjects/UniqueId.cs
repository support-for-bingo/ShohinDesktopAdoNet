using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShohinDesktopAdoNet.Models.DomainObjects.ShohinValueObjects
{
    /// <summary>値オブジェクト：ユニークID</summary>
    /// <remarks>不変、継承不可</remarks>>
    public sealed class UniqueId : ValueObject<UniqueId>
    {
        private readonly string _value;
        private const int MAX_BYTE_LENGTH = 36;

        /// <summary>完全コンストラクタ</summary>
        /// <param name="uniqueId"></param>
        public UniqueId(string? uniqueId)
        {//Guidの重複チェックは、ほぼ重複することが無いうえコストが高いのでDB側でユニークキーとして例外を発生させる。
            IsNull(uniqueId);
            IsEmpty(uniqueId!);
            IsByteOvered(uniqueId!, MAX_BYTE_LENGTH);
            //適切な位置にハイフンやフォーマットが合っているかもチェックする
            _value = uniqueId!;
        }

        /// <summary>ゲッター</summary>
        /// <remarks></remarks>>
        public string Value => _value;

        /// <summary>等値(同一オブジェクト)比較</summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool RunEquals(UniqueId other)
        {
            return _value == other.Value;
        }

        /// <summary>再作成</summary>
        /// <param name="rc"></param>
        /// <returns></returns>
        public UniqueId Recreate(string rc) => new UniqueId(rc);
    }
}