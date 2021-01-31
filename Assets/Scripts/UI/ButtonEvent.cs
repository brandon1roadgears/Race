using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private AudioMixer MusicMixer = null;
    [SerializeField] private AudioMixer SoundMixer = null;
    [SerializeField] private AudioClip TestSound = null;
    [SerializeField] private AudioSource MenuListener = null;

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
    
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
