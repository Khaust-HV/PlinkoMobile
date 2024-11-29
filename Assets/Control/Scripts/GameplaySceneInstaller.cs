using UnityEngine;
using Zenject;

public sealed class GameplaySceneInstaler : MonoInstaller
{
    [SerializeField] private GameObject _spacePrefab;
    [SerializeField] private GameObject _playerManagerPrefab;
    [SerializeField] private GameObject _ballPoolPrefab;
    [SerializeField] private GameObject _uiControlPrefab;

    public override void InstallBindings()
    {
        Container.Bind<ISpaceControl>().To<SpaceControl>().FromComponentInNewPrefab(_spacePrefab).AsSingle().NonLazy();
        Container.Bind<IPlayerAction>().To<PlayerManager>().FromComponentInNewPrefab(_playerManagerPrefab).AsSingle().NonLazy();
        Container.Bind<IBallPoolAction>().To<BallPool>().FromComponentInNewPrefab(_ballPoolPrefab).AsSingle().NonLazy();
        Container.Bind<IUIControlAction>().To<UIControl>().FromComponentInNewPrefab(_uiControlPrefab).AsSingle().NonLazy();
    }
}
