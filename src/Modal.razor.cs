using MetaFrm.Razor.Alert.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MetaFrm.Razor.Alert
{
    /// <summary>
    /// Modal
    /// </summary>
    public partial class Modal
    {
        internal ModalViewModel ModalViewModel = Factory.CreateViewModel<ModalViewModel>();

        /// <summary>
        /// ToastMessage
        /// </summary>
        [Parameter]
        public MetaFrm.Alert.Modal? ModalMessage { get; set; }

        /// <summary>
        /// OnAfterRenderAsync
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (this.ModalMessage != null && this.ModalMessage.IsVisible)
            {
                if (this.ModalMessage != null && this.ModalMessage.IsVisible)
                {
                    if (this.ModalMessage.Buttons != null && this.ModalMessage.Buttons.Keys.Count == 1)
                    {
#pragma warning disable CA2012 // 올바르게 ValueTasks 사용
                        this.JSRuntime?.InvokeVoidAsync("ElementFocus", $"bt_{this.ModalMessage.Buttons.Keys.FirstOrDefault()}");
#pragma warning restore CA2012 // 올바르게 ValueTasks 사용
                    }
                    else
                    {
#pragma warning disable CA2012 // 올바르게 ValueTasks 사용
                        this.JSRuntime?.InvokeVoidAsync("ElementFocus", "focuselement");
#pragma warning restore CA2012 // 올바르게 ValueTasks 사용
                    }
                }
            }
        }

        private void OnClick(string action)
        {
            try
            {
                this.ModalViewModel.IsBusy = true;

                if (this.ModalMessage != null && this.ModalMessage.Buttons != null && this.ModalMessage.Buttons.ContainsKey(action))
                {
                    if (this.ModalMessage.EventCallback != null)
                        ((EventCallback<string>)this.ModalMessage.EventCallback).InvokeAsync(action);
                }
                Close();
            }
            finally
            {
                this.ModalViewModel.IsBusy = false;
            }
        }

        private void Close()
        {
            if (this.ModalMessage != null)
            {
                this.ModalMessage.IsVisible = false;
                this.ModalMessage.Title = "";
                this.ModalMessage.Text = "";
                this.ModalMessage.Buttons = null;
                this.ModalMessage.EventCallback = null;
            }
        }
    }
}