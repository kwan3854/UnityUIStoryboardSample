using Cysharp.Threading.Tasks;

namespace OutGame.Runtime.Core.Repository
{
    public interface ISignUpRepository
    {
        public UniTask<SignUpResponseData> SignUp(SignUpRequestData signUpData);
        
        public class SignUpRequestData
        {
            public string ID;
            public string Password;
        }
        
        public class SignUpResponseData
        {
            public bool IsSuccess;
            public string Message;
        }
    }
}