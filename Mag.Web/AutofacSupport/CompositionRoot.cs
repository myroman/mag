using System;

using Autofac;

namespace Mag.Web.AutofacSupport
{
    public class CompositionRoot
    {
        private readonly IContainer container;

        public CompositionRoot(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public TObject Resolve<TObject>()
        {
            return container.Resolve<TObject>();
        }
    }
}