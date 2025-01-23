using Cysharp.Threading.Tasks;

namespace OutGame.Runtime.Core.Repository
{
    public interface ISignInRepository
    {
        public UniTask<SignInResponseData> SignIn(SignInRequestData signInData);
        
        public class SignInRequestData
        {
            public string ID { get; private set; }
            public string Password { get; private set; }
            
            public SignInRequestData(string id, string password)
            {
                ID = id;
                Password = password;
            }
        }

        public class SignInResponseData
        {
            public bool IsSuccess { get; private set; }

            public SignInResponseData(bool isSuccess)
            {
                IsSuccess = isSuccess;
            }
        }
    }
}