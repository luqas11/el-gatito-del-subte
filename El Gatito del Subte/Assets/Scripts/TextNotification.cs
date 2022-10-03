using UnityEngine;
using UnityEngine.UI;

public class TextNotification : MonoBehaviour
{
    public Text textElement;
    public Image panelImage;
    public float timer;
    public float alphaValue = 0;

    const float NOTIFICATION_TIME = 6;

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > NOTIFICATION_TIME)
        {
            Destroy(this);
        }
        else if (timer > 4 * NOTIFICATION_TIME / 5)
        {
            alphaValue = 5 - timer / (NOTIFICATION_TIME / 5);
        }
        else if (timer > NOTIFICATION_TIME / 5)
        {
            alphaValue = 1;
        }
        else
        {
            alphaValue = timer / (NOTIFICATION_TIME / 5);
        }
        alphaValue *= 0.8f;
        textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, alphaValue);
        panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, alphaValue);
    }
}
