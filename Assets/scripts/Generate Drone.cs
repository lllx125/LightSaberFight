using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine;


public class GenerateDrone : MonoBehaviour
{
    public GameObject droneObj;
    public float intervalUpperBound;
    public float intervalLowerBound;
    private float t;
    private float interval;
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

        int[] signz = { 1, 1, -1, -1, -1, -1, -1, -1, -1, -1 };
        float x = Random.Range(-20, 20);
        float z = Random.Range(20, 30) * signz[(int)Random.Range(0, 10)];
        Vector3 pos = new Vector3(x, Random.Range(3, 10), z);
        GameObject drone = Instantiate(droneObj, pos, Random.rotation);
        drone.name = "Drone";

    }
}
