using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Managers
{
    public class ScoreManager : AbstractManager
    {
        [SerializeField]
        private int _levelUpMultiplicity = 5000;

        private long _score;

        private int _currentDifficultLevel;
        private int _previousDifficultLevel = 0;

        public long Score
        {
            get { return _score; }
            set
            {
                if (value >= 0)
                {
                    _score = value;
                    _currentDifficultLevel = (int) (_score / _levelUpMultiplicity);
                    if (_currentDifficultLevel > _previousDifficultLevel)
                    {
                        ManagerProvider.EventManager.DifficultUpEvent.OnEvent();
                        _previousDifficultLevel = _currentDifficultLevel;
                    }
                }
            }
        }

        public void ResetScore()
        {
            Score = 0;
        }

        public override void Initialization()
        {
            ResetScore();
        }

        public override void Finalization()
        {
            ResetScore();
        }
    }
}