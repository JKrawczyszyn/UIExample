using Entry.Controllers;
using Utilities.States;
using Zenject;

namespace Entry.Installers
{
    public class EntryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FlowController>().AsSingle();

            Container.Bind<SceneLoader>().AsSingle();

            StateMachineInstaller<FlowState>.Install(Container);
        }
    }
}
