using Game.Controllers;
using Game.Models;
using Game.Views;
using UnityEngine;
using Utilities;
using Zenject;

namespace Game.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private BulletsView bulletsView;

        public override void InstallBindings()
        {
            Container.BindInstance(bulletsView).AsSingle();

            Container.BindInterfacesAndSelfTo<GameController>().AsSingle();

            Container.Bind<ScenePositionHelper>().AsSingle();

            Container.Bind<IdProvider>().AsSingle();

            Container.Bind<GameModelFactory>().AsSingle();

            Container.BindConfig<GameViewConfig>("Configs/GameViewConfig");
        }
    }
}
