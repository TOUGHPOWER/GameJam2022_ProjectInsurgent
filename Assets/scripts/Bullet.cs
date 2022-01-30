using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] bool granade = false;
    [SerializeField] float speed = 1;
    private Rigidbody2D body;
    [SerializeField] float timer = 3;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (granade)
            body.velocity = gameObject.transform.right * speed;
    }

    private void FixedUpdate()
    {
        if(!granade && !GetComponent<DangerZone>().hited)
            body.velocity = gameObject.transform.right * speed;
        else if(GetComponent<DangerZone>().hited)
            body.velocity = Vector2.zero;

        timer -= Time.deltaTime;
        if (timer <= 0)
            Destroy(gameObject);
    }
}
