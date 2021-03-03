using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol : MonoBehaviour
{

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 targetPosition;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = getRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else{
            targetPosition = getRandomPosition();
        }
        
    }
    private Vector2 getRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Barrel")
        {
            targetPosition = getRandomPosition();
        }
    }
}
