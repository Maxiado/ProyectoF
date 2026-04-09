using System;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public float speed;
    public Transform startPosition;

    private void Update()
    {
        transform.position += Vector3.up * (Time.deltaTime * speed);

        if (transform.position.y >= 6)
        {
            transform.position = startPosition.position;
        }
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.layer.Equals(4))
    //     {
    //     }
    // }
}
