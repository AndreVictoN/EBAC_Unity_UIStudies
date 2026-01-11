using System.Collections;
using NaughtyAttributes;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float timeBetweenLetters = .1f;

    public string sentence;

    [Button]
    public void StartTyping()
    {
        StopAllCoroutines();
        StartCoroutine(Type(sentence));
    }

    IEnumerator Type(String textToType)
    {
        textMeshPro.text = "";

        foreach (char letter in textToType.ToCharArray())
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }
}
