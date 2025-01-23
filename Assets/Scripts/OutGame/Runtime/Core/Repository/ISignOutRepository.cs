using Cysharp.Threading.Tasks;

namespace OutGame.Runtime.Core.Repository
{
    public interface ISignOutRepository
    {
        public UniTask<SignOutResponseData> SignOut();
        
        public class SignOutResponseData
        {
            public bool IsSuccess { get; private set; }
            public string Message { get; private set; }
            
            public SignOutResponseData(bool isSuccess, string message)
            {
                IsSuccess = isSuccess;
                Message = message;
            }
        }
    }
}