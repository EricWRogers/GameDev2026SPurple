using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Image image;
    void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }
    public void ToggleActive()
    {
        image.enabled = !image.enabled;
    }

}
