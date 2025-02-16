using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine;


public class GenerateStones : MonoBehaviour
{
    public GameObject[] stones;
    public float intervalUpperBound;
    public float intervalLowerBound;
    private float t;
    private float interval;
    public AudioClip explodeSound;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        interval = Random.Range(intervalLowerBound, intervalUpperBound);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > interval)
        {
            Throw();

            t = 0;
            interval = Random.Range(intervalLowerBound, intervalUpperBound);
        }
    }

    void Throw()
    {
        float x = Random.Range(-30, 30);
        float z = Random.Range(-30, 30);
        Vector3 pos = new Vector3(x, (float)Sqrt(5500 - x * x + z * z), z);
        GameObject stone = Instantiate(stones[(int)Random.Range(0, stones.Length)], pos, Random.rotation);
        stone.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
        stone.name = "Rock";
        stone.GetComponent<MeshCollider>().convex = true;
        Rigidbody rb = stone.AddComponent<Rigidbody>();
        rb.useGravity = false;
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable sg = stone.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        sg.useDynamicAttach = true;
        MeshDestroy md = stone.AddComponent<MeshDestroy>();
        Stone st = stone.AddComponent<Stone>();
        st.crash = md;
        st.rb = rb;
        st.clip = explodeSound;
        AudioSource au = stone.AddComponent<AudioSource>();
        au.playOnAwake = false;
        au.clip = explodeSound;
    }
}
