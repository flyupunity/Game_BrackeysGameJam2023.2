using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureСhest : MonoBehaviour
{
    [SerializeField] private LifeTime lifeTime;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() )
        {
            GetComponent<Animator>().enabled = true;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            GetComponent<Animator>().enabled = true;
        }
    }
    public void StartLifeTime()
    {
        StartCoroutine(lifeTime.lifeTimeCoroutine());
        GetComponent<Animator>().enabled = false;
        Destroy(this);
    }
}
