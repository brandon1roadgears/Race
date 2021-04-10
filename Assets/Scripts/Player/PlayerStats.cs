using UnityEngine;
using UnityEngine.UI;
using ScriptablePlayerStatsObject;
public class PlayerStats : MonoBehaviour
{
    [SerializeField] private PlayerStatsScOb _PlayerStats = null;
    [SerializeField] private GameObject GameOverPanel = null;
    [SerializeField] private GameObject PauseButton = null;
    [SerializeField] private GameObject ControlBlock = null;
    [SerializeField] private Text EndScore = null;
    private PlayerParameters _PlayerParameters = null;
    private Text HealthText = null;
    private Text Score = null;
    private Save _Save = null;   
    private GameObject DestroyAnimation = null;
    private Color DestroyColor;
    private Sprite ShipSkin = null;
    private int HealthPoint = 0;
    private string[] Collisions;

    private void Awake()
    {
        HealthText  = GameObject.Find("Text(Hp_points)").GetComponent<Text>();
        Score       = GameObject.Find("Text(Points)").GetComponent<Text>();
        _Save       = GameObject.Find("Canvas").GetComponent<Save>();
        _PlayerParameters = this.GetComponent<PlayerParameters>();

        ShipSkin = _PlayerStats.shipSkin;
        HealthPoint = _PlayerStats.healthPoint;
        DestroyColor = _PlayerStats.destroyColor;
        DestroyAnimation = _PlayerStats.destroyAnimation;
        Collisions = _PlayerStats.collisions;

        this.gameObject.AddComponent<SpriteRenderer>().sprite = ShipSkin;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        foreach(string i in Collisions)
        {
            if(col.tag == i)
            {
                _PlayerParameters.soundPlay.PlayOneShot(_PlayerParameters.damageSound);
                --HealthPoint;
                HealthText.text = HealthPoint.ToString();
            }
        }
        if(HealthPoint == 0)
        {
            Instantiate(DestroyAnimation, this.transform.localPosition, this.transform.localRotation);
            EndScore.text = Score.text;
            GameOverPanel.SetActive(true);
            ControlBlock.SetActive(true);
            PauseButton.SetActive(false);
            _PlayerParameters.musicPlay.Stop();
            _PlayerParameters.soundPlay.PlayOneShot(_PlayerParameters.gameOverSound);
            _Save.SaveResult(int.Parse(Score.text));
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }

    internal PlayerStatsScOb playerStatsScOb
    {
        get {return _PlayerStats;}
    }
}
 