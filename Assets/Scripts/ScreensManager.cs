using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ScreenType
{
    HOME,
    GAME_OVER,
    GAME_PAUSE,
    GAME_COMPLETE,
    NONE
}
public class ScreensManager : MonoBehaviour
{
    public static ScreensManager Instance;
    public List<ScreenData> screenData = new List<ScreenData>();
    public ScreenType currentScreen = ScreenType.NONE;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void ShowScreen(ScreenType type)
    {
        if (currentScreen != ScreenType.NONE)
            screenData.Find(x => x.type == currentScreen).screen.SetActive(false);
        currentScreen = type;
        screenData.Find(x => x.type == type).screen.SetActive(true);
    }
}

[System.Serializable]
public class ScreenData
{
    public ScreenType type;
    public GameObject screen;
}
