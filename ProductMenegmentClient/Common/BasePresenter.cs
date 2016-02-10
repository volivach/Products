using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMenegmentClient
{
    public class BasePresenter<TView>
    {
        public TView View { get; set; }

        public virtual void OnViewInitialized() { }
        public virtual void OnViewFinalize() { }
    }
}
