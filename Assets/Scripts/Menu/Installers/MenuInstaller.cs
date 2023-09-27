using Menu.Controllers;
using Utilities;
using Zenject;

namespace Menu.Installers
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MenuController>().AsSingle();

            Container.BindConfig<MenuViewConfig>("Configs/MenuViewConfig");
        }
    }
}
