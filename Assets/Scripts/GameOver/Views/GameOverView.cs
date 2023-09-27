using Cysharp.Threading.Tasks;
using Entry.Controllers;
using Entry.Views;
using UnityEngine;
using Zenject;

namespace GameOver.Views
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField]
        private DpadButton mainMenuButton;

        [Inject]
        private GameFlowController gameFlowController;

        private void Awake()
        {
            mainMenuButton.Initialize("Main Menu");
            mainMenuButton.OnClick += MainMenuButtonClick;
            mainMenuButton.SetActive(true);
        }

        private void MainMenuButtonClick()
        {
            gameFlowController.LoadMenu().Forget();
        }
    }
}
