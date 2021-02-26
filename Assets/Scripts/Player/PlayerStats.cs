using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private AudioClip GameOverSound = null;
    [SerializeField] private AudioClip DamageSound = null;
    [SerializeField] private GameObject GameOverPanel = null;
    [SerializeField] private GameObject DestroyAnimation = null;
    [SerializeField] private GameObject PauseButton = null;
    [SerializeField] private GameObject ControlBlock = null;
    [SerializeField] private Text EndScore = null;
    private AudioSource SoundPlay = null;
    private AudioSource MusicPlay = null;
    private Text HealthText = null;
    private Text Score = null;
    private Save _Save = null;
    private byte HealthPoint = 5;

    private bool IsInShieldMod = false;

    private void Start()
    {
        SoundPlay   = GameObject.Find("SoundPoint").GetComponent<AudioSource>();
        MusicPlay   = Camera.main.GetComponent<AudioSource>();
        HealthText  = GameObject.Find("Text(Hp_points)").GetComponent<Text>();
        Score       = GameObject.Find("Text(Points)").GetComponent<Text>();
        _Save       = GameObject.Find("Canvas").GetComponent<Save>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "EnemyBullet" && !IsInShieldMod)
        {
            SoundPlay.PlayOneShot(DamageSound);
            --HealthPoint;
            byte Hp = byte.Parse(HealthText.text);
            --Hp;
            HealthText.text = Hp.ToString();
        }
        if(HealthPoint == 0)
        {
            Instantiate(DestroyAnimation, this.transform.localPosition, this.transform.localRotation);
            EndScore.text = Score.text;
            GameOverPanel.SetActive(true);
            ControlBlock.SetActive(true);
            PauseButton.SetActive(false);
            MusicPlay.Stop();
            SoundPlay.PlayOneShot(GameOverSound);
            _Save.SaveResult(int.Parse(Score.text));
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }
}
 