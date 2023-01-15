using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    [System.Serializable]
    public class SFX
    {
        public string name;
        public AudioClip clip;
    };

    [Header("Audio Sources")]
    [SerializeField] AudioSource BGMPlayer;
    [SerializeField] AudioSource SFX1Player;
    [SerializeField] AudioSource SFX2Player;
    [SerializeField] AudioSource SFX3Player;

    [Header("Audio Clip List")]
    [SerializeField] List<SFX> list_SFX = new List<SFX>();
    [SerializeField] List<SFX> list_BGM = new List<SFX>();

    Dictionary<string, AudioClip> dic_SFX = new Dictionary<string, AudioClip>();
    Dictionary<string, AudioClip> dic_BGM = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        foreach(SFX s in list_SFX)
        {
            dic_SFX.Add(s.name, s.clip);
        }

        foreach (SFX s in list_BGM)
        {
            dic_BGM.Add(s.name, s.clip);
        }
    }

    public void PlaySFX(string _sfxName)
    {
        if(SFX1Player.isPlaying)
        {
            SFX2Player.clip = dic_SFX[_sfxName];
            SFX2Player.Play();
        }
        else
        {
            SFX1Player.clip = dic_SFX[_sfxName];
            SFX1Player.Play();
        }
    }

    public void PlaySFXLoop(string _sfxName)
    {
        SFX3Player.clip = dic_SFX[_sfxName];
        SFX3Player.Play();
    }

    public void PlayBGM(string _bgmName)
    {
        BGMPlayer.Stop();
        BGMPlayer.clip = dic_BGM[_bgmName];
        BGMPlayer.Play();
    }

    public void StopBGM()
    {
        BGMPlayer.Stop();
    }
}
