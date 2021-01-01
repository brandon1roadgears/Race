using UnityEngine;
using UnityEngine.UI;

public class TextColorChange : MonoBehaviour
{
    private Text InvaderText;
    private float H = 0.050f;
    void Start()
    {
        InvaderText = GetComponent<Text>();
    }

    void Update()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        
        InvaderText.color = Color.HSVToRGB(H, 1, 1);
        H = H >= 1.000 ? H = 0.000f : H += 0.001f;

    }
}
