using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    void Start()
    {
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Increment(int s)
    {
        score += s;
    }

    public int s()
    {
        return score;
    }

    public void clear()
    {
        score = 0;
    }

}
