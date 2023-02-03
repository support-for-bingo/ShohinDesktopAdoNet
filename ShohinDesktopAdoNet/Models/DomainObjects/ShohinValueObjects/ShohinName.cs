using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShohinDesktopAdoNet.Models.DomainObjects.ShohinValueObjects
{
    /// <summary>値オブジェクト：商品名</summary>
    /// <remarks>不変、継承不可</remarks>>
    public sealed class ShohinName : ValueObject<ShohinName>
    {
        private readonly string _value;
        private const int MAX_BYTE_LENGTH = 50;

        /// <summary>完全コンストラクタ</summary>
        /// <param name="shohinName"></param>
        public ShohinName(string? shohinName)
        {
            IsNull(shohinName);
            IsEmpty(shohinName!);
            IsByteOvered(shohinName!, MAX_BYTE_LENGTH);

            _value = shohinName!;
        }

        /// <summary>ゲッター</summary>
        /// <remarks></remarks>>
        public string Value => _value;

        /// <summary>ゲッター。末尾の空白除去した値</summary>
        /// <remarks></remarks>>
        public string ValueNotSpace => _value.TrimEnd(' ');

        /// <summary>等値(同一オブジェクト)比較</summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool RunEquals(ShohinName other)
        {
            return _value == other.Value;
        }

        /// <summary>再作成</summary>
        /// <param name="rc"></param>
        /// <returns></returns>
        public ShohinName Recreate(string rc) => new ShohinName(rc);
    }
}