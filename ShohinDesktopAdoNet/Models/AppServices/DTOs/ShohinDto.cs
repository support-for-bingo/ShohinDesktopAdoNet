using ShohinDesktopAdoNet.Models.DomainObjects.Entitys;
using ShohinDesktopAdoNet.Models.DomainObjects.ShohinValueObjects;

namespace ShohinDesktopAdoNet.Models.AppServices.DTOs
{
    /// <summary>商品Data Transfer Object</summary>
    /// <remarks>データベースアクセス時に使用。不変、継承不可</remarks>
    public sealed class ShohinDto
    {
        public ShohinDto(ShohinEntity source)
        {
            UniqueId = source.UniqueId.Value;
            ShohinCode = source.ShohinCode.Value;
            ShohinName = source.ShohinName.Value;
            var datetime = new DateTimeDto(source.EditDateTime);
            EditDate = datetime.Date; //EditDate = source.EditDateTime.EditDate.Value;
            EditTime = datetime.Time;
            Remarks = source.Remarks.Value;
        }

        public string UniqueId { get; }

        public int ShohinCode { get; }

        public string ShohinName { get; }

        public decimal EditDate { get; }

        public decimal EditTime { get; }

        public string Remarks { get; }
    }
}