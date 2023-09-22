using Zenject;

namespace Utilities.States
{
    public class StateMachineInstaller<T> : Installer<StateMachineInstaller<T>> where T : State
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StateMachine<T>>().AsSingle();
            Container.BindAllDerivedInterfacesAndSelf<T>(c => c.AsSingle());
        }
    }
}
