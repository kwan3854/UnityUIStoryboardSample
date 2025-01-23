using OutGame.Runtime.UI.Presentation.Presenter;
using OutGame.Runtime.UI.View;
using ScreenSystem.Modal;

namespace OutGame.Runtime.UI.Presentation.Builder
{
    public class SignInModalBuilder : ModalBuilderBase<SignInModalLifecycle, SignInModalView>
    {
        public SignInModalBuilder(bool playAnimation) : base(playAnimation)
        {
        }
    }
}