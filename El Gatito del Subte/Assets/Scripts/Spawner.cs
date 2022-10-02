using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : BaseClass
{
    public GameObject train;
    public float topTimer;
    public int spawnTime;
    public float bottomTimer;
    public Transform topSpawner;
    public Transform bottomSpawner;
    public int trainSpeed;
    public Image topTimerImage;
    public Image bottomTimerImage;

    const float TRAIN_LIFESPAN = 5;

    private void Start()
    {
        bottomTimer = -spawnTime / 2;
    }

    void Update()
    {
        if (!globalScript.isPlayingIntro && globalScript.allowSpawn)
        {
            topTimer += Time.deltaTime;
            topTimerImage.color = new Color(getExpIntensity(topTimer), 1 - getExpIntensity(topTimer), 0);
            if (topTimer > spawnTime)
            {
                topTimer = 0;
                Rigidbody2D spawnedTrain = Instantiate(train, topSpawner.position, topSpawner.rotation).GetComponent<Rigidbody2D>();
                spawnedTrain.velocity = Vector2.right * trainSpeed;
                StartCoroutine(destroyTrain(spawnedTrain.gameObject));
            }

            bottomTimer += Time.deltaTime;
            bottomTimerImage.color = new Color(getExpIntensity(bottomTimer), 1 - getExpIntensity(bottomTimer), 0);
            if (bottomTimer > spawnTime)
            {
                bottomTimer = 0;
                Rigidbody2D spawnedTrain = Instantiate(train, bottomSpawner.position, bottomSpawner.rotation).GetComponent<Rigidbody2D>();
                spawnedTrain.velocity = Vector2.left * trainSpeed;
                StartCoroutine(destroyTrain(spawnedTrain.gameObject));
            }
        }
    }

    // Destroys the given GameObject after the time given by the TRAIN_LIFESPAN constant
    IEnumerator destroyTrain(GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(TRAIN_LIFESPAN);
        Destroy(objectToDestroy);
    }

    // Maps a [0, 1] linear function to an exponential function
    public float getExpIntensity(float timer)
    {
        return (float)(Math.Exp(5 * timer / spawnTime - 3) / 8);
    }
}
