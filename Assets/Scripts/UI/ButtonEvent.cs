using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
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
