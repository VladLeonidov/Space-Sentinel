using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Managers;

namespace Core.Audio
{
    public class BackgroundMusicPlayer : MonoBehaviour
    {
        [SerializeField]
        private MusicClip[] musicList;
        [SerializeField]
        private bool randomOrder;
        [SerializeField]
        private bool dontDestroyOnLoad;
        [SerializeField]
        private float crossfadeRate;

        private static BackgroundMusicPlayer _instance;

        private int _musicListIndex;
        private float _musicTimePlaying;

        private void Awake()
        {
            if (this.dontDestroyOnLoad)
            {
                if (_instance != null)
                {
                    Destroy(this.gameObject);
                    return;
                }

                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        private void Start()
        {
            //ManagerProvider.EventManager.EndMusicEvent.Subscribe(OnMusicEnd);

            //if (this.randomOrder)
            //{
            //    PlayWithRandomOrder();
            //}
            //else
            //{
            //    Play();
            //}
        }

        private void Update()
        {
            if (!ManagerProvider.AudioManager.IsPlayMusic)
            {
                if (this.randomOrder)
                {
                    PlayWithRandomOrder();
                }
                else
                {
                    Play();
                }
            }

            if (this.musicList[_musicListIndex].IsInterrupt)
            {
                InterruptMusic(this.musicList[_musicListIndex].InterruptDelay);
            }
        }

        private void Play()
        {
            ManagerProvider.AudioManager.PlayMusic
                    (
                        this.musicList[_musicListIndex].Track,
                        this.musicList[_musicListIndex].IsLoop
                    );

            _musicListIndex++;
            
            if (_musicListIndex >= this.musicList.Length)
            {
                _musicListIndex = 0;
            }
        }

        private void PlayWithRandomOrder()
        {
            int rand = Random.Range(0, this.musicList.Length);

            if (_musicListIndex == rand)
            {
                _musicListIndex = ++rand;
            }
            else
            {
                _musicListIndex = rand;
            }

            if (_musicListIndex >= this.musicList.Length)
            {
                _musicListIndex = 0;
            }

            ManagerProvider.AudioManager.PlayMusic
                    (
                        this.musicList[_musicListIndex].Track,
                        this.musicList[_musicListIndex].IsLoop
                    );
        }

        private void InterruptMusic(float interruptDelay)
        {
            if (CanInterruptMusic(interruptDelay))
            {
                ManagerProvider.AudioManager.CrossfadeRate = this.crossfadeRate;
                ManagerProvider.AudioManager.StopMusic();
                _musicTimePlaying = 0f;
            }
            else
            {
                _musicTimePlaying += Time.deltaTime;
            }
        }

        private bool CanInterruptMusic(float interruptDelay)
        {
            if (_musicTimePlaying >= interruptDelay)
            {
                return true;
            }

            return false;
        }

        private void OnDestroy()
        {
            ManagerProvider.AudioManager.StopMusic();
            //ManagerProvider.EventManager.EndMusicEvent.Unsubscribe(OnMusicEnd);
        }

        private void OnMusicEnd()
        {
            if (this.randomOrder)
            {
                PlayWithRandomOrder();
            }
            else
            {
                Play();
            }
        }
    }
}