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
    // x=15
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
            topTimerImage.color = new Color(topTimer / spawnTime, 1 - topTimer / spawnTime, 0);
            if (topTimer > spawnTime)
            {
                topTimer = 0;
                Rigidbody2D spawnedTrain = Instantiate(train, topSpawner.position, topSpawner.rotation).GetComponent<Rigidbody2D>();
                spawnedTrain.velocity = Vector2.right * trainSpeed;
                StartCoroutine(destroyTrain(spawnedTrain.gameObject));
            }

            bottomTimer += Time.deltaTime;
            bottomTimerImage.color = new Color(bottomTimer / spawnTime, 1 - bottomTimer / spawnTime, 0);
            if (bottomTimer > spawnTime)
            {
                bottomTimer = 0;
                Rigidbody2D spawnedTrain = Instantiate(train, bottomSpawner.position, bottomSpawner.rotation).GetComponent<Rigidbody2D>();
                spawnedTrain.velocity = Vector2.right * trainSpeed;
                StartCoroutine(destroyTrain(spawnedTrain.gameObject));
            }
        }
    }

    IEnumerator destroyTrain(GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(TRAIN_LIFESPAN);
        Destroy(objectToDestroy);
    }
}
