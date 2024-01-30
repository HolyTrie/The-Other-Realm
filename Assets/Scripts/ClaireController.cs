using UnityEngine;

public class ClaireController : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;

    // Update is called once per frame
    public void NpcDialogue()
    {
        dialogue.StartDialogue();
    }
}