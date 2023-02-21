using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float defend;
    public GameObject effect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > defend)
        {
            Destroy(gameObject, 0.1f);

            Instantiate(effect, transform.position, Quaternion.identity);
        }
         else
        {
            defend -= collision.relativeVelocity.magnitude;
        }
    }
}
