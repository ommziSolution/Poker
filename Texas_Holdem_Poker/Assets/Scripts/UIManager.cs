using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject MainMenuScene;
    public GameObject GamePlayScene;

    GameObject CurrentScene;

    public void Start()
    {
        CurrentScene = MainMenuScene;
        CurrentScene.SetActive(true);
    }
    public void OnPlay()
    {
        CurrentScene.SetActive(false);
        CurrentScene = GamePlayScene;
        CurrentScene.SetActive(true);
        GamePlayManager.Instance.StartGame();
    }


    public void OnHome()
    {
        CurrentScene.SetActive(false);
        CurrentScene = MainMenuScene;
        CurrentScene.SetActive(true);
    }
}
