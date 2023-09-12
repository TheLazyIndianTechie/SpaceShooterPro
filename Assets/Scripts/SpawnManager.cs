using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform enemyContainer;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float waitDuration;
    

    // Start is called before the first frame update
    void Start()
    {
        if (prefab == null || enemyContainer == null) return;
        StartCoroutine(SpawnRoutine(waitDuration));   
    }

    private IEnumerator SpawnRoutine(float duration = 5.0f)
    {
        while (true)
        {
            GameObject go = Instantiate(prefab, enemyContainer.position, Quaternion.identity); //Instantiate prefab at spawn position
            go.transform.parent = enemyContainer.transform;
            
            #if UNITY_EDITOR
            Debug.Log("Launched Enemy: " + go.name );
            #endif
            
            yield return new WaitForSeconds(duration); // Wait 5 seconds
        }
    }
}
