using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
public class CameraPositionManager : MonoBehaviour
{

    public Transform[] cameraPositions;
    public int currentPosIndex = 0;
    public int itemPrice = 50;

    private GameManager gameManager;
    private ColliderAction colliderAction;

    public Text priceText;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        colliderAction = FindAnyObjectByType<ColliderAction>();

        transform.position = cameraPositions[currentPosIndex].position;
        transform.rotation = cameraPositions[currentPosIndex].rotation;

        priceText.text = $"AKM Price: ${itemPrice}";

    }

    private void Update()
    {
    
    }

    public void MoveCamera()
    {
        transform.position = cameraPositions[currentPosIndex].position;
        transform.rotation = cameraPositions[currentPosIndex].rotation;
    }

    public void ChangeItemPrice(int currentPosIndex)
    {
        switch (currentPosIndex)
        {
            case 1:
                itemPrice = 70;
                priceText.text = $"M416 Price: ${itemPrice}";
                break;
            case 2:
                itemPrice = 35;
                priceText.text = $"Pistol Price: ${itemPrice}";
                break;
            default:
                itemPrice = 50;
                priceText.text = $"AKM Price: ${itemPrice}";
                break;
        }
    }

    public void NextCameraPosition()
    {
       currentPosIndex = (currentPosIndex + 1) % cameraPositions.Length;
       ChangeItemPrice(currentPosIndex);
       MoveCamera();
    }

    public void PreviousCameraPosition()
    {
       currentPosIndex = (currentPosIndex - 1 + cameraPositions.Length) % cameraPositions.Length;
       ChangeItemPrice(currentPosIndex);
       MoveCamera();
    }

    public void BuyItem()
    {
        if(currentPosIndex == 0 && colliderAction.playerTriggered == true && gameManager.akmPrefab == false)
        {
            itemPrice = 50;
            if(gameManager.playerMoney > itemPrice)
            {
                gameManager.playerMoney -= itemPrice;
                // Debug.Log("Item bought for: " + "$" + itemPrice);
                gameManager.akmPrefab = true;
            }
        }

        if(currentPosIndex == 1 && colliderAction.playerTriggered == true && gameManager.m416Prefab == false)
        {
            itemPrice = 70;
            if(gameManager.playerMoney > itemPrice)
            {
                gameManager.playerMoney -= itemPrice;
                // Debug.Log("Item bought for: " + "$" + itemPrice);
                gameManager.m416Prefab = true;
            }
        }

        if(currentPosIndex == 2 && colliderAction.playerTriggered == true && gameManager.pistolPrefab == false)
        {
            itemPrice = 35;
            if(gameManager.playerMoney > itemPrice)
            {
                gameManager.playerMoney -= itemPrice;
                // Debug.Log("Item bought for: " + "$" + itemPrice);
                gameManager.pistolPrefab = true;
            }
        }
    }

    
}
