using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponenet;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    private int index;

    // Update is called once per frame
    void Update()
    {
        // this simply speeds the dialogue up and moves to the next dialgoue on press//
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponenet.text == lines[index])
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

    //this method starts the dialogue sequence, 
    //at first the gameobject is set to false because we dont want it to appear on screen before the talking starts
    public void StartDialogue()
    {
        gameObject.SetActive(true);
        textComponenet.text = string.Empty;
        index = 0;
        StartCoroutine(TypeLine());
    }

    //types chracters according to the desired speed we want
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponenet.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    //skips to the next line and empties the current text box//
    void NextLine()
    {
        if (index < lines.Length - 1)
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
