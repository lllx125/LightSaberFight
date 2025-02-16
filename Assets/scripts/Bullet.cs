using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 speed;
    public bool isHit;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        speed = new Vector3(0f, 0f, 10f);
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime);
        if (transform.position.x > 60 || transform.position.x < -60 || transform.position.z > 60 || transform.position.z < -60)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y < 0.125f)
        {
            explode();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        explode();
    }
    public void ReverseSpeed()
    {
        speed = -speed;
        float rotationSpeed = 10f;
        float randomX = Random.Range(-1f, 1f) * rotationSpeed;
        float randomY = Random.Range(-1f, 1f) * rotationSpeed;
        float randomZ = Random.Range(-1f, 1f) * rotationSpeed;
        transform.Rotate(new Vector3(randomX, randomY, randomZ));
    }
    public void explode()
    {
        Instantiate(explosion);
        Destroy(this.gameObject);
    }
}