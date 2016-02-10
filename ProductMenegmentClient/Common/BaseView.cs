using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows;

namespace ProductMenegmentClient
{
    /// <summary>
    ///  This class injects the Presenter into the View using Unity
    /// </summary>
    /// <typeparam name="TView">Any View</typeparam>
    /// <typeparam name="TPresenter">Any Presenter</typeparam>
    public class BaseView<TView, TPresenter> : System.Windows.Window
        where TPresenter : BasePresenter<TView>
        where TView : class
    {        
        public TPresenter Presenter { get; set; }

        public BaseView() 
        {
            ContainerAccessor containerAccessor = new ContainerAccessor();
            UnityContainer container = containerAccessor.GetContainer();

            if (container == null) throw new InvalidOperationException("Cannot find UnityContainer");

            Presenter = container.Resolve<TPresenter>();
            Presenter.View = this as TView;
        }
    }
}
