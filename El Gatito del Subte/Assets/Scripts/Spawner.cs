using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : BaseClass
{
    public GameObject train;
    public float timer;
    public int spawnTime;
    public Transform[] spawners;
    public int trainSpeed;
    public float trainLifespan;
    public Image timerImage;

    int currentSpawner = 0;

    void Update()
    {
        timer += Time.deltaTime;
        timerImage.color = new Color(timer / spawnTime, 1 - timer / spawnTime, 0);
        if (timer > spawnTime)
        {
            timer = 0;
            currentSpawner = Convert.ToInt32(!Convert.ToBoolean(currentSpawner));
            Rigidbody2D spawnedTrain = Instantiate(train, spawners[currentSpawner].position, spawners[currentSpawner].rotation).GetComponent<Rigidbody2D>();
            spawnedTrain.velocity = Vector2.right * trainSpeed;
            StartCoroutine(destroyTrain(spawnedTrain.gameObject));
        }
    }

    IEnumerator destroyTrain(GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(trainLifespan);
        Destroy(objectToDestroy);
    }
}
