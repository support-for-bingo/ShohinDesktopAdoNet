using ShohinDesktopAdoNet.Models.DomainObjects.Entitys;
using ShohinDesktopAdoNet.Models.DomainObjects.ShohinValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShohinDesktopAdoNet.Models.DomainObjects.InterfaceRepositorys
{
    /// <summary>商品レポジトリ・インターフェース</summary>
    /// <remarks></remarks>
    public interface IShohinRepository
    {
        ShohinEntity FindByUniqueId(UniqueId uniqueId);
        ShohinEntity FindByShohinCode(ShohinCode shohinCode);

        IEnumerable<ShohinEntity> FindAll();

        void Save(ShohinEntity shohin);

        void Remove(ShohinEntity shohin);
    }
}