using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Vector3 InitialPos;
    public Rigidbody2D rb;

    public float speed;
    Vector2 startPos;
    Vector2 currentPos;
    Vector2 direction;

    public float maxDrag;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitialPos = transform.position;
        startPos = rb.position;

        rb.isKinematic = true;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPos = mousePos;


        if (desiredPos.x > startPos.x)
        {
            desiredPos.x = startPos.x;
        }

        rb.position = desiredPos;

    }

    private void OnMouseUp()
    {
        currentPos = rb.position;
        direction = startPos - currentPos;
        direction.Normalize();

        rb.isKinematic = false;
        rb.AddForce(direction * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetDelay());
    }

    IEnumerator ResetDelay()
    {
        yield return new WaitForSeconds(3);
        rb.position = startPos;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }
}
