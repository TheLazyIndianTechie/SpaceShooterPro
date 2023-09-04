using UnityEngine;

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
}
