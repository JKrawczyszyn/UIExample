using Cysharp.Threading.Tasks;
using Entry.Models;
using Zenject;

namespace Entry.Controllers
{
    public class GameFlowController
    {
        [Inject]
        private SceneLoader sceneLoader;

        [Inject]
        private GameState gameState;

        public async UniTask LoadMenu()
        {
            await sceneLoader.Unload(SceneName.Game);
            await sceneLoader.Load(SceneName.Menu);
        }

        public async UniTask LoadGame(int level)
        {
            gameState.Level = level;

            await sceneLoader.Unload(SceneName.Menu);
            await sceneLoader.Load(SceneName.Game);
        }
    }
}
