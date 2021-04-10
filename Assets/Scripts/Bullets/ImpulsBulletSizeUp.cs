using System.Collections;
using UnityEngine;

public class ImpulsBulletSizeUp : MonoBehaviour
{
    private Transform BulletSize = null;
    private float Maximum = 0.4f;
    private float Radius = 0.05f;
    private float Alpha = 0.0f;
    private void Start()
    {
        BulletSize = this.GetComponent<Transform>();
        Alpha = Random.Range(-1f,2f);
    }

    private void Update()
    {   
        SizeUp();
    }

    private void SizeUp()
    {
        this.transform.position = new Vector2(Radius * Mathf.Cos(Alpha) + this.transform.position.x, this.transform.position.y);
        this.transform.localScale = new Vector2(Mathf.Lerp(this.transform.localScale.x, Maximum, 0.02f), Mathf.Lerp(this.transform.localScale.y, Maximum, 0.02f));
        Alpha += 0.08f;
    }
}
