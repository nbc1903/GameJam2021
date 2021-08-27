using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidSpawner : MonoBehaviour
{

    public GameObject liquid;
    private bool spawning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            spawning = !spawning;
        }

        if (spawning)
        {
            Instantiate(liquid, transform.position + new Vector3(Random.Range(-1f,1f),0,0), Quaternion.identity);
        }
    }
}
