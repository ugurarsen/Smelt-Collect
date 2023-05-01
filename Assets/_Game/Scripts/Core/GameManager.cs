#if SupersonicWisdomSDK
using SupersonicWisdomSDK;

#endif
public class GameManager : Singleton<GameManager>
{
    public static bool canStart = false, isRunning = false;

    public override void Awake()
    {
        base.Awake();
#if SupersonicWisdomSDK
SupersonicWisdom.Api.Initialize();
#endif
        
    }


    public static void OnStartGame()
    {
        if (isRunning || !canStart) return;

        canStart = false;
        UIManager.I.OnGameStarted();
        TouchHandler.I.OnGameStarted();
        PlayerController.I.OnGameStarted();
        isRunning = true;
#if SupersonicWisdomSDK
        SupersonicWisdom.Api.NotifyLevelStarted(SaveLoadManager.GetLevel()+1, null);
#endif
        TinySauce.OnGameStarted(SaveLoadManager.GetLevel());
    }

    public static void OnLevelCompleted()
    {
        isRunning = false;
        canStart = false;
        UIManager.I.OnSuccess();
#if SupersonicWisdomSDK
        SupersonicWisdom.Api.NotifyLevelCompleted(SaveLoadManager.GetLevel()+1, null);
#endif
        TinySauce.OnGameFinished(true, SaveLoadManager.GetCoin());
    }

    public static void OnLevelFailed()
    {
        isRunning = false;
        canStart = false;
        UIManager.I.OnFail();
    }

    public static void ReloadScene(bool isSuccess)
    {
        if (isSuccess)
        {
            SaveLoadManager.IncreaseLevel();
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
