using UnityEngine;
using UnityEngine.SceneManagement;

public class portalScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D col)
    {
        SceneManager.LoadScene("Level_2");
    }

    // Update is called once per frame
}
