using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection = Vector3.down;
    [SerializeField] private float _speed = 4.0f;
    private void Start()
    {
        //Set and cache the vector3 direction
        _moveDirection = Vector3.down;
    }

    private void Update()
    {
        // Move enemy when spawned at 4 m/s
        transform.Translate(_moveDirection * (_speed * Time.deltaTime));
        
        //if enemy goes off screen, respawn it with a random x position. 
        if (transform.position.y <= -6f)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy Hit: " + other.gameObject.name);
        
        //If enemy collides with player, destroy player and then destroy us
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        
        //if enemy collides with laser, destroy laser and then us
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
