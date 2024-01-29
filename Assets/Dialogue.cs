using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponenet;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Update is called once per frame
    void Update()
    {
        // this simply speeds the dialogue up.
        if(Input.GetMouseButtonDown(0))
        {
            if(textComponenet.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponenet.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        gameObject.SetActive(true);
        textComponenet.text = string.Empty;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponenet.text += c;
            yield return new WaitForSeconds(textSpeed); 
        }
    }

    void NextLine()
    {
        if (index < lines.Length -1)
        {
            index++;
            textComponenet.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
