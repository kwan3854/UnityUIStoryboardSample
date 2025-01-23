using Cysharp.Threading.Tasks;
using OutGame.Runtime.UI.Model;
using ScreenSystem.Modal;
using UnityEngine;
using UnityEngine.UI;

namespace OutGame.Runtime.UI.View
{
    public class SignInModalView : ModalViewBase
    {
        [SerializeField] private TMPro.TMP_InputField idInputField;
        [SerializeField] private TMPro.TMP_InputField passwordInputField;
        [SerializeField] private Button signInButton;
    
        public IUniTaskAsyncEnumerable<AsyncUnit> OnSignInButtonClickedAsync => signInButton.OnClickAsAsyncEnumerable();
        public IUniTaskAsyncEnumerable<string> OnIdInputFieldEditAsync => idInputField.OnValueChangedAsAsyncEnumerable();
        public IUniTaskAsyncEnumerable<string> OnPasswordInputFieldEditAsync => passwordInputField.OnValueChangedAsAsyncEnumerable();
        
        public void SetView(SignInModalModel model)
        {
        }

        public void SetSignInButtonInteractable(bool isInteractable)
        {
            signInButton.interactable = isInteractable;
        }

        public LogInInfo GetCurrentInput()
        {
            return new LogInInfo(idInputField.text, passwordInputField.text);
        }
    }

    public class LogInInfo
    {
        public string ID { get; private set; }
        public string Password { get; private set; }
        
        public LogInInfo(string id, string password)
        {
            ID = id;
            Password = password;
        }
    }
}