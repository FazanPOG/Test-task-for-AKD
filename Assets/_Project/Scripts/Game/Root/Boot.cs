using _Project.Services;
using _Project.Utils;

namespace _Project.Root
{
    public class Boot
    {
        private readonly ISceneLoaderService _sceneLoaderService;

        public Boot(ISceneLoaderService sceneLoaderService)
        {
            _sceneLoaderService = sceneLoaderService;
        }
        
        public void StartGame()
        {
            _sceneLoaderService.LoadScene(Scenes.Gameplay);
        }
    }
}
