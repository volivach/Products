using System;

namespace ProductMenegmentClient
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        internal void NavigateToCustomers()
        {
            View.NavigateToCustomers();
        }
    }
}