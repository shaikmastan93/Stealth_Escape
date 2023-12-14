using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private Transform _playerTransform; // Reference to the player GameObject
    public GameObject bulletPrefab; // Prefab of the bullet GameObject
    public Transform firePoint; // Point from where the bullet is fired
    public float bulletForce = 10f; // Force with which the bullet is fired

    private bool isShooting = false; // Flag to check if the enemy is shooting
    [SerializeField]
    private float rotationSpeed = 6;
    public Animator _animator;
   

    private void Awake()
    {
        _playerTransform = FindObjectOfType<PlayerTest>().GetComponent<Transform>();
   }
}
