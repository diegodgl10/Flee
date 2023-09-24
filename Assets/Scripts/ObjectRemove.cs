using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRemove : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Backpack" ||
            collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
