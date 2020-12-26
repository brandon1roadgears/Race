using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    private static bool ControlType = true;

    public bool GetValueOfConfiguration()
    {
        return ControlType;
    }

    public void OnControlTypeChange1()
    {
        ControlType = true;
    }

    public void OnControlTypeChange2()
    {
        ControlType = false;
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnHomeClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
