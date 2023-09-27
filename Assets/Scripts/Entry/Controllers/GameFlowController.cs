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
            await sceneLoader.UnloadAll();
            await sceneLoader.Load(SceneName.Menu);
        }

        public async UniTask LoadGame(int level)
        {
            gameState.Level = level;

            await sceneLoader.UnloadAll();
            await sceneLoader.Load(SceneName.Game);
        }

        public async UniTask LoadGameOver()
        {
            await sceneLoader.UnloadAll();
            await sceneLoader.Load(SceneName.GameOver);
        }
    }
}
