using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void Exit()
    {
        switch(GameManager.Current.state)
        {
            case GameState.MainMenu:
                GameManager.Current.CloseApplication();
                break;
            case GameState.GameSettings:
            case GameState.Settings:
            case GameState.HighScore:
                GameManager.Current.ChangeState(0);
                break;
            case GameState.GamePlay:
                GameManager.Current.LoadMenuScene();
                GameManager.Current.ChangeState(0);
                break;
            case GameState.Pause:
                break;
            case GameState.None:
            default:
                Debug.LogError("The game manager has no state!");
                break;
        }
    }
}