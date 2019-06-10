using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Managers
{
    [RequireComponent(typeof(EventManager))]
    [RequireComponent(typeof(PlayerManager))]
    [RequireComponent(typeof(ScoreManager))]
    [RequireComponent(typeof(AudioManager))]
    [RequireComponent(typeof(AnimationManager))]
    [RequireComponent(typeof(LevelManager))]
    public class ManagerProvider : MonoBehaviour
    {
        private List<AbstractManager> _managers;

        public static EventManager EventManager { get; private set; }
        public static PlayerManager PlayerManager { get; private set; }
        public static ScoreManager ScoreManager { get; private set; }
        public static SettingsManager SettingsManager { get; private set; }
        public static AudioManager AudioManager { get; private set; }
        public static AnimationManager AnimationManager { get; private set; }
        public static LevelManager LevelManager { get; private set; }

        private void Awake()
        {
            Initialize();

            DontDestroyOnLoad(this.gameObject);

            LevelManager.LoadLevel(Levels.MainMenu);
        }

        private void OnDestroy()
        {
            foreach (AbstractManager manager in _managers)
            {
                manager.Finalization();
            }
        }

        private void Initialize()
        {
            EventManager = GetComponent<EventManager>();
            ScoreManager = GetComponent<ScoreManager>();
            SettingsManager = GetComponent<SettingsManager>();
            AudioManager = GetComponent<AudioManager>();
            AnimationManager = GetComponent<AnimationManager>();
            PlayerManager = GetComponent<PlayerManager>();
            LevelManager = GetComponent<LevelManager>();

            _managers = new List<AbstractManager>
            {
                EventManager,
                ScoreManager,
                SettingsManager,
                AudioManager,
                AnimationManager,
                PlayerManager,
                LevelManager
            };

            foreach (AbstractManager manager in _managers)
            {
                manager.Initialization();
            }
        }
    }
}