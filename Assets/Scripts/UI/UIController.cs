
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Managers;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        public void OnInfinityGameSceneLoad()
        {
            ManagerProvider.LevelManager.LoadLevel(Levels.InfinityGame);
        }

        public void OnMainMenuSceneLoad()
        {
            if (SettingsPopupController.IsPause)
            {
                SettingsPopupController.Pause(false);
            }

            ManagerProvider.LevelManager.LoadLevel(Levels.MainMenu);
        }

        public void OnScoreMenuLoad()
        {
            ManagerProvider.LevelManager.LoadLevel(Levels.ScoreMenu);
        }

        public void OnRestartGame()
        {
            if (SettingsPopupController.IsPause)
            {
                SettingsPopupController.Pause(false);
            }
            ManagerProvider.LevelManager.RestartGame();
        }

        public void OnExitGame()
        {
            Application.Quit();
        }
    }
}