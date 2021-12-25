using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] GameObject _snake;
    
   
    private void OnTriggerEnter(Collider other)
    {
        _snake = GameObject.Find("Snake");
        if (other.CompareTag("PartTail"))
        {
            _snake.GetComponent<Snake>().addTail(other.gameObject.GetComponent<PartTail>().CountTail);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Block"))
        {
            _snake.GetComponent<Snake>().DelTail();
        }
        
    }
   


}
