using ShohinDesktopAdoNet.Models.DomainObjects.ShohinValueObjects;

namespace ShohinDesktopAdoNet.Models.DomainObjects.Entitys
{
    /// <summary>エンティティ：商品</summary>
    /// <remarks></remarks>
    public class ShohinEntity : Entity<ShohinEntity>
    {
        private readonly UniqueId _uniqueId; //識別子
        private ShohinCode _shohinCode;
        private ShohinName _shohinName;
        private EditDateTime _editDateTime;
        private Remarks _remarks;

        /// <summary>データベースから読み取った値格納コンストラクタ。よって、日付、時刻も取ってきたデータそのままを使用する。</summary>
        /// <param name="uniqueId"></param>
        /// <param name="shohinCode"></param>
        /// <param name="shohinName"></param>
        /// <param name="dateTime"></param>
        /// <param name="remarks"></param>
        public ShohinEntity(UniqueId uniqueId, ShohinCode shohinCode, ShohinName shohinName, EditDateTime dateTime, Remarks remarks)
        {
            _uniqueId = uniqueId;
            _shohinCode = shohinCode;
            _shohinName = shohinName;
            _editDateTime = dateTime;
            _remarks = remarks;
        }

        /// <summary>生成するときのコンストラクタ(Guid も作成される)</summary>
        /// <param name="shohinCode"></param>
        /// <param name="shohinName"></param>
        /// <param name="remarks"></param>
        public ShohinEntity(ShohinCode shohinCode, ShohinName shohinName, Remarks remarks)
        {
            _uniqueId = new UniqueId(Guid.NewGuid().ToString()); //識別子新規作成
            _shohinCode = shohinCode;
            _shohinName = shohinName;
            var nowDate = new VoDate(decimal.Parse(String.Format(DateTime.Now.ToString("yyyyMMdd"))));
            var nowTime = new VoTime(decimal.Parse(String.Format(DateTime.Now.ToString("HHmmss"))));
            _editDateTime = new EditDateTime(nowDate, nowTime);
            _remarks = remarks;
        }

        public UniqueId UniqueId => _uniqueId;

        public ShohinCode ShohinCode
        {
            get => _shohinCode;
            set
            {
                IsNull(value);
                _shohinCode = value; 
            }
        } 

        public ShohinName ShohinName
        {
            get => _shohinName;
            set
            {
                IsNull(value);
                _shohinName = value;
            }
        }

        public EditDateTime EditDateTime => _editDateTime;

        public Remarks Remarks
        {
            get => _remarks;
            set
            {
                IsNull(value);
                _remarks = value;
            }
        }

        /// <summary>等値(同一オブジェクト)比較</summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(ShohinEntity other)
        {
            if (_uniqueId.Equals(other.UniqueId))
                if (_shohinCode.Equals(other.ShohinCode))
                    if (_shohinName.Equals(other.ShohinName))
                        if (_editDateTime.Equals(other.EditDateTime))
                            if (_remarks.Equals(other.Remarks))
                                return true;

            return false;
        }

        public override int GetHashCode()
        {
            //nullでないならハッシュコード、nullなら0を返す
            return (_uniqueId != null ? _uniqueId.GetHashCode() : 0);
        }

        public void SetEditDateTime()
        {
            var nowDate = new VoDate(decimal.Parse(String.Format(DateTime.Now.ToString("yyyyMMdd"))));
            var nowTime = new VoTime(decimal.Parse(String.Format(DateTime.Now.ToString("HHmmss"))));
            _editDateTime = new EditDateTime(nowDate, nowTime);
        }

        /// <summary>再作成</summary>
        /// <param name="shohinCode"></param>
        /// <param name="shohinName"></param>
        /// <param name="remarks"></param>
        /// <returns></returns>
        public ShohinEntity Recreate(ShohinCode shohinCode, ShohinName shohinName, Remarks remarks) => new ShohinEntity(shohinCode, shohinName, remarks);
    }
}