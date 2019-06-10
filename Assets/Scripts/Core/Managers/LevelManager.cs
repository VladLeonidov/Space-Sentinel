using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Managers
{
    public enum Levels
    {
        MainMenu,
        ScoreMenu,
        InfinityGame,
        GameOverMenu
    }

    public class LevelManager : AbstractManager
    {
        private Dictionary<int, string> _levels;

        private string _currentLevel;

        public override void Initialization()
        {
            _levels = new Dictionary<int, string>();
            _levels.Add(0, "MainMenu");
            _levels.Add(1, "ScoreMenu");
            _levels.Add(2, "InfinityGame");
            _levels.Add(3, "GameOverMenu");
            _currentLevel = _levels[0];
        }

        public override void Finalization()
        {
            _levels.Clear();
        }

        public void LoadLevel(Levels level)
        {
            _currentLevel = _levels[(int) level];
            SceneManager.LoadScene(_currentLevel, LoadSceneMode.Single);
            ManagerProvider.PlayerManager.ResetHealth();
            if ((int)level != (int)Levels.GameOverMenu)
            {
                ManagerProvider.ScoreManager.ResetScore();
            }
        }

        public void LoadLevel(string levelName, bool resetScore)
        {
            SceneManager.LoadScene(levelName, LoadSceneMode.Single);
            ManagerProvider.PlayerManager.ResetHealth();
            if (resetScore)
            {
                ManagerProvider.ScoreManager.ResetScore();
            }
        }

        public void RestartGame()
        {
            LoadLevel(Levels.InfinityGame);
        }
    }
}