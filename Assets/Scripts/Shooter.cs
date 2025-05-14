using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject dartPrefab;
    public Transform firePoint;

    public void Shooting()
    {
        Instantiate(dartPrefab, firePoint.position, Quaternion.identity);
    }
}

