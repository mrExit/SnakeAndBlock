using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTail : MonoBehaviour
{
    [SerializeField] TextMesh _text;
    public int CountTail = 1;
    private void Awake()
    {
        CountTail = Random.Range(1, 10);
        _text.text = CountTail.ToString();
    }
}
