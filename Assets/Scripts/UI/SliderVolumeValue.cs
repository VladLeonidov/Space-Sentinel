using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Managers;

namespace UI
{
    [RequireComponent(typeof(Slider))]
    public class SliderVolumeValue : MonoBehaviour
    {
        [SerializeField]
        private bool isSoundValue;
        [SerializeField]
        private bool isMusicValue;

        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            if (isSoundValue)
            {
                SetCurrentSoundVolumeValue();
            }

            if (isMusicValue)
            {
                SetCurrentMusicVolumeValue();
            }
        }

        private void SetCurrentSoundVolumeValue()
        {
            _slider.value = ManagerProvider.SettingsManager.CurrSoundVolume;
        }

        private void SetCurrentMusicVolumeValue()
        {
            _slider.value = ManagerProvider.SettingsManager.CurrMusicVolume;
        }
    }
}