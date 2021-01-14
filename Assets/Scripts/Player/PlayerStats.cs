using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private AudioClip GameOverSound = null;
    [SerializeField] private GameObject GameOverPanel = null;
    [SerializeField] private Text EndScore = null;
    [SerializeField] private GameObject DestroyAnimation = null;
    [SerializeField] private GameObject PauseButton = null; 
    [SerializeField] private AudioClip DamageSound = null;
    [SerializeField] private Sprite ClassicShipInShieldMod = null;
    [SerializeField] private Sprite ClassicShip = null;
    [SerializeField] private Animator ShieldModAnimation = null;
    [SerializeField] private Image ButtonOfShieldMod = null;
    private AudioSource SoundPlay = null;
    private Text HealthText = null;
    private Text Score = null;
    private byte HealthPoint = 5;
    private Save _Save = null;
    private SpriteRenderer ShipSkin = null;

    private bool IsInShieldMod = false;

    private void Start()
    {
        SoundPlay = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        HealthText = GameObject.Find("Text(Hp_points)").GetComponent<Text>();
        Score = GameObject.Find("Text(Points)").GetComponent<Text>();
        _Save = Camera.main.GetComponent<Save>();
        ShipSkin = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "HealthBox")
        {
            HealthPoint += 2;
        }
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
            PauseButton.SetActive(false);
            SoundPlay.Stop();
            SoundPlay.PlayOneShot(GameOverSound);
            _Save.SaveResult(int.Parse(Score.text));
            Destroy(this.gameObject);
        }
    }
    
    public void OnShieldModButtonClick()
    {   
        if(ButtonOfShieldMod.sprite.name == "ShieldMod20")
        {
            ShieldModAnimation.SetBool("End", true);
            IsInShieldMod = true;
            ShipSkin.sprite = ClassicShipInShieldMod;
            StartCoroutine(ReloadAnimation());
            StartCoroutine(ShieldMod());    
        }
    }

    private IEnumerator ReloadAnimation()
    {
        yield return new WaitForSeconds(0f);
        ShieldModAnimation.SetBool("End", false);
    }

    private IEnumerator ShieldMod()
    {
        yield return new WaitForSeconds(7f);
        ShipSkin.sprite = ClassicShip;
        IsInShieldMod = false;
    }
}
 