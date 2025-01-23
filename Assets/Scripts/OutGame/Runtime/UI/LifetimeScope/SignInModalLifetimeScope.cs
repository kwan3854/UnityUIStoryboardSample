using OutGame.Runtime.Core.UseCase;
using OutGame.Runtime.UI.Presentation.Presenter;
using OutGame.Runtime.UI.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace OutGame.Runtime.UI.LifetimeScope
{
    public class SignInModalLifetimeScope : VContainer.Unity.LifetimeScope
    {
        [SerializeField] private SignInModalView view;
    
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
        
            builder.RegisterComponent(view);
            builder.Register<SignInModalLifecycle>(Lifetime.Singleton);
            // builder.Register<SignInUseCase>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<MockSignInUseCase>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
