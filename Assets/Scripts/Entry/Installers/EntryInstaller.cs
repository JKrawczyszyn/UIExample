using Entry.Controllers;
using UnityEngine;
using Zenject;

namespace Entry.Installers
{
    public class EntryInstaller : MonoInstaller
    {
        [SerializeField]
        private Config config;

        [SerializeField]
        private ViewConfig viewConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(config).AsSingle();

            viewConfig.Initialize();
            Container.BindInstance(viewConfig).AsSingle();

            Container.Bind<FlowController>().AsSingle();

            Container.Bind<SceneLoader>().AsSingle();
        }
    }
}
