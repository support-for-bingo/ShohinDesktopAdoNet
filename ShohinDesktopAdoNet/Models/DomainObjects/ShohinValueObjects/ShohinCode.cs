using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShohinDesktopAdoNet.Models.DomainObjects.ShohinValueObjects
{
    /// <summary>値オブジェクト：商品番号</summary>
    /// <remarks>不変、継承不可</remarks>>
    public sealed class ShohinCode : ValueObject<ShohinCode>
    {
        private readonly int _value;

        /// <summary>完全コンストラクタ</summary>
        /// <param name="shohinCode"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public ShohinCode(int shohinCode)
        {
            if (shohinCode < 1 | shohinCode > 99999)
            {
                throw new DomainObjectException("商品番号は1～99999で指定してください");
            }
            _value = shohinCode;
        }

        public ShohinCode(string shohinCode)
        {
            IsNull(shohinCode);
            if (Regex.IsMatch(shohinCode, "^[0-9]{1,5}$") == false)
            {
                throw new DomainObjectException("商品番号は1～99999で指定してください");
            }
            _value = int.Parse(shohinCode);
        }

        /// <summary>ゲッター</summary>
        /// <remarks></remarks>
        public int Value => _value;

        /// <summary>等値(同一オブジェクト)比較</summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool RunEquals(ShohinCode other)
        {
            return _value == other.Value;
        }

        /// <summary>再作成</summary>
        /// <param name="rc"></param>
        /// <returns></returns>
        public ShohinCode Recreate(int rc) => new ShohinCode(rc);
    }
}