using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        speed = Random.Range(2f,6f);
    }
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boom"))
        {
            Destroy(gameObject);
        }
    }
}
