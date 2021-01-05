using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    private static byte ControlType = 1;

    public byte GetValueOfConfiguration()
    {
        return ControlType;
    }

    public void OnControlTypeChange1()
    {
        ControlType = 1;
    }

    public void OnControlTypeChange2()
    {
        ControlType = 2;
    }

    public void OnControlTypeChange3()
    {
        ControlType = 3;
    }

    public void OnStartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGame");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnHomeClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
    }

    public void OnResumeButtonClick()
    {
        Time.timeScale = 1;
    }
}
