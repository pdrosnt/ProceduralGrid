using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStream : MonoBehaviour
{
    World world;
    public Vector2 postition;
    public Transform _camera;

    private void Start()
    {
        if(_camera == null){_camera = Camera.main.transform;}
    }

    private void Update()
    {
        postition = new Vector2(_camera.position.x,_camera.position.z);
    }
}
