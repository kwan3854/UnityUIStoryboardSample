using OutGame.Runtime.Core.UseCase;
using OutGame.Runtime.UI.Presentation.Presenter;
using OutGame.Runtime.UI.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace OutGame.Runtime.UI.LifetimeScope
{
    public class EntryPageLifetimeScope : VContainer.Unity.LifetimeScope
    {
        [SerializeField] private EntryPageView view;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            
            builder.RegisterComponent(view);
            builder.Register<EntryPageLifecycle>(Lifetime.Singleton);
            builder.Register<SignInUseCase>(Lifetime.Singleton).As<ISignInUseCase>();
        }
    }
}
