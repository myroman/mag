using System.Collections.Generic;

using Mag.Business.Domain;

namespace Mag.Business.Abstract
{
    public interface ISalesRepository
    {
        IEnumerable<Sale> ReadSales();

        Sale Add(Sale sale);

        void Remove(IEnumerable<int> ids);
    }
}