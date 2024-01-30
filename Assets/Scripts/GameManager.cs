using UnityEngine;


//This is a singelton controller for the game manager, right now it only follows as trigger to count defeated enemies//
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private int enemyCount;
    public int EnemyCount { get { return enemyCount; } }

    private ClaireController _claire;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        _claire = GameObject.Find("Claire").GetComponent<ClaireController>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //after enemy is defeated just add it to the count//
    public void AddDefeatedEnemy()
    {
        ++enemyCount;
        if (enemyCount == 3)
        {
            _claire.NpcDialogue();
        }
    }
}
