using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningHandler : MonoBehaviour
{
    public Image fadeInOutImage;
    public float timer;
    public float fadeInTime;
    public GameObject mouse;
    public Transform mouseSpawner;
    public int mouseSpeed;
    public int mouseSpawnTime = 5;
    public float forbiddenAreaTimer;
    public Image forbiddenAreaImage;
    public float forbiddenAreaPeriod;
    public float forbiddenAreaIntensity;
    public Transform player;

    bool isTutorialEnded;
    bool fadedIn;
    bool mouseSpawned;

    const float MOUSE_LIFESPAN = 5;

    public void Start()
    {
        fadeInOutImage.transform.parent.gameObject.SetActive(true);
        timer = -fadeInTime * 0.5f;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (!fadedIn)
        {
            fadeInOutImage.color = new Color(0, 0, 0, 1 - timer / (fadeInTime));
            if (timer > fadeInTime)
            {
                fadedIn = true;
            }
        }
        if (!mouseSpawned)
        {
            if (timer > mouseSpawnTime)
            {
                Rigidbody2D spawnedMouse = Instantiate(mouse, mouseSpawner.position, mouseSpawner.rotation).GetComponent<Rigidbody2D>();
                spawnedMouse.velocity = Vector2.right * mouseSpeed;
                StartCoroutine(destroyMouse(spawnedMouse.gameObject));
                mouseSpawned = true;
            }
        }
        if (timer > MOUSE_LIFESPAN)
        {
            GetComponent<GlobalScript>().isPlayingIntro = false;
        }
        if (!isTutorialEnded) {
            forbiddenAreaTimer += Time.deltaTime;
            forbiddenAreaImage.color = new Color(1, 0, 0, forbiddenAreaIntensity * System.Math.Abs(forbiddenAreaTimer) / forbiddenAreaPeriod);
            if (forbiddenAreaTimer > forbiddenAreaPeriod)
            {
                forbiddenAreaTimer = -forbiddenAreaPeriod;
            }
        }
        if(!isTutorialEnded && player.position.x > 60)
        {
            isTutorialEnded = true;
            Destroy(forbiddenAreaImage.transform.parent.gameObject);
        }
    }

    IEnumerator destroyMouse(GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(MOUSE_LIFESPAN);
        Destroy(objectToDestroy);
    }
}
