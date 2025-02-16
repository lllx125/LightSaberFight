using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Stone : MonoBehaviour
{
    private Vector3 speed;
    private float v;
    private bool grabbed;
    public MeshDestroy crash;
    public Rigidbody rb;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 destination = new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
        speed = destination - transform.position;
        speed = speed / speed.magnitude;
        grabbed = false;
        v = Random.Range(3, 7);
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.activated.AddListener(OnExplode);

    }

    // Update is called once per frame
    void Update()
    {
        if (!grabbed)
        {
            transform.position += speed * Time.deltaTime * v;
        }
        else
        {
            rb.AddForce(0, -1, 0);
        }
        if (transform.position.y < -20 || transform.position.y > 100)
        {
            Destroy(this.gameObject);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        explode();
    }
    public void explode()
    {
        crash.DestroyMesh();
        AudioSource.PlayClipAtPoint(clip, transform.position, 10);
    }
    public void OnGrab(SelectEnterEventArgs args)
    {
        grabbed = true;
    }
    void OnExplode(ActivateEventArgs args)
    {
        explode();
    }
}
