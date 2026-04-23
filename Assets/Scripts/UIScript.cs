using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public TMP_Text deathField;
    public GameObject player;
    public PlayerController playerController;
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    public void FixedUpdate()
    {
        deathField.text = playerController.deaths.ToString();
    }

}