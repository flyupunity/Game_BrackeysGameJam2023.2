using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureСhest : MonoBehaviour
{
    [SerializeField] private LifeTime lifeTime;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            GetComponent<Animator>().enabled = true;
            if (gameObject.tag == "Mem")
            {
                PlayerPrefs.SetInt("Mem", 1);
                GameObject.FindGameObjectWithTag("Manager").GetComponent<UGS_Analytics>().MemCustomEvent();
            }
        }
        print(PlayerPrefs.GetInt("Mem"));
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            GetComponent<Animator>().enabled = true;
            if (gameObject.tag == "Mem")
            {
                PlayerPrefs.SetInt("Mem", 1);
                GameObject.FindGameObjectWithTag("Manager").GetComponent<UGS_Analytics>().MemCustomEvent();
            }
        }
        print(PlayerPrefs.GetInt("Mem"));
    }
    public void StartLifeTime()
    {
        StartCoroutine(lifeTime.lifeTimeCoroutine());
        GetComponent<Animator>().enabled = false;
        Destroy(this);
    }
}
