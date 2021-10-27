using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData", menuName ="Data/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    [Header("Player Position")]
    public Vector3 PlayerPosition;
}
