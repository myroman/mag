using System.Web;

using Mag.Business.Abstract;
using Mag.Business.Domain;

using Newtonsoft.Json;

namespace Mag.Web.Handlers.ApiControllers
{
    public class SaleController : ApiControllerBase
    {
        private readonly ISalesRepository salesRepository;

        public SaleController(HttpContext context, ISalesRepository salesRepository)
            : base(context)
        {
            this.salesRepository = salesRepository;
        }

        public override void ProcessRequest()
        {
            var action = Context.Request["action"];
            switch (action)
            {
                case "add":
                    AddSale();
                    break;
                case "delete":
                    Delete();
                    break;
            }
        }

        private void AddSale()
        {
            var @object = Context.Request["object"];
            
            var newSale = JsonConvert.DeserializeObject<Sale>(@object);
            var updated = salesRepository.Add(newSale);
            WriteObjectAndFinish(updated);
        }

        private void Delete()
        {
            var idsRaw = Context.Request["ids"];
            var ids = JsonConvert.DeserializeObject<int[]>(idsRaw);
            salesRepository.Remove(ids);
            WriteObjectAndFinish(ids);
        }
    }
}