using Cysharp.Threading.Tasks;
using Entry;
using Entry.Controllers;
using Entry.Views;
using TMPro;
using UnityEngine;
using Zenject;

namespace GameOver.Views
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI gameOverText;

        [SerializeField]
        private DpadButton mainMenuButton;

        [Inject]
        private Config config;

        [Inject]
        private GameFlowController gameFlowController;

        private void Awake()
        {
            gameOverText.text = config.Texts.GameOver;

            mainMenuButton.Initialize(config.Texts.MainMenu);
            mainMenuButton.OnClick += MainMenuButtonClick;
            mainMenuButton.SetActive(true);
        }

        private void MainMenuButtonClick()
        {
            gameFlowController.LoadMenu().Forget();
        }
    }
}
