using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibertyScript : MonoBehaviour
{
    bool liberty;


    void Awake()
    {
        liberty = true;
    }
    void Start()
    {
        if (!liberty)
        {
            transform.position = new Vector2(Random.Range(-16f, 25), Random.Range(-3f, 30f));
            liberty = true;
        }
    }
    IEnumerator WaitLiberty()
    {
        yield return new WaitForSeconds(3);
        if (!liberty) transform.position = new Vector2(Random.Range(-16f, 25), Random.Range(-3f, 30f));
        liberty = true;

    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name == "Dno" || other.gameObject.name == "Border")
        {
            StartCoroutine(WaitLiberty());
            liberty = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Dno" || other.gameObject.name == "Border")
        {
            StartCoroutine(WaitLiberty());
            liberty = false;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Dno" || other.gameObject.name == "Border") liberty = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Dno" || other.gameObject.name == "Border") liberty = true;
    }
}
