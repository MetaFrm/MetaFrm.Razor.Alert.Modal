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
        internal ModalViewModel ModalViewModel = new();

        /// <summary>
        /// ToastMessage
        /// </summary>
        [Parameter]
        public MetaFrm.Alert.Modal? ModalMessage { get; set; }

        /// <summary>
        /// OnInitializedAsync
        /// </summary>
        /// <returns></returns>
        protected override void OnInitialized()
        {
            this.ModalViewModel = this.CreateViewModel<ModalViewModel>();
        }

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
                        ValueTask? _ = this.JSRuntime?.InvokeVoidAsync("ElementFocus", $"bt_{this.ModalMessage.Buttons.Keys.FirstOrDefault()}");
                    }
                    else
                    {
                        ValueTask? _ = this.JSRuntime?.InvokeVoidAsync("ElementFocus", "focuselement");
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