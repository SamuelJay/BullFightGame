using MrPigCore;
using MrPigEvents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager :  BaseSceneLoaderManager
{

    public override void Setup(BaseManagerHelper baseManagerHelperIn)
    {
        base.Setup(baseManagerHelperIn);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    public void LoadMainMenuScene()
    {
        LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    public void LoadGameScene()
    {
        LoadScene(2, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.buildIndex)
        {

            case 1:
                TriggerEvent<MainMenuSceneLoadedEvent>(new BaseEvent());
                break;
            case 2:
                TriggerEvent<GameSceneLoadedEvent>(new BaseEvent());
                break;
        }
    }
}
