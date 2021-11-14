using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelZone : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float rotationSpeed = 2f;

    private int nextLevel;


    private void Start()
    {
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == player.gameObject.name)
        {
            if (nextLevel < 4)
            {
                SceneManager.LoadScene(nextLevel);
            }
            else
            {
                SceneManager.LoadScene("Win_Scene");
            }

        }

    }
}
