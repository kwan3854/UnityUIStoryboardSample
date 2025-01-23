using Cysharp.Threading.Tasks;
using OutGame.Runtime.Core.Repository;
using VContainer;

namespace OutGame.Runtime.Core.UseCase
{
    public class SignInUseCase : ISignInUseCase
    {
        private readonly ISignInRepository _accountRepository;

        [Inject]
        public SignInUseCase(ISignInRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async UniTask<ISignInUseCase.SignInResponseData> SignIn(ISignInUseCase.SignInRequestData signInData)
        {
            return await SignInInternal(signInData);
        }

        private async UniTask<ISignInUseCase.SignInResponseData> SignInInternal(ISignInUseCase.SignInRequestData signInData)
        {
             var requestData =
                new ISignInRepository.SignInRequestData(signInData.ID, signInData.Password);
            var response = await _accountRepository.SignIn(requestData);
            return new ISignInUseCase.SignInResponseData(response.IsSuccess);
        }
    }
}