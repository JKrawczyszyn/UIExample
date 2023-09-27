using Entry.Controllers;
using Entry.Models;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using Utilities;
using Zenject;

namespace Entry.Installers
{
    public class EntryInstaller : MonoInstaller
    {
        [SerializeField]
        private Camera camera;

        public override void InstallBindings()
        {
            Container.BindInstance(camera).AsSingle();

            Container.Bind<GameFlowController>().AsSingle();

            Container.Bind<SceneLoader>().AsSingle();

            Container.Bind<GameState>().AsSingle();

            var inputModule = FindObjectOfType<InputSystemUIInputModule>();
            Container.BindInstance(inputModule).AsSingle();

            Container.BindConfig<Config>("Configs/Config");
        }
    }
}
