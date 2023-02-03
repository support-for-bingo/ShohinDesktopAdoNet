using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShohinDesktopAdoNet.Models.DomainObjects
{
    /// <summary>値オブジェクト：日付</summary>
    /// <remarks></remarks>
    public class VoDate : ValueObject<VoDate>
    {
        private readonly decimal _value;

        /// <summary>完全コンストラクタ</summary>
        /// <param name="date"></param>
        public VoDate(decimal date)
        {
            string format = "yyyyMMdd";
            //CultureInfo ci = CultureInfo.CurrentCulture;
            CultureInfo ci = new CultureInfo("ja-JP");
            DateTimeStyles dts = DateTimeStyles.None;

            if (DateTime.TryParseExact(date.ToString(), format, ci, dts, out _) == false)
            {
                throw new ArgumentOutOfRangeException($"{date}は、日付に変換できません。");
            }
            _value = date;
        }

        /// <summary>ゲッター</summary>
        /// <remarks></remarks>
        public decimal Value => _value;

        /// <summary>スラッシュ付きゲッター(yyyy/MM/dd)</summary>
        /// <remarks></remarks>
        public string ValueAndSlashFormat => string.Format(_value.ToString("yyyy/MM/dd"));

        /// <summary>ハイフン付き付きゲッター(yyyy-MM-dd)</summary>
        /// <remarks></remarks>
        public string ValueAndHyphenFormat => string.Format(_value.ToString("yyyy-MM-dd"));

        /// <summary>等値(同一オブジェクト)比較</summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool RunEquals(VoDate other)
        {
            return _value == other.Value;
        }

        /// <summary>再作成</summary>
        /// <param name="rc"></param>
        /// <returns></returns>
        public VoDate Recreate(decimal rc) => new VoDate(rc);
    }
}