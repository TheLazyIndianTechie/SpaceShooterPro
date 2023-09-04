using UnityEngine;

public class Laser : MonoBehaviour
{
    // Control the speed of the laser
    public float speed = 2f;
    private void Update()
    {
        //Set up the speed here so it can be changed later during runtime 
        transform.Translate(Vector3.up * (speed * Time.deltaTime));

        // Destroy the laser once it goes off screen
        if (transform.position.y >= 7f) Destroy(gameObject);
    }
}
