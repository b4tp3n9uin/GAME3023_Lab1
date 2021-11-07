using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scirptable object for the Player Data
[CreateAssetMenu(fileName ="PlayerData", menuName ="Data/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    [Header("Player Position")]
    public Vector3 PlayerPosition;
}
