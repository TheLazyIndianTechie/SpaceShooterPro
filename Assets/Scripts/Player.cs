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
        
        //TODO: Remove redundant code 
        // transform.Translate(Vector3.right * (horizontalInput * (speed * Time.deltaTime)));
        // transform.Translate(Vector3.up * (verticalInput * (speed * Time.deltaTime)));
        // REDUNDANT CODE -- 
        
        //Move the player by taking the horizontal and vertical input per frame in
        //the x and y directions multiplied by time and speed
        transform.Translate(horizontalInput, verticalInput, 0 * Time.deltaTime * speed);
        
    }
}
