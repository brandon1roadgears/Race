using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private byte HealthPoint = 5;
    private Text HealthText = null;

    private void Start()
    {
        HealthText = GameObject.Find("Text(Hp_points)").GetComponent<Text>();
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
            Destroy(this.gameObject);
        }
    }
}
