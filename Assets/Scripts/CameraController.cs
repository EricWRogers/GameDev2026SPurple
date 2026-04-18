using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject quarter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (quarter.transform.position.x > transform.position.x + 4)
        {
            transform.position = new Vector3(quarter.transform.position.x - 4, transform.position.y, transform.position.z);
        }
        else if (quarter.transform.position.x < transform.position.x - 4) {
            transform.position = new Vector3(quarter.transform.position.x + 4, transform.position.y, transform.position.z);
        }
    }
}
