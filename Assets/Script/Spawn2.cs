using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2: MonoBehaviour
{
    public GameObject[] sampah;
    public GameObject bomb;

    public float xBounds, yBound;

    void Start()
    {
        StartCoroutine(SpawnRandomGameObject());
    }
    IEnumerator SpawnRandomGameObject()
    {
        yield return new WaitForSeconds(Random.Range(0.4f, 1f));

        int randomSampah = Random.Range(0, sampah.Length);

        if (Random.value <= .7f)
        {
            Instantiate(sampah[randomSampah], new Vector2(Random.Range(-xBounds, xBounds), yBound), Quaternion.identity);
        }
        else
        {
            Instantiate(bomb, new Vector2(Random.Range(-xBounds, xBounds), yBound), Quaternion.identity);
        }
        StartCoroutine(SpawnRandomGameObject());
    }
}

