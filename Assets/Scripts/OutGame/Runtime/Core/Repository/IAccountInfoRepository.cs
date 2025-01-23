namespace OutGame.Runtime.Core.Repository
{
    public interface IAccountInfoRepository
    {
        public AccountInfo GetCurrentAccountInfo();
        
        public class AccountInfo
        {
            public string ID { get; }
            public string NickName { get; }
            public string Token { get; }

            public AccountInfo(string id, string nickName, string token)
            {
                ID = id;
                Token = token;
                NickName = nickName;
            }
        }
    }
}