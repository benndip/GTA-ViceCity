using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderAction : MonoBehaviour
{
    GameManager gameManager;
    InputManager inputManager;
    public GameObject mainCamera;
    public GameObject shopCamera;

    public Text notificationText;
    public GameObject priceText;

    public bool playerTriggered = false;
    bool inShop;


    private void Start()
    {
        shopCamera.SetActive(false);
        notificationText.gameObject.SetActive(false);
        priceText.SetActive(false);

        gameManager = FindAnyObjectByType<GameManager>();
        inputManager = FindAnyObjectByType<InputManager>();

    }

    private void Update()
    {
        if (playerTriggered)
        {
            if(inputManager.interactInput && inShop == false)
            {
                mainCamera.SetActive(false);
                shopCamera.SetActive(true);
                priceText.SetActive(true);
                notificationText.gameObject.SetActive(false);
                inShop = true;
            }
            else if(inputManager.interactInput && inShop == true)
            {
                mainCamera.SetActive(true);
                shopCamera.SetActive(false);
                priceText.SetActive(false);
                notificationText.gameObject.SetActive(false);
                inShop = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            notificationText.text = "Press E";
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
