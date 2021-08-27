using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            spawnObstacle();
        }
    }

    private void spawnObstacle()
    {
        GameObject obs = Instantiate(obstacle, transform.GetChild(Random.Range(0, transform.childCount)).position, Quaternion.identity);
        Vector2 direction = player.transform.position - obs.transform.position;
        //Debug.Log("player.transform.position: " + player.transform.position);
        //Debug.Log("transform.position: " + transform.position);
        Vector2 newVector = direction * speed;
        //Debug.Log("speed: " + speed);
        //Debug.Log("direction: " + direction);
        //Debug.Log("newVector: " + newVector);
        obs.GetComponent<Rigidbody2D>().velocity = newVector;

    }
}
