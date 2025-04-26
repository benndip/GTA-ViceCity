using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ColliderAction : MonoBehaviour
{
    public GameManager gameManager;
    public InputManager inputManager;
    public GameObject mainCamera;
    public GameObject shopCamera;
    public Text notificationText;
    public Text priceText;
    public bool playerTriggered = false;
    bool inShop;


    private void Start()
    {
        shopCamera.SetActive(false);
        notificationText.gameObject.SetActive(false);
        priceText.gameObject.SetActive(false);

        gameManager = FindAnyObjectByType<GameManager>();
        inputManager = FindAnyObjectByType<InputManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            notificationText.text = "Press F";
            notificationText.gameObject.SetActive(true);
            playerTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            notificationText.gameObject.SetActive(false);
            playerTriggered = false;
        }
    }
}
