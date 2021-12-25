using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int _life = 1;
    [SerializeField] GameObject _coube;
    [SerializeField] TextMesh _text;    

    private void Awake()
    {
        Create();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            Defence();
        }
    }
    
    public void Defence()
    {
        _life--;
        _text.text = _life.ToString();
        if (_life <= 0)
        {
            
            Destroy(_coube);
        }
    }

    private void ChengedLife()
    {
        _life = Random.Range(1, 7);
        _text.text = _life.ToString();
    }

    private void Create()
    {
        ChengedLife();
        
        MeshRenderer mr = _coube.GetComponent<MeshRenderer>();
        mr.material = mr.materials[Random.Range(0, mr.materials.Length)];
    }
    
}
