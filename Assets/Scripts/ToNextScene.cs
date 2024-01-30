using UnityEngine;
using UnityEngine.SceneManagement;

//Transfers the player to the next scene when he enters a trigger area//
public class ToNextScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
