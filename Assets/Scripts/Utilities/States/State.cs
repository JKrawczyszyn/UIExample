using Cysharp.Threading.Tasks;

namespace Utilities.States
{
    public interface IState
    {
        UniTask OnEnter();
    }

    public abstract class State : IState
    {
        public virtual async UniTask OnEnter()
        {
            await UniTask.Yield();
        }
    }
}
