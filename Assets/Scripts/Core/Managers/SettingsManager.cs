using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Managers
{
    public class SettingsManager : AbstractManager
    {
        public float CurrSoundVolume { get; set; }
        public float CurrMusicVolume { get; set; }

        public override void Initialization()
        {
            CurrSoundVolume = 1f;
            CurrMusicVolume = 1f;
        }

        public override void Finalization()
        {
            //NOP
        }
    }
}