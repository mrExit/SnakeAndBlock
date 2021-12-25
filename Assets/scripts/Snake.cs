using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] GameObject _canvasLose;    
    [SerializeField] Camera _camera;
    [SerializeField] GameObject _plane;
    [SerializeField] float _distCamera = 13;
    [SerializeField] List<GameObject> _partTail;
    [SerializeField] float _sens=0.1f;
    [SerializeField] float _speedTail;
    [SerializeField] GameObject _tail;
    [SerializeField] float _speed;
    [SerializeField] ParticleSystem _particleDestroy;
    [SerializeField] AudioSource _audio;
    [SerializeField] AudioClip _addAudio;
    [SerializeField] AudioClip _loseAudio;

    private Vector3 _previousMousePosition;


    private void Update()
    {
        MoveSnake();
    }
    private void TailPosition(float speed)
    {
        
        int i = 1;
        while (i < _partTail.Count)
        {

            Vector3 endPosition = new Vector3(_partTail[i - 1].transform.position.x, _partTail[i].transform.position.y, _partTail[i].transform.position.z);
            _partTail[i].transform.position = Vector3.Lerp(_partTail[i].transform.position, endPosition, Time.deltaTime* speed);
            i++;       
        }
       
    }
    private void MoveSnake()
    {
        if (_partTail.Count != 0)
        {
            Vector3 targetCamera = new Vector3(_camera.transform.position.x, _camera.transform.position.y, _partTail[0].transform.position.z - _distCamera);
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetCamera, _speedTail * Time.deltaTime);
            transform.position += new Vector3(0, 0, _speed) * Time.deltaTime;
            Vector3 mousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.transform.position.y));
            Vector3 targetPosition = new Vector3(mousePosition.x, 1.5f , 0);
            Debug.Log(mousePosition.x);
            if (mousePosition.x>-5&&mousePosition.x<5)
                if (Input.GetMouseButton(0))
                {

                    Vector3 delta = targetPosition - _previousMousePosition;
                    
                //_partTail[0].transform.localPosition += new Vector3(delta.x * _sens, 0, 0) * Time.deltaTime;
                // _partTail[0].GetComponent<Rigidbody>().velocity = new Vector3(delta.x, 0, 0) * _sens;
                //_partTail[0].transform.localPosition = Vector3.Lerp (_partTail[0].transform.localPosition, new Vector3(targetPosition.x, _partTail[0].transform.localPosition.y, _partTail[0].transform.localPosition.z), _sens);
                _partTail[0].GetComponent<Rigidbody>().AddForce(delta*_sens*1000, ForceMode.VelocityChange);    
                TailPosition(_speedTail);
                }

                else
                    TailPosition(_speedTail);
            else TailPosition(_speedTail);
            _previousMousePosition = targetPosition;
            
        }
    }
    public void addTail(int count)
    {
        _audio.PlayOneShot(_addAudio);
        for (int x = 0; x < count; x++)
        {
            int i = _partTail.Count - 1;
            GameObject tail = Instantiate(_tail);
            tail.name += i;
            tail.transform.parent = gameObject.transform;
            tail.transform.position = new Vector3(_partTail[i].transform.position.x, _partTail[i].transform.position.y, _partTail[i].transform.position.z - 0.5f);
            _partTail.Add(tail);
        }
    }
    public void DelTail()
    {
        _particleDestroy.transform.position = _partTail[0].transform.position;
        _particleDestroy.Play();
        _audio.Play();
        Destroy(GameObject.Find(_partTail[0].name));
        float posX = _partTail[0].transform.position.x;
        _partTail.RemoveAt(0);
        
        if (_partTail.Count >= 1)
        {

            _partTail[0].tag = "Head";
            _partTail[0].AddComponent<Head>();
            _partTail[0].transform.position = new Vector3(posX, _partTail[0].transform.position.y, _partTail[0].transform.position.z);        
            Vector3 target = new Vector3(_plane.transform.position.x, _plane.transform.position.y, _partTail[0].transform.position.z - 27);
            _plane.transform.position = Vector3.Lerp(_plane.transform.position, target, 0.8f * Time.deltaTime);
        } else if (_partTail.Count == 0) 
        {
            _audio.PlayOneShot(_loseAudio);
            Instantiate(_canvasLose); 
        }

    
    }
}
