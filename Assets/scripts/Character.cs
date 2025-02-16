using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public GameObject health;
    private int HP;
    public AudioClip hurt;
    private UnityEngine.UI.Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        HP = 20;
        healthBar = health.GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            SceneManager.LoadScene("Dead");
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.name == "Rock")
        {
            AudioSource.PlayClipAtPoint(hurt, transform.position, 1);
            HP -= 2;
            healthBar.fillAmount -= 0.1f;
        }
        if (other.name == "Bullet")
        {
            AudioSource.PlayClipAtPoint(hurt, transform.position, 1);
            HP -= 1;
            healthBar.fillAmount -= 0.05f;
            other.GetComponent<Bullet>().explode();
        }
    }
}
