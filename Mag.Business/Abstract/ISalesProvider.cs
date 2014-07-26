using System.Collections.Generic;

using Mag.Business.Domain;

namespace Mag.Business.Abstract
{
    public interface ISalesProvider
    {
        IEnumerable<Sale> ReadSales();
    }
}