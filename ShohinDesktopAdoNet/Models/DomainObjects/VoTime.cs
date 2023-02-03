using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ShohinDesktopAdoNet.Models.DomainObjects
{
    /// <summary>値オブジェクト：時刻</summary>
    /// <remarks></remarks>>
    public class VoTime : ValueObject<VoTime>
    {
        private readonly decimal _value;

        /// <summary>完全コンストラクタ</summary>
        /// <param name="time"></param>
        public VoTime(decimal time)
        {
            string format = "HHmmss";
            //CultureInfo ci = CultureInfo.CurrentCulture;
            CultureInfo ci = new CultureInfo("ja-JP");
            DateTimeStyles dts = DateTimeStyles.None;

            var t = time.ToString();
            if (t.Length < 6)
                t = $"0{t}";

            if (DateTime.TryParseExact(t, format, ci, dts, out _) == false)
            {
                throw new ArgumentOutOfRangeException($"{time}は、時刻に変換できません。");
            }
            _value = time;
        }

        /// <summary>ゲッター</summary>
        /// <remarks></remarks>>
        public decimal Value => _value;

        /// <summary>コロン付きゲッター</summary>
        /// <remarks></remarks>
        public string ValueAndColonFormat => String.Format(_value.ToString("HH:mm:ss"));

        /// <summary>等値(同一オブジェクト)比較</summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool RunEquals(VoTime other)
        {
            return _value == other.Value;
        }

        /// <summary>再作成</summary>
        /// <param name="rc"></param>
        /// <returns></returns>
        public VoTime Recreate(decimal rc) => new VoTime(rc);
    }
}