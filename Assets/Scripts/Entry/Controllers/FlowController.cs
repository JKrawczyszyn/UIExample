using Cysharp.Threading.Tasks;
using Zenject;

namespace Entry.Controllers
{
    public class FlowController
    {
        [Inject]
        private SceneLoader sceneLoader;

        public async UniTask LoadMenu()
        {
            await sceneLoader.Unload(SceneName.Game);
            await sceneLoader.Load(SceneName.Menu);
        }

        public async UniTask LoadGame(int level)
        {
            await sceneLoader.Unload(SceneName.Menu);
            await sceneLoader.Load(SceneName.Game);
        }
    }
}
