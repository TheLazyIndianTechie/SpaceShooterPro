using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection = Vector3.down;
    [SerializeField] private float speed = 4.0f;
    private void Start()
    {
        //Set and cache the vector3 direction
        moveDirection = Vector3.down;
    }

    private void Update()
    {
        // Move enemy when spawned at 4 m/s
        transform.Translate(moveDirection * (speed * Time.deltaTime));
        
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
            // Get the component player from collision
            Player player = other.transform.GetComponent<Player>();
            
            // Check if GetComponent is working and do Damage by calling the remote method
            if (player != null) player.Damage();

            // Destroy us, the bad bad enemy
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
