using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private AudioClip GameOverSound = null;
    [SerializeField] private GameObject GameOverPanel = null;
    [SerializeField] private Text EndScore = null;
    [SerializeField] private GameObject DestroyAnimation = null;
    [SerializeField] private GameObject PauseButton = null; 
    private AudioSource SoundPlay = null;
    private Text HealthText = null;
    private Text Score = null;
    private byte HealthPoint = 5;

    private void Start()
    {
        SoundPlay = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        HealthText = GameObject.Find("Text(Hp_points)").GetComponent<Text>();
        Score = GameObject.Find("Text(Points)").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "EnemyBullet")
        {
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
            PauseButton.SetActive(false);
            SoundPlay.Stop();
            SoundPlay.PlayOneShot(GameOverSound);
            Destroy(this.gameObject);
        }
    }
}
 