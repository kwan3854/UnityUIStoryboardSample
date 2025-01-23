using Cysharp.Threading.Tasks;
using OutGame.Runtime.UI.Model;
using UnityEngine;
using UnityEngine.UI;
using PageViewBase = ScreenSystem.Page.PageViewBase;

namespace OutGame.Runtime.UI.View
{
    public class SignInPageView : PageViewBase
    {
        [SerializeField] private Button signInModalButton;
    
        public IUniTaskAsyncEnumerable<AsyncUnit> OnSignInModalButtonClickedAsync => signInModalButton.OnClickAsAsyncEnumerable();
    
        public void SetView(SignInPageModel model)
        {
        }
    }
}