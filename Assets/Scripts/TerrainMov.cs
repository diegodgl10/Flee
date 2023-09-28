using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMov : MonoBehaviour
{
    private float speed = 28.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, Time.deltaTime * this.speed * -1);
    }
}
