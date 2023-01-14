using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] Button Btn_start;
    [SerializeField] Button Btn_preference;
    [SerializeField] Button Btn_Eixt;

    private void Awake()
    {
        DontDestroyObject.LoadDontDestroy();
        Btn_start.onClick.AddListener(GameStart);
        Btn_Eixt.onClick.AddListener(GameExit);
    }

    private void GameStart()
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
