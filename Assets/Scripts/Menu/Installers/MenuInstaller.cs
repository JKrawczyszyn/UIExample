using Menu.Controllers;
using UnityEngine.InputSystem.UI;
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
        }
    }
}
