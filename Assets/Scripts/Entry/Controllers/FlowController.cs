using System;
using Utilities.States;
using Zenject;

namespace Entry.Controllers
{
    public class FlowController : IDisposable
    {
        [Inject]
        private readonly StateMachine<FlowState> stateMachine;

        public void LoadMenu()
        {
            stateMachine.Transition<LoadMenuState>();
        }

        public void LoadGame()
        {
            stateMachine.Transition<LoadGameState>();
        }

        public void Dispose()
        {
            stateMachine.Stop();
        }
    }
}
