using OutGame.Runtime.UI.Presentation.Presenter;
using OutGame.Runtime.UI.View;
using ScreenSystem.Page;

namespace OutGame.Runtime.UI.Presentation.Builder
{
    public class EntryPageBuilder : PageBuilderBase<EntryPageLifecycle, EntryPageView>
    {
        public EntryPageBuilder(bool playAnimation = true, bool stack = true) : base(playAnimation, stack)
        {
        }
    }
}