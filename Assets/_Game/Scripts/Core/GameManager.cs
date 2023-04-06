using SupersonicWisdomSDK;
public class GameManager : Singleton<GameManager>
{
    public static bool canStart = false, isRunning = false;

    public override void Awake()
    {
        base.Awake();
        SupersonicWisdom.Api.Initialize();
    }


    public static void OnStartGame()
    {
        if (isRunning || !canStart) return;

        canStart = false;
        UIManager.I.OnGameStarted();
        TouchHandler.I.OnGameStarted();
        PlayerController.I.OnGameStarted();
        isRunning = true;
        SupersonicWisdom.Api.NotifyLevelStarted(SaveLoadManager.GetLevel()+1, null);
    }

    public static void OnLevelCompleted()
    {
        isRunning = false;
        canStart = false;
        UIManager.I.OnSuccess();
        SupersonicWisdom.Api.NotifyLevelCompleted(SaveLoadManager.GetLevel()+1, null);
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
