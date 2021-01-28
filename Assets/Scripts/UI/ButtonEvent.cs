using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private AudioMixer MusicMixer = null;
    [SerializeField] private AudioMixer SoundMixer = null;
    [SerializeField] private AudioClip TestSound = null;
    [SerializeField] private AudioSource MenuListener = null;
    private static byte ControlType = 1;

    public void SetVolumeOfMusic(float Volume)
    {
        MusicMixer.SetFloat("MusicVolume", Mathf.Log10(Volume) * 20);
    }
    public void SetVolumeOfSounds(float Volume)
    {
        SoundMixer.SetFloat("SoundVolume", Mathf.Log10(Volume) * 20);
    }

    public void CheckSoundVolume()
    {
        MenuListener.PlayOneShot(TestSound);
    }
    
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
