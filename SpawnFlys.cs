using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlys : MonoBehaviour
{
    [SerializeField] GameObject flyPrefab;
    [SerializeField] int numerFlys = 10;
    private void Start()
    {
        for(int i=0; i<= numerFlys; i++)
        {
            GameObject flyP;
            flyP = Instantiate(flyPrefab);
            int x, y, z;
            x = Random.Range(-10, 10);
            y = Random.Range(1, 5);
            z = Random.Range(-10, 10);
            flyP.transform.position = new Vector3(x, y, z);
        }
    }
}
