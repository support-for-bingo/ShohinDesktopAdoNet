using ShohinDesktopAdoNet.Models.DomainObjects.ShohinValueObjects;

namespace ShohinDesktopAdoNet.Models.AppServices.DTOs
{
    /// <summary>編集日付時刻Data Transfer Object</summary>
    /// <remarks>データベースアクセス時に使用。不変</remarks>
    public class DateTimeDto
    {
        public DateTimeDto(EditDateTime source)
        {
            Date = source.EditDate.Value;
            Time = source.EditTime.Value;
        }

        public decimal Date { get; }
        public decimal Time { get; }
    }
}