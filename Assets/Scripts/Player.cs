using UnityEngine;

public class Player : MonoBehaviour
{
    // Initialize variables for player spawn position
    [SerializeField] private Transform _playerSpawnPos;
    [SerializeField] private float _speed = 2f, _laserSpeed = 2f;
    [SerializeField] private GameObject _laserPrefab;
    private LaserManager _laserManager;
    [SerializeField] private Vector3 _laserSpawnOffset = new Vector3(0, 0.8f, 0);

    [SerializeField] private float _fireRate = 0.5f;
    private float _canFire = -1.0f;
    
    
    private void Awake()
    {
        _laserManager = _laserPrefab.GetComponent<LaserManager>();
    }
    

    // Start is called before the first frame update
    private void Start()
    {
        //Better to return if inspector value hasn't been assigned
        if (_playerSpawnPos == null) return;
        
        //Initialize the player to the target spawn origin if assigned.
        transform.position = _playerSpawnPos.position;
    }

    // Update is called once per frame
    private void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire) Fire();
    }

    private void Fire()
    {
        // Setting up the speed here so it can be changed later during runtime 
        _laserManager.speed = _laserSpeed;
        
        //Set cooldown 
        _canFire = Time.time + _fireRate;
            
        //Instantiate game object
        Instantiate(_laserPrefab, transform.position + _laserSpawnOffset, Quaternion.identity);


    }

    private void CalculateMovement()
    {
        //Get both horizontal and vertical input per frame 
        float horizontalInput = Input.GetAxis("Horizontal"), verticalInput = Input.GetAxis("Vertical");

        //Cache the Vector3 input within update for reuse
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        //Move the player by taking the cached horizontal and vertical input per frame in
        //the x and y directions multiplied by time and speed
        Transform playerTransform;
        (playerTransform = transform).Translate(direction * (Time.deltaTime * _speed));

        //Create a local cached variable of player's position
        Vector3 playerPosition = playerTransform.position;

        //Check and limit player's vertical movement
        //Leaving in legacy code for reference
        // if (playerPosition.y >= 0) playerTransform.position = new Vector3(transform.position.x, 0, 0);
        // else if (transform.position.y <= -3.8f) playerTransform.position = new Vector3(transform.position.x, -3.8f, 0);
        //Clamping vertical y position to remove if statements. 
        playerTransform.position = new Vector3(playerPosition.x, Mathf.Clamp(playerPosition.y, -3.8f, 0), 0);

        //Check and overlap player's horizontal movement
        if (playerPosition.x >= 12f) playerTransform.position = new Vector3(-12, transform.position.y, 0);
        else if (transform.position.x <= -12f) playerTransform.position = new Vector3(12f, transform.position.y, 0);
    }
}
