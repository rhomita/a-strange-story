using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera cam;

    public Camera Cam
    {
        get => cam;
    }
}