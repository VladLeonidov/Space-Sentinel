using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Managers;

namespace UI
{
    public class SettingsPopupController : MonoBehaviour
    {
        [SerializeField]
        private GameObject settingsPopup;

        public static bool IsPause { get; set; }

        private void Awake()
        {
            this.settingsPopup.SetActive(false);
            ManagerProvider.AudioManager.SoundVolume = ManagerProvider.SettingsManager.CurrSoundVolume;
            ManagerProvider.AudioManager.MusicVolume = ManagerProvider.SettingsManager.CurrMusicVolume;
        }

        public void SetActivePopup(bool active)
        {
            this.settingsPopup.SetActive(active);
            IsPause = active;

            Pause(IsPause);
        }

        public void OnSetSoundVolume(float value)
        {
            ManagerProvider.SettingsManager.CurrSoundVolume = value;
            ManagerProvider.AudioManager.SoundVolume = ManagerProvider.SettingsManager.CurrSoundVolume;
        }

        public void OnSetMusicVolume(float value)
        {
            ManagerProvider.SettingsManager.CurrMusicVolume = value;
            ManagerProvider.AudioManager.MusicVolume = ManagerProvider.SettingsManager.CurrMusicVolume;
        }

        public static void Pause(bool pause)
        {
            if (pause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}