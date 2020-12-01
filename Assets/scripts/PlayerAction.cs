using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private float sideSpeed = 10f;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * sideSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * sideSpeed * Time.deltaTime);
        }
    }
}
