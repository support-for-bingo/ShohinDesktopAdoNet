using ShohinDesktopAdoNet.Models.AppServices.DTOs;
using ShohinDesktopAdoNet.Models.DomainObjects.DomainServices;
using ShohinDesktopAdoNet.Models.DomainObjects.Entitys;
using ShohinDesktopAdoNet.Models.DomainObjects.InterfaceRepositorys;
using ShohinDesktopAdoNet.Models.DomainObjects.ShohinValueObjects;

namespace ShohinDesktopAdoNet.Models.AppServices
{
    public class ShohinAppService
    {
        private readonly IShohinRepository repository;
        private readonly ShohinDomainService domainService;

        public ShohinAppService(IShohinRepository shohinRepository)
        {
            repository = shohinRepository;
            domainService = new ShohinDomainService(repository);
        }

        public void RegisterShohin(string shohinCode, string shohinName, string remarks)
        {//同じ商品名を登録したらExceptionでなくそれに到達するまでに別の例外が起きる
            var shohin = new ShohinEntity(
              new ShohinCode(shohinCode),
              new ShohinName(shohinName),
              new Remarks(remarks)
            );
            if (domainService.IsRegistered(shohin))
            {
                throw new BusinessAppException($"商品番号：{shohinCode}はすでに登録されております。");
            }
            else
            {
                repository.Save(shohin);
            }
        }

        public void EditShohin(string uniqueId, string shohinCode, string shohinName, string remarks)
        {
            var id = new UniqueId(uniqueId);
            var shohin = repository.FindByUniqueId(id);
            if (shohin == null)
            {
                throw new BusinessAppException($"商品に対するIDを見つけれませんでした。ID:{uniqueId}");
            }
            var code = new ShohinCode(shohinCode);
            shohin.ShohinCode = code;
            var name = new ShohinName(shohinName);
            shohin.ShohinName = name;
            shohin.SetEditDateTime();
            var note = new Remarks(remarks);
            shohin.Remarks = note;
            repository.Save(shohin);
        }

        public void RemoveShohin(string uniqueId)
        {
            var id = new UniqueId(uniqueId);
            var shohin = repository.FindByUniqueId(id);
            if (shohin == null)
            {
                throw new BusinessAppException($"商品に対するIDを見つけれませんでした。ID:{uniqueId}");
            }
            repository.Remove(shohin);
        }

        //ユーザー情報取得
        public ShohinDto GetShohinInfo(string uniqueId)
        {
            var id = new UniqueId(uniqueId);
            var shohin = repository.FindByUniqueId(id);
            if (shohin == null)
            {
                throw new BusinessAppException($"商品に対するIDを見つけれませんでした。ID:{uniqueId}");
            }

            return new ShohinDto(shohin);
        }

        public IEnumerable<ShohinDto> GetAllShohinList()
        {
            var shohins = repository.FindAll();
            var dtos = new List<ShohinDto>();
            foreach (var shohin in shohins)
            {
                var dto = new ShohinDto(shohin);
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}