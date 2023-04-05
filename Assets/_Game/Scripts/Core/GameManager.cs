#if ElephantSDK
using ElephantSDK;
#endif
public class GameManager : Singleton<GameManager>
{
    public static bool canStart = false, isRunning = false;

    public static void OnStartGame()
    {
        if (isRunning || !canStart) return;

        canStart = false;

        #if ElephantSDK
            Elephant.LevelStarted(SaveLoadManager.GetLevel());
        #endif

        UIManager.I.OnGameStarted();
        TouchHandler.I.OnGameStarted();
        PlayerController.I.OnGameStarted();
        isRunning = true;
    }

    public static void OnLevelCompleted()
    {
        isRunning = false;
        canStart = false;
        UIManager.I.OnSuccess();
    }

    public static void OnLevelFailed()
    {
        isRunning = false;
        canStart = false;
        UIManager.I.OnFail();
    }

    public static void ReloadScene(bool isSuccess)
    {
        
#if ElephantSDK
        if (isSuccess) Elephant.LevelStarted(SaveLoadManager.GetLevel());
        else Elephant.LevelFailed(SaveLoadManager.GetLevel());
#endif

        if (isSuccess)
        {
            SaveLoadManager.IncreaseLevel();
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
