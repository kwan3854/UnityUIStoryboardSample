using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using OutGame.Runtime.UI.Model;
using OutGame.Runtime.UI.Presentation.Builder;
using OutGame.Runtime.UI.View;
using ScreenSystem.Attributes;
using ScreenSystem.Modal;
using ScreenSystem.Page;
using VContainer;

namespace OutGame.Runtime.UI.Presentation.Presenter
{
    [AssetName("MainUI/Page/SignInPage by Artist.prefab")]
    public class SignInPageLifecycle : LifecyclePageBase
    {
        private readonly SignInPageView _view;
        private readonly PageEventPublisher _publisher;
        private readonly ModalManager _modalManager;

        [Inject]
        public SignInPageLifecycle(SignInPageView view, PageEventPublisher publisher, ModalManager modalManager) : base(view)
        {
            _view = view;
            _publisher = publisher;
            _modalManager = modalManager;
        }
    
        protected override UniTask WillPushEnterAsync(CancellationToken cancellationToken)
        {
            var model = new SignInPageModel();
            _view.SetView(model);
            return UniTask.CompletedTask;
        }
    
        public override void DidPushEnter()
        {
            base.DidPushEnter();
        
            _view.OnSignInModalButtonClickedAsync.ForEachAwaitAsync(async _ =>
            {
                await _modalManager.Push(new SignInModalBuilder(true), ExitCancellationToken);
            });
        }
    }
}