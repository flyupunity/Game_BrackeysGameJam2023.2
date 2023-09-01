 using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class AnimationEvents : MonoBehaviour
{
    [Header("Final Kat Scene Atributs")]
    #region Final Kat Scene
    [SerializeField] private Dialogue dialogueScript;
    [SerializeField] private GameObject winnerWindow;
    #endregion

    public void ActiveUI_AnimationEvent()
    {
        if (GetComponent<AudioSource>()) GetComponent<AudioSource>().enabled = true;
        winnerWindow.SetActive(true);
        StartCoroutine(timePause(2f));
    }
    IEnumerator timePause(float wait)
    {
        yield return new WaitForSeconds(wait);
        if (winnerWindow.GetComponent<Dialogue>()) winnerWindow.GetComponent<Dialogue>().StartDialogue();
        winnerWindow.GetComponent<AudioSource>().enabled = true;
    }
}