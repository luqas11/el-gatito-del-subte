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
    public Image[] topTimerDots;
    public Image[] bottomTimerDots;

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
            int topRedDots = (int)Math.Round(topTimer / spawnTime * topTimerDots.Length);
            for (int i=0; i < topTimerDots.Length; i++)
            {
                topTimerDots[i].color = (i < topRedDots) ? Color.red : Color.green;
            }

            if (topTimer > spawnTime)
            {
                topTimer = 0;
                Rigidbody2D spawnedTrain = Instantiate(train, topSpawner.position, topSpawner.rotation).GetComponent<Rigidbody2D>();
                spawnedTrain.velocity = Vector2.right * trainSpeed;
                StartCoroutine(destroyTrain(spawnedTrain.gameObject));
            }

            bottomTimer += Time.deltaTime;
            int bottomRedDots = (int)Math.Round(bottomTimer / spawnTime * bottomTimerDots.Length);
            for (int i = 0; i < topTimerDots.Length; i++)
            {
                bottomTimerDots[i].color = (i < bottomRedDots) ? Color.red : Color.green;
            }

            if (bottomTimer > spawnTime)
            {
                bottomTimer = 0;
                Rigidbody2D spawnedTrain = Instantiate(train, bottomSpawner.position, bottomSpawner.rotation).GetComponent<Rigidbody2D>();
                spawnedTrain.velocity = Vector2.left * trainSpeed;
                StartCoroutine(destroyTrain(spawnedTrain.gameObject));
            }
        }

        if (!globalScript.trainIndicatorsActive)
        {
            foreach(Image dot in topTimerDots)
            {
                dot.color = Color.gray;
            }
            foreach (Image dot in bottomTimerDots)
            {
                dot.color = Color.gray;
            }
        }
    }

    // Destroys the given GameObject after the time given by the TRAIN_LIFESPAN constant
    IEnumerator destroyTrain(GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(TRAIN_LIFESPAN);
        Destroy(objectToDestroy);
    }
}
