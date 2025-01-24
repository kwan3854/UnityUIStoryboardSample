using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using OutGame.Runtime.UI.Model;
using OutGame.Runtime.UI.Presentation.Builder;
using OutGame.Runtime.UI.View;
using ScreenSystem.Attributes;
using ScreenSystem.Modal;
using ScreenSystem.Page;
using UnityScreenNavigator.Runtime.Core.Page;
using VContainer;

namespace OutGame.Runtime.UI.Presentation.Presenter
{
    [AssetName("MainUI/Page/MainPage by Artist.prefab")]
    public class EntryPageLifecycle : LifecyclePageBase
    {
        private readonly EntryPageView _view;
        private readonly PageEventPublisher _publisher;
        private readonly ModalManager _modalManager;

        [Inject]
        protected EntryPageLifecycle(EntryPageView view, PageEventPublisher publisher, ModalManager modalManager) : base(view)
        {
            _view = view;
            _publisher = publisher;
            _modalManager = modalManager;
        }
    
        protected override UniTask WillPushEnterAsync(CancellationToken cancellationToken)
        {
            base.WillPushEnterAsync(cancellationToken);
            
            var model = new EntryPageModel("Entry Page");
            _view.SetView(model);
            return UniTask.CompletedTask;
        }
    
        public override void DidPushEnter()
        {
            base.DidPushEnter();
        
            _view.OnNextPageButtonClickedAsync.ForEachAwaitAsync(async _ =>
            {
                _publisher.SendPushEvent(new EntryPageBuilder());

                await UniTask.CompletedTask;
            }, ExitCancellationToken);
            
            _view.OnPrevPageButtonClickedAsync.ForEachAwaitAsync(async _ =>
            {
                _publisher.SendPopEvent();
                
                await UniTask.CompletedTask;
            }, ExitCancellationToken);
            
            _view.OnNextPageNoStackButtonClickedAsync.ForEachAwaitAsync(async _ =>
            {
                _publisher.SendPushEvent(new EntryPageBuilder(true, false));
                
                await UniTask.CompletedTask;
            }, ExitCancellationToken);
            
            _view.OnPopAllButtonClickedAsync.ForEachAwaitAsync(async _ =>
            {
                // PageContainer.Of(_view.transform).Pop(true, "EntryPage");

                var targetContainer = PageContainer.Of(_view.transform);
                while (targetContainer.Pages.Count > 1)
                {
                    var prevCount = targetContainer.Pages.Count;
                    _publisher.SendPopEvent(false);
                    // Wait for the page to be popped
                    await UniTask.WaitUntil(() => targetContainer.Pages.Count < prevCount);
                }
            }, ExitCancellationToken);
        }
    }
}