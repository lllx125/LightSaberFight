using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    // Start is called before the first frame update
    private ScoreBoard sb;
    void Start()
    {
        sb = GameObject.Find("Score").GetComponent<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Score:" + sb.s();
    }
}
