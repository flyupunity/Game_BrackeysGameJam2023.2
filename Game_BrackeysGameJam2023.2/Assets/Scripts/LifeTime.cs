using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeTime : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI m_TextMeshProUGUI;
    [SerializeField] private float m_Time;
    private float timer;
    public IEnumerator lifeTimeCoroutine()
    {
        timer = m_Time;
        //m_TextMeshProUGUI.text = timer.ToString();
        for (int i = 0; i < m_Time; i++)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            //m_TextMeshProUGUI.text = timer.ToString();
            if (timer <= 0)
            {
                gameObject.SetActive(false);
                //Destroy(gameObject);
                break;
            }
        }
        if (timer <= 0)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Bonus");
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Bonus");
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
