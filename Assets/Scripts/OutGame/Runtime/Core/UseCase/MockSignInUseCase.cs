using Cysharp.Threading.Tasks;

namespace OutGame.Runtime.Core.UseCase
{
    public class MockSignInUseCase : ISignInUseCase
    {
        public async UniTask<ISignInUseCase.SignInResponseData> SignIn(ISignInUseCase.SignInRequestData signInData)
        {
            await UniTask.Delay(1000);
            
            return new ISignInUseCase.SignInResponseData(true);
        }
    }
}