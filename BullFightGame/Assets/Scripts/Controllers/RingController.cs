using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : Controller
{
    [SerializeField] private GameObject[] playerSpawnPoints;

    public GameObject GetPlayerSpawnPoint(int index) => playerSpawnPoints[index]; 
}
