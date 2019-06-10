using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Managers
{
    public class AudioManager : AbstractManager
    {
        private AudioSource _audioSourceSound;
        private AudioSource _audioSourceMusic;
        private AudioSource _audioSourceMusicHelper;

        private float _musicVolume;

        private float _musicTimePlaying;

        public bool IsPlayMusic { get; set; }

        public float MusicVolume
        {
            get
            {
                return ManagerProvider.SettingsManager.CurrMusicVolume;
            }
            set
            {
                _musicVolume = Mathf.Clamp(value, 0f, 1f);

                _audioSourceMusic.volume = _musicVolume;
                _audioSourceMusicHelper.volume = _musicVolume;
                ManagerProvider.SettingsManager.CurrMusicVolume = _musicVolume;
            }
        }

        public float SoundVolume
        {
            get { return ManagerProvider.SettingsManager.CurrSoundVolume; }
            set
            {
                ManagerProvider.SettingsManager.CurrSoundVolume = Mathf.Clamp(value, 0f, 1f);
                _audioSourceSound.volume = ManagerProvider.SettingsManager.CurrSoundVolume;
            }
        }

        public float CrossfadeRate { get; set; }

        public float CrossfadeRateDelay { get; set; }

        private void Update()
        {
            if (_musicTimePlaying >= _audioSourceMusic.clip.length - CrossfadeRateDelay)
            {
                StopMusic();
            }
            else if (IsPlayMusic)
            {
                _musicTimePlaying += Time.deltaTime;
            }
        }

        public override void Initialization()
        {
            GameObject audio = new GameObject("Audio");

            GameObject audioSourceSoundObject = new GameObject("Sound");
            audioSourceSoundObject.AddComponent<AudioSource>();
            audioSourceSoundObject.transform.parent = audio.transform;

            GameObject audioSourceMusicObject = new GameObject("Music:source");
            audioSourceMusicObject.AddComponent<AudioSource>();
            audioSourceMusicObject.transform.parent = audio.transform;

            GameObject audioSourceMusicHelperObject = new GameObject("Music:source_helper");
            audioSourceMusicHelperObject.AddComponent<AudioSource>();
            audioSourceMusicHelperObject.transform.parent = audio.transform;

            DontDestroyOnLoad(audio);

            _audioSourceSound = audioSourceSoundObject.GetComponent<AudioSource>();
            _audioSourceMusic = audioSourceMusicObject.GetComponent<AudioSource>();
            _audioSourceMusicHelper = audioSourceMusicHelperObject.GetComponent<AudioSource>();

            _audioSourceMusic.playOnAwake = false;
            _audioSourceMusic.ignoreListenerPause = true;
            _audioSourceMusic.ignoreListenerVolume = true;

            _audioSourceMusicHelper.playOnAwake = false;
            _audioSourceMusicHelper.ignoreListenerPause = true;
            _audioSourceMusicHelper.ignoreListenerVolume = true;

            SoundVolume = 0.7f;
            MusicVolume = 0.8f;

            CrossfadeRate = 0.5f;
            CrossfadeRateDelay = 3f;
        }

        public override void Finalization()
        {
            Destroy(_audioSourceSound);
            Destroy(_audioSourceMusic);
            Destroy(_audioSourceMusicHelper);
            _audioSourceSound = null;
            _audioSourceMusic = null;
            _audioSourceMusicHelper = null;
        }

        public void PlaySound(AudioClip clip)
        {
            if (_audioSourceSound != null)
            {
                _audioSourceSound.PlayOneShot(clip);
            }
        }

        public void PlayMusic(AudioClip music, bool loop = false)
        {
            if (!IsPlayMusic && _audioSourceMusic != null)
            {
                _audioSourceMusic.clip = music;
                _audioSourceMusic.loop = loop;
                _audioSourceMusic.Play();
                IsPlayMusic = true;
            }
        }

        public void StopMusic()
        {
            if (IsPlayMusic && _audioSourceMusic != null /*&& _audioSourceMusicHelper != null*/)
            {
                StartCoroutine(CrossfadeMusic(CrossfadeRate));
            }
        }

        private IEnumerator CrossfadeMusic(float crossfadeRate)
        {
            float scaledRate = crossfadeRate * MusicVolume;

            while (_audioSourceMusic.volume > 0)
            {
                _audioSourceMusic.volume -= scaledRate * Time.deltaTime;

                yield return null;
            }

            //AudioSource tmp = _audioSourceMusic;

            //_audioSourceMusic = _audioSourceMusicHelper;
            //_audioSourceMusic.volume = MusicVolume;

            //_audioSourceMusicHelper = tmp;
            //_audioSourceMusicHelper.Stop();

            _audioSourceMusic.Stop();
            _audioSourceMusic.volume = MusicVolume;

            IsPlayMusic = false;
            _musicTimePlaying = 0f;

            ManagerProvider.EventManager.EndMusicEvent.OnEvent();
        }
    }
}