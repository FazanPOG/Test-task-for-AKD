using UnityEngine;
using Zenject;

namespace _Project.Gameplay.Root
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private Transform _gameplayRootTransform;
        [SerializeField] private Player _playerPrefab; 
        
        public override void InstallBindings()
        {
            BindInput();
            BindPlayer();
        }

        private void BindInput()
        {
            Container.BindInterfacesTo<DesktopInputHandler>().FromNew().AsSingle().NonLazy();
        }

        private void BindPlayer()
        {
            var inputHandler = Container.Resolve<IInputHandler>();
            
            var player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _gameplayRootTransform);
            
            player.Init(inputHandler);
        }
    }
}
