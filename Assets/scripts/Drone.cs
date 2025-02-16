using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    // Start is called before the first frame update
    private int HP;
    public GameObject explosion;
    public AudioClip clip;
    private ScoreBoard sb;
    private float time;
    public GameObject bullet;
    public float fireRate;
    void Start()
    {
        HP = 3;
        sb = GameObject.Find("Score").GetComponent<ScoreBoard>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
        if (HP <= 0)
        {
            sb.Increment(3);
            explode();
        }

        time += Time.deltaTime;
        if (time > fireRate)
        {
            Fire();
            time = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Rock")
        {
            sb.Increment(1);
            explode();

        }
        if (collision.gameObject.name == "Bullet")
        {
            sb.Increment(1);
            if (collision.gameObject.GetComponent<Bullet>().isHit)
            {
                sb.Increment(1);
            }
            explode();
        }
    }

    private void Fly()
    {
        Vector3 direction = new Vector3(0, 1.3f, 1) - transform.position;
        if (direction.magnitude > 50)
        {
            Destroy(this.gameObject);
        }
        var targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 45 * Time.deltaTime);
        transform.Translate(0, 0, 1 * Time.deltaTime);
    }
    public void explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        AudioSource.PlayClipAtPoint(clip, transform.position, 1);
    }
    public void hitted()
    {
        HP -= 1;
    }
    public void Fire()
    {
        GameObject b = Instantiate(bullet, transform.position + transform.forward * 1f, transform.rotation);
        b.name = "Bullet";
    }
}
