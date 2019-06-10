using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Managers;

namespace UI
{
    public class ScoreTextDisplayer : MonoBehaviour
    {
        [SerializeField]
        private Text textLabel;

        private void Start()
        {
            textLabel.text = "Your score: " + ManagerProvider.ScoreManager.Score;
        }
    }
}