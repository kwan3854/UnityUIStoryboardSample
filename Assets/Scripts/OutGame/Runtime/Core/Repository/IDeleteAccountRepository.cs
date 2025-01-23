using Cysharp.Threading.Tasks;

namespace OutGame.Runtime.Core.Repository
{
    public interface IDeleteAccountRepository
    {
        public UniTask<DeleteAccountResponseData> DeleteAccount(DeleteAccountRequestData deleteAccountData);
        
        public class DeleteAccountRequestData
        {
            public string ID;
            public string Password;
        }
        
        public class DeleteAccountResponseData
        {
            public bool IsSuccess;
            public string Message;
        }
    }
}