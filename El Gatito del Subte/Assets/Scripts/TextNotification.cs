using UnityEngine;
using UnityEngine.UI;

public class TextNotification : MonoBehaviour
{
    public Text textElement;
    public Image panelImage;
    public float timer;
    public float aplhaValue = 0;

    const float NOTIFICATION_TIME = 8;

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > NOTIFICATION_TIME)
        {
            Destroy(this);
        }
        else if (timer > 4 * NOTIFICATION_TIME / 5)
        {
            aplhaValue = 5 - timer / (NOTIFICATION_TIME / 5);
        }
        else if (timer > NOTIFICATION_TIME / 5)
        {
            aplhaValue = 1;
        }
        else
        {
            aplhaValue = timer / (NOTIFICATION_TIME / 5);
        }
        textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, aplhaValue);
        panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, aplhaValue);
    }
}
