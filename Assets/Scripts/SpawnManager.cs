using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float waitDuration;
    

    // Start is called before the first frame update
    void Start()
    {
        if (prefab == null || spawnPos == null) return;
        StartCoroutine(SpawnRoutine(waitDuration));   
    }

    private IEnumerator SpawnRoutine(float duration = 5.0f)
    {
        while (true)
        {
            GameObject go = Instantiate(prefab, spawnPos.position, Quaternion.identity); //Instantiate prefab at spawn position
            
            #if UNITY_EDITOR
            Debug.Log("Launched Enemy: " + go.name );
            #endif
            
            yield return new WaitForSeconds(duration); // Wait 5 seconds
        }
    }
}
