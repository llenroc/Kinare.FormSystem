using Abp.Web.Mvc.Views;

namespace Kinare.FormSystem.Web.Views
{
    public abstract class FormSystemWebViewPageBase : FormSystemWebViewPageBase<dynamic>
    {

    }

    public abstract class FormSystemWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected FormSystemWebViewPageBase()
        {
            LocalizationSourceName = FormSystemConsts.LocalizationSourceName;
        }
    }
}