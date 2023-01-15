using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverManager : MonoSingleton<GameOverManager>
{
    [SerializeField] Image image_illust;
    [SerializeField] Image Background;
    [SerializeField] Button Btn_back;

    public Sprite[] illustDatas;

    private void Awake()
    {
        Btn_back.onClick.AddListener(BtnBackToMenu);
    }

    public void GameOver(GameOverType gameOverType)
    {
        SoundManager.Instance.StopBGM();

        if (gameOverType == GameOverType.Success)
            SoundManager.Instance.PlaySFX("SFX_GameWin");
        else
            SoundManager.Instance.PlaySFX("SFX_GameOver");

        image_illust.sprite = illustDatas[(int)gameOverType];
        image_illust.gameObject.SetActive(true);

        image_illust.DOFade(1f, 1f).SetEase(Ease.Linear).OnComplete(()=> 
        {
            Background.gameObject.SetActive(true);
            Btn_back.gameObject.SetActive(true);
        });
    }

    public void BtnBackToMenu()
    {
        image_illust.DOFade(0f, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            Background.gameObject.SetActive(false);
            Btn_back.gameObject.SetActive(false);
            image_illust.gameObject.SetActive(false);

            SceneLoader.Load(SceneName.Start);
        });
    }

}
