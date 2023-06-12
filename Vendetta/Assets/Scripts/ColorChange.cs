using UnityEngine;
using TMPro;

public class ColorChange : MonoBehaviour
{
    public float delay = 5f; // Delay in seconds before changing the text color
    public Color targetColor = Color.red;

    private TextMeshProUGUI textMeshPro;
    private bool colorChanged = false;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        Invoke("ChangeTextColor", delay);
    }

    private void ChangeTextColor()
    {
        textMeshPro.color = targetColor;
        colorChanged = true;
    }
}
