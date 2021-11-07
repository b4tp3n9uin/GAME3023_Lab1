using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSaver : MonoBehaviour
{
    public static UnityEvent OnSaveEvent = new UnityEvent();
    public static UnityEvent OnLoadEvent = new UnityEvent();

    public PlayerDataSO playerData;
    public PlayerBehaviour player;

    void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();
    }

    //Saves player position
    public void Save()
    {
        OnSaveEvent.Invoke();
        PlayerPrefs.Save();
        playerData.PlayerPosition = player.transform.position;
        Debug.Log("Saved");
    }

    //loads player position
    public void Load()
    {
        OnLoadEvent.Invoke();
        player.transform.position = playerData.PlayerPosition;
        Debug.Log("Loaded");
    }

    // For save button
    public void OnSaveButtonPressed()
    {
        Save();
    }

    // For load button
    public void OnLoadButtonPressed()
    {
        Load();
    }
}
