using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Dialogue dialogue;

    bool is_talking = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
