using UnityEngine.SceneManagement;

namespace _Project.Services
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}