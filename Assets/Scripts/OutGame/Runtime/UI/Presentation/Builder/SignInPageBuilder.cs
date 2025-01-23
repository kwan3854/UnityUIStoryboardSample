using OutGame.Runtime.UI.Presentation.Presenter;
using OutGame.Runtime.UI.View;
using ScreenSystem.Page;

namespace OutGame.Runtime.UI.Presentation.Builder
{
    public class SignInPageBuilder : PageBuilderBase<SignInPageLifecycle, SignInPageView>
    {
        public SignInPageBuilder(bool shouldAnimate, bool shouldStack) : base(shouldAnimate, shouldStack)
        {
        }
    }
}