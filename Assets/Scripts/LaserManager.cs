using UnityEngine;
using UnityEngine.Serialization;

public class LaserManager : MonoBehaviour
{
    public float speed = 2f;
    
    private void Update()
    {
        transform.Translate(Vector3.up * (speed * Time.deltaTime));
        
        //if the position is out of the screen
        // destroy this object

        if (transform.position.y >= 7f)
        {
            Destroy(gameObject);
        }
    }
}
