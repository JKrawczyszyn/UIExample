using Menu.Controllers;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using Utilities;
using Zenject;

namespace Menu.Installers
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MenuController>().AsSingle();

            var inputModule = FindObjectOfType<InputSystemUIInputModule>();
            Container.BindInstance(inputModule).AsSingle();

            Container.BindConfig<MenuViewConfig>("Configs/MenuViewConfig");
        }
    }
}
