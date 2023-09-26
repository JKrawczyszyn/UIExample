using Game.Controllers;
using Game.Models;
using Game.Views;
using Utilities;
using Zenject;

namespace Game.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameController>().AsSingle();

            Container.Bind<ScenePositionHelper>().AsSingle();

            Container.Bind<IdProvider>().AsSingle();

            Container.Bind<GameModelFactory>().AsSingle();

            Container.BindConfig<GameViewConfig>("Configs/GameViewConfig");
        }
    }
}
