using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    [SerializeField] GameObject _block;
    [SerializeField] GameObject _partTail;
    [SerializeField] GameObject _block2;
    [SerializeField] GameObject _finish;

    private void Awake()
    {
       
        Time.timeScale = 0;
        for (int z = 0; z < 100; z += 8)
            for (int x = -4; x < 4; x+=2)
            {
                if (Random.value > 0.3f)
                    if(x!=-4)
                    Instantiate(_block2).transform.position = new Vector3(x-0.14f, 0, z-2);
                if(Random.value>0.7f)
                    Instantiate(_partTail).transform.position = new Vector3(x+1, 0.3f , z-4);
                if (Random.value > 0.3f)
                    Instantiate(_block).transform.position= new Vector3(x, 0, z);
            }
        Instantiate(_finish).transform.position = new Vector3(-4.5f, 0, 110);
        Time.timeScale = 1;
    }
}
