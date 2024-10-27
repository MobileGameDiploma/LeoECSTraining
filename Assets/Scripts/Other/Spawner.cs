using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private int Amount;

    private void Awake()
    {
        for(int i = 0; i < Amount; i++)
        {
            Instantiate(Prefab);
        }
    }
}
