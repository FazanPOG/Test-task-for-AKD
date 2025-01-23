using _Project.Services;
using Zenject;

namespace _Project.Root
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindServices();

            StartGame();
        }

        private void BindServices()
        {
            Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().FromNew().AsSingle().NonLazy();
        }

        private void StartGame()
        {
            var sceneLoaderService = Container.Resolve<ISceneLoaderService>();
            
            new Boot(sceneLoaderService).StartGame();
        }
    }
}