using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using OutGame.Runtime.Core.UseCase;
using OutGame.Runtime.UI.Model;
using OutGame.Runtime.UI.Presentation.Builder;
using OutGame.Runtime.UI.View;
using ScreenSystem.Attributes;
using ScreenSystem.Modal;
using ScreenSystem.Page;
using VContainer;

namespace OutGame.Runtime.UI.Presentation.Presenter
{
    [AssetName("MainUI/Modal/SignInModal by Artist.prefab")]
    public class SignInModalLifecycle : LifecycleModalBase
    {
        private string _currentId = string.Empty;
        private string _currentPassword = string.Empty;
        
        private readonly SignInModalView _view;
        private readonly ModalManager _modalManager;
        private readonly ISignInUseCase _signInUseCase;
        private readonly PageEventPublisher _pageEventPublisher;

        [Inject]
        public SignInModalLifecycle(SignInModalView view, ModalManager modalManager, ISignInUseCase signInUseCase, PageEventPublisher pageEventPublisher) : base(view)
        {
            _view = view;
            _modalManager = modalManager;
            _signInUseCase = signInUseCase;
            _pageEventPublisher = pageEventPublisher;
        }

        protected override UniTask WillPushEnterAsync(CancellationToken cancellationToken)
        {
            base.WillPushEnterAsync(cancellationToken);

            var model = new SignInModalModel();
            _view.SetView(model);
            return UniTask.CompletedTask;
        }

        public override void DidPushEnter()
        {
            base.DidPushEnter();
            
            var currentId = string.Empty;
            var currentPassword = string.Empty;
            
            // Disable the sign-in button
            _view.SetSignInButtonInteractable(false);
            
            // ID input event processing
            _view.OnIdInputFieldEditAsync
                .ForEachAwaitAsync(async id =>
                {
                    currentId = id;
                    UpdateButtonState(currentId, currentPassword);

                    await UniTask.CompletedTask;
                }).Forget();

            // Password input event processing
            _view.OnPasswordInputFieldEditAsync
                .ForEachAwaitAsync(async password =>
                {
                    currentPassword = password;
                    UpdateButtonState(currentId, currentPassword);
                    
                    await UniTask.CompletedTask;
                }).Forget();
            
            _view.OnSignInButtonClickedAsync
                .ForEachAwaitAsync(async _ => await OnSignInButtonClicked())
                .Forget();
        }

        // If both id and password are not empty, enable the sign-in button
        private void UpdateButtonState(string id, string password)
        {
            bool isInteractable = !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(password);
            _view.SetSignInButtonInteractable(isInteractable);
        }

        // When the sign-in button is clicked, send a sign-in request
        private async UniTask OnSignInButtonClicked()
        {
            var logInInfo = _view.GetCurrentInput();
            var response = await _signInUseCase.SignIn(new ISignInUseCase.SignInRequestData(logInInfo.ID, logInInfo.Password));
                
            // If the sign-in is successful, close the modal
            if (response.IsSuccess)
            {
                _pageEventPublisher.SendPushEvent(new EntryPageBuilder(true, true));
                await _modalManager.Pop(true, ExitCancellationToken);
            }
        }
    }
}