using UnityEngine;

public class Player : MonoBehaviour
{
    // Initialize variables for player spawn position
    [SerializeField] private Transform playerSpawnPos;
    [SerializeField] private float speed = 2f;

    // Start is called before the first frame update
    private void Start()
    {
        //Better to return if inspector value hasn't been assigned
        if (playerSpawnPos == null) return;
        
        //Initialize the player to the target spawn origin if assigned.
        transform.position = playerSpawnPos.position;
    }

    // Update is called once per frame
    private void Update()
    {
        //Get both horizontal and vertical input per frame 
        float horizontalInput = Input.GetAxis("Horizontal"), verticalInput = Input.GetAxis("Vertical");
        
        //Cache the Vector3 input within update for reuse
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        
        //Move the player by taking the cached horizontal and vertical input per frame in
        //the x and y directions multiplied by time and speed
        Transform playerTransform;
        (playerTransform = transform).Translate(direction * (Time.deltaTime * speed));
        
        //Create a local cached variable of player's position
        Vector3 playerPosition = playerTransform.position;
        
        //Check and limit player's vertical movement
        if (playerPosition.y >= 0) playerTransform.position = new Vector3(transform.position.x,0,0);
        else if (transform.position.y <= - 3.8f) playerTransform.position = new Vector3(transform.position.x, -3.8f, 0);
        
        //Check and overlap player's horizontal movement
        if (playerPosition.x >= 12f) playerTransform.position = new Vector3(-12, transform.position.y, 0);
        else if (transform.position.x <= -12f) playerTransform.position = new Vector3(12f, transform.position.y, 0);
        
    }
}
