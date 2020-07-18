using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform player;

    #region Singleton
    public static GameManager instance { get; private set; }
    void Awake()
    {
        instance = this;
    }
    #endregion

    public Transform Player
    {
        get
        {
            return player;
        }
    }
    
    void EnableCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
