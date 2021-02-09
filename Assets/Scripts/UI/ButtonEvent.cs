using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private AudioMixer MusicMixer = null;
    [SerializeField] private AudioMixer SoundMixer = null;
    [SerializeField] private AudioClip TestSound = null;
    //[SerializeField] GameObject[] PanelsWithEnemies = new GameObject[4];
    private AudioSource MenuListener = null;
    //private byte CurrentEnemy = 0;

    private void Awake()
    {
        MenuListener = GameObject.Find("SoundPoint").GetComponent<AudioSource>();
    }

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

    /*public void OnPreviosEnemyButton()
    {
        if(CurrentEnemy != 0)
        {
            CloseCurrentEnemy();
            --CurrentEnemy;
            OpenCurrentEnemy();
        }
    }

    public void OnNextEnemyButton()
    {
        if(CurrentEnemy != 3)
        {
            CloseCurrentEnemy();
            ++CurrentEnemy;
            OpenCurrentEnemy();
        }
    }

    private void CloseCurrentEnemy()
    {
        PanelsWithEnemies[CurrentEnemy].SetActive(false);
    }
    private void OpenCurrentEnemy()
    {
        PanelsWithEnemies[CurrentEnemy].SetActive(true);
    }*/
}
