using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject quarter;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (quarter.transform.position.x > transform.position.x + 2)
        {
            transform.position = new Vector3(quarter.transform.position.x - 2, transform.position.y, transform.position.z);
        }
        else if (quarter.transform.position.x < transform.position.x - 4) {
            transform.position = new Vector3(quarter.transform.position.x + 4, transform.position.y, transform.position.z);
        }

        if (quarter.transform.position.y > transform.position.y + 2)
        {
            transform.position = new Vector3(transform.position.x, quarter.transform.position.y - 2, transform.position.z); 
        } 
        else if (quarter.transform.position.y < transform.position.y - 2)
        {
            transform.position = new Vector3(transform.position.x, quarter.transform.position.y + 2, transform.position.z); 
        } 
    }

    public void flipFlopSound()
    {
        audioSource.Play();
    }
}
