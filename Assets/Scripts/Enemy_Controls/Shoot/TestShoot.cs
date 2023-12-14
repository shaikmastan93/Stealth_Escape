//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TestShoot : MonoBehaviour
//{
//    public float minDistance = 10f; // Minimum distance to shoot at player
//    public float maxDistance = 20f; // Maximum distance to stop shooting at player
//    private Transform _playerTransform; // Reference to the player GameObject
//    public GameObject bulletPrefab; // Prefab of the bullet GameObject
//    public Transform firePoint; // Point from where the bullet is fired
//    public float bulletForce = 10f; // Force with which the bullet is fired

//    private bool isShooting = false; // Flag to check if the enemy is shooting
//    [SerializeField]
//    private float rotationSpeed = 6;
//    public  Animator _animator;
//    private Transform _transform;



//    private void Awake()
//    {
//        _playerTransform = FindObjectOfType<PlayerTest>().GetComponent<Transform>();
//        _transform = GetComponent<Transform>();
//       // _animator = GetComponent<Animator>();
   



//    }

//    void FixedUpdate()
//    {
//        // Check if the player is within the minimum distance
//        if (Vector3.Distance(transform.position, _playerTransform.transform.position) <= minDistance)
//        {
//            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.Normalize(_playerTransform.position - transform.position)), rotationSpeed);
//            // Start shooting if not already shooting
//            if (!isShooting)
//            {
//                _animator.SetBool("Fire", true);
//                isShooting = true;
//                InvokeRepeating("Shoot", 0f, 1f); // Shoot every 1 second

//            }
//        }
//        // Check if the player is beyond the maximum distance
//        else if (Vector3.Distance(transform.position, _playerTransform.transform.position) >= maxDistance)
//        {
//            // Stop shooting if already shooting
//            if (isShooting)
//            {
//                _animator.SetBool("Fire", false);
//                isShooting = false;
//                CancelInvoke(); // Stop shooting
//            }
//        }
//    }


//    public void StartFiring()
//    {
//        if (Vector3.Distance(transform.position, _playerTransform.transform.position) <= minDistance)
//        {
//            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.Normalize(_playerTransform.position - transform.position)), rotationSpeed);

//            if (!isShooting)
//            {
//                _animator.SetBool("Fire", true);
//                isShooting = true;
//                InvokeRepeating("Shoot", 0f, 1f); // Shoot every 1 second

//            }
//        }
//        else if (Vector3.Distance(transform.position, _playerTransform.transform.position) >= maxDistance)
//        {
//            StopFiring();
//        }



//    }
//    public void StopFiring()
//    {
//        if (isShooting)
//        {
//            _animator.SetBool("Fire", false);
//            isShooting = false;
//            CancelInvoke(); // Stop shooting
//        }
//    }

//    void Shoot()
//    {
//        // Create the bullet GameObject
//        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//        Rigidbody rb = bullet.GetComponent<Rigidbody>();

//        // Add force to the bullet in the direction of the player
//        Vector3 direction = (_playerTransform.transform.position - firePoint.position).normalized;
//        rb.AddForce(direction * bulletForce, ForceMode.Impulse);
//    }
//}
