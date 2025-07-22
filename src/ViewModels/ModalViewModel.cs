using MetaFrm.MVVM;
using Microsoft.Extensions.Localization;

namespace MetaFrm.Razor.Alert.ViewModels
{
    /// <summary>
    /// ToastViewModel
    /// </summary>
    public partial class ModalViewModel : BaseViewModel
    {
        /// <summary>
        /// ModalViewModel
        /// </summary>
        public ModalViewModel() { }

        /// <summary>
        /// ModalViewModel
        /// </summary>
        /// <param name="localization"></param>
        public ModalViewModel(IStringLocalizer? localization) : base(localization) { }
    }
}