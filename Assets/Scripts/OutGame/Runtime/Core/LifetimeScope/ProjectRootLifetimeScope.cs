using MessagePipe;
using OutGame.Runtime.Core.Gateway;
using OutGame.Runtime.Core.Repository;
using OutGame.Runtime.Core.UseCase;
using OutGame.Runtime.UI.Presentation.Builder;
using ScreenSystem.Page;
using ScreenSystem.VContainerExtension;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityScreenNavigator.Runtime.Core.Page;
using VContainer;
using VContainer.Unity;

namespace OutGame.Runtime.Core.LifetimeScope
{
    public class ProjectRootLifetimeScope : VContainer.Unity.LifetimeScope
    {
        [SerializeField] private PageContainer pageContainer;
        [SerializeField] private ModalContainer modalContainer;
    
        protected override void Configure(IContainerBuilder builder)
        {
            // ScreenSystem
            builder.RegisterPageSystem(pageContainer);
            builder.RegisterModalSystem(modalContainer);
        
            // MessagePipe
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<MessagePipeOptions>(options);
            
            RegisterGateways(builder);
            RegisterRepositories(builder);
            RegisterUseCases(builder);
            
            builder.RegisterEntryPoint<SampleEntryPoint>();
        }

        private void RegisterUseCases(IContainerBuilder builder)
        {
            builder.Register<SignInUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
        }

        private void RegisterRepositories(IContainerBuilder builder)
        {
            builder.Register<AccountRepository>(Lifetime.Scoped).AsImplementedInterfaces();
        }

        private void RegisterGateways(IContainerBuilder builder)
        {
            builder.Register<HttpClientGateway>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        private class SampleEntryPoint : IStartable
        {
            private readonly PageEventPublisher _pageEventPublisher;
        
            public SampleEntryPoint(PageEventPublisher pageEventPublisher)
            {
                _pageEventPublisher = pageEventPublisher;
            }

            public void Start()
            {
                _pageEventPublisher.SendPushEvent(new SignInPageBuilder(false, false));
            }
        }
    }
}