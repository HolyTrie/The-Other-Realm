using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string sceneName;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
                SceneManager.LoadScene(sceneName);
        }
    }
}
