using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameText : MonoBehaviour
{
    // public bool isTesting = false;
    public float revealDelay = 0.1f; // Delay between each letter appearing
    private List<GameObject> letters = new List<GameObject>();

    void Start()
    {
        // Store child letters in order and deactivate them
        foreach (Transform child in transform)
        {
            letters.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
        Trigger();
    }
    // void Update(){
    //     if (isTesting){
    //         if (Input.GetKeyDown(KeyCode.Space)){
    //             Trigger();
    //         }
    //     }
    // }
    public void Trigger()
    {
        StopAllCoroutines();
        StartCoroutine(RevealLetters());
    }

    private IEnumerator RevealLetters()
    {
        foreach (GameObject letter in letters)
        {
            letter.SetActive(true);
            yield return new WaitForSeconds(revealDelay);
        }
    }
}
