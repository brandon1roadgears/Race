using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private AudioClip GameOverSound = null;
    [SerializeField] private AudioClip DamageSound = null;
    [SerializeField] private AudioClip ShieldOnSound = null;
    [SerializeField] private AudioClip ShieldOnSound_reverse = null;
    [SerializeField] private GameObject GameOverPanel = null;
    [SerializeField] private GameObject DestroyAnimation = null;
    [SerializeField] private Sprite ClassicShipInShieldMod = null;
    [SerializeField] private Sprite ClassicShip = null;
    [SerializeField] private Animator ShieldModAnimation = null;
    [SerializeField] private Image ButtonOfShieldMod = null;
    [SerializeField] private Text EndScore = null;
    private AudioSource SoundPlay = null;
    private GameObject PauseButton = null;
    private Text HealthText = null;
    private Text Score = null;
    private Save _Save = null;
    private SpriteRenderer ShipSkin = null;
    private byte HealthPoint = 5;

    private bool IsInShieldMod = false;

    private void Start()
    {
        SoundPlay   = GameObject.Find("SoundPoint").GetComponent<AudioSource>();
        HealthText  = GameObject.Find("Text(Hp_points)").GetComponent<Text>();
        Score       = GameObject.Find("Text(Points)").GetComponent<Text>();
        PauseButton = GameObject.Find("Button(Pause)").GetComponent<GameObject>();
        _Save       = Camera.main.GetComponent<Save>();
        ShipSkin    = GetComponent<SpriteRenderer>();
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
            SoundPlay.PlayOneShot(ShieldOnSound);
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
        SoundPlay.PlayOneShot(ShieldOnSound_reverse);
        IsInShieldMod = false;
    }
}
 