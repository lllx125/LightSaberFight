using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightsaber : MonoBehaviour
{
    public float x_pos;
    private bool fullExtend;
    private bool fullShrink;
    private bool isLight;
    private bool isHold;
    private float t;
    public AudioSource extendSound;
    private Vector3 pre_pos;
    public AudioSource swaySound;
    public AudioSource hitSound;
    void Start()
    {
        fullShrink = true;
        fullExtend = false;
        isLight = false;
        t = 0;
        pre_pos = transform.position;
    }

    void Update()
    {

        if (!isHold)
        {
            Timer();
        }
        if (isLight)
        {
            Light();
        }
        else
        {
            if (!fullShrink)
            {
                Shrink();
            }
        }
        pre_pos = transform.position;
    }

    public void Activate()
    {
        isLight = true;
        fullShrink = false;
        Light lightComp = this.gameObject.transform.GetChild(8).GetComponent<Light>();
        lightComp.intensity = 200;
        lightComp = this.gameObject.transform.GetChild(9).GetComponent<Light>();
        lightComp.intensity = 200;
        extendSound.Play();
    }

    public void Deactivate()
    {
        fullExtend = false;
        isLight = false;
        Light lightComp = this.gameObject.transform.GetChild(8).GetComponent<Light>();
        lightComp.intensity = 0;
        lightComp = this.gameObject.transform.GetChild(9).GetComponent<Light>();
        lightComp.intensity = 0;

    }
    public void Throw()
    {
        isHold = false;
        Deactivate();
        t = 0;
    }
    public void Grab()
    {
        isHold = true;
        this.gameObject.transform.GetChild(10).GetComponent<Light>().intensity = 0;
    }
    void Timer()
    {
        t += Time.deltaTime;
        if (t > 7)
        {
            transform.localPosition = new Vector3(x_pos, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            this.gameObject.transform.GetChild(10).GetComponent<Light>().intensity = 100;
        }
    }
    void Light()
    {
        if (!fullExtend)
        {
            Extend();
        }
        Vector3 v = (transform.position - pre_pos) / Time.deltaTime;
        if (v.magnitude > 3 && !swaySound.isPlaying)
        {
            swaySound.Play();
        }
    }
    void Extend()
    {
        for (int i = 1; i <= 5; i++)
        {
            this.gameObject.transform.GetChild(2 + i).transform.Translate(0, Time.deltaTime * i * 0.5f, 0);
            if (this.gameObject.transform.GetChild(2 + i).transform.localPosition.y > 0.14f * i)
            {
                this.gameObject.transform.GetChild(2 + i).transform.localPosition = new Vector3(0, 0.14f * i, 0);
                fullExtend = true;
            }
        }
    }

    void Shrink()
    {
        for (int i = 1; i <= 5; i++)
        {
            this.gameObject.transform.GetChild(2 + i).transform.Translate(0, -Time.deltaTime * i * 0.5f, 0);
            if (this.gameObject.transform.GetChild(2 + i).transform.localPosition.y < 0)
            {
                this.gameObject.transform.GetChild(2 + i).transform.localPosition = new Vector3(0, 0, 0);
                fullShrink = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (fullExtend)
        {

            if (other.name == "Drone")
            {
                if (!hitSound.isPlaying)
                {
                    hitSound.Play();
                }
                Drone dr = other.GetComponent<Drone>();
                dr.hitted();
            }
            if (other.name == "Rock")
            {
                if (!hitSound.isPlaying)
                {
                    hitSound.Play();
                }
                Stone st = other.GetComponent<Stone>();
                st.explode();
            }
            if (other.name == "Bullet")
            {
                if (!hitSound.isPlaying)
                {
                    hitSound.Play();
                }
                Bullet bu = other.GetComponent<Bullet>();
                bu.ReverseSpeed();
                bu.isHit = true;
            }
        }
    }

}
