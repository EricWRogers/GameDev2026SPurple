using UnityEngine;

public class corpseScript : MonoBehaviour
{
    int timer = 400;
    void Start()
    {
        timer = 1000;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(timer);
        if (timer < 1)
        {
            Destroy(gameObject);
        }
        else timer--;
    }
}
