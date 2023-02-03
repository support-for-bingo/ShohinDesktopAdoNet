using ShohinDesktopAdoNet.Models.DomainObjects.Entitys;
using ShohinDesktopAdoNet.Models.DomainObjects.InterfaceRepositorys;

namespace ShohinDesktopAdoNet.Models.DomainObjects.DomainServices
{
    /// <summary>ドメインサービス</summary>
    /// <remarks></remarks>
    public class ShohinDomainService
    {
        private readonly IShohinRepository repository;

        public ShohinDomainService(IShohinRepository shohinRepository)
        {
            repository = shohinRepository;
        }


        /// <summary>商品番号の登録チェック</summary>
        /// <param name="shohin"></param>
        /// <returns></returns>
        public bool IsRegistered(ShohinEntity shohin)
        {
            var code = shohin.ShohinCode;

            //データベースに問い合わせてすでに同じ商品番号が登録されているかチェックする
            var serched = repository.FindByShohinCode(code);

            return serched != null;
        }
    }
}