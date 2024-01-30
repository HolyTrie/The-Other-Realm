using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    bool is_talking = false;

    //if the player presses "E" it will invoke a talking with the character//
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && !is_talking)
            {
                is_talking = true;
                dialogue.StartDialogue();
            }
            if (!dialogue.isActiveAndEnabled)
                is_talking = false;
        }
    }
}