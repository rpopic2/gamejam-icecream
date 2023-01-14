using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Video;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] Image Title;
    [SerializeField] Button Btn_start;
    [SerializeField] Button Btn_preference;
    [SerializeField] Button Btn_Eixt;
    [SerializeField] GameObject video;
    [SerializeField] VideoPlayer videoPlayer;

    private void Awake()
    {
        DontDestroyObject.LoadDontDestroy();
        Btn_start.onClick.AddListener(GameStart);
        Btn_Eixt.onClick.AddListener(GameExit);
        
    }

    private void GameStart()
    {
        Title.DOFade(1f, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            video.SetActive(true);

            videoPlayer.loopPointReached += VideoEndReached;

            videoPlayer.Play();
        });

        Btn_start.image.DOFade(1f, 1f).SetEase(Ease.Linear);
        Btn_preference.image.DOFade(1f, 1f).SetEase(Ease.Linear);
        Btn_Eixt.image.DOFade(1f, 1f).SetEase(Ease.Linear);
    }

    void VideoEndReached(VideoPlayer vp)
    {
        SceneLoader.Load(SceneName.Game);
    }

    private void GameExit()
    {
        Application.Quit();
    }

    private void OpenPreference()
    {

    }

}
