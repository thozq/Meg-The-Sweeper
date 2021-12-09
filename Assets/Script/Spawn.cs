using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
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
        yield return new WaitForSeconds(Random.Range(1f, 2f));

        int randomSampah = Random.Range(0, sampah.Length);

        if (Random.value <= .8f)
        { 
            Instantiate(sampah[randomSampah], new Vector2(Random.Range(-xBounds, xBounds), yBound),Quaternion.identity);
        }
        else
        { 
            Instantiate(bomb, new Vector2(Random.Range(-xBounds, xBounds), yBound), Quaternion.identity);
        }
        StartCoroutine(SpawnRandomGameObject());
    }
}

