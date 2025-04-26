using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Player Rifle Things")]
    public GameObject pistolGameObjectPrefab;
    public GameObject akmGameObjectPrefab;
    public GameObject m416GameObjectPrefab;

    public bool pistolPrefab;
    public bool akmPrefab;
    public bool m416Prefab;

    bool rifle1Active;
    bool rifle2Active;
    bool rifle3Active;

    [Header("Player Money and Kills")]
    public int playerMoney = 150;
}
