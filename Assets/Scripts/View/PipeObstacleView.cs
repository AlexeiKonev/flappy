using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeObstacleView : MonoBehaviour
{
    [SerializeField]
    private PipeObstacleModel model;
    
    private PipeObstaclePresenter presenter;
    void Start()
    {
        presenter = new PipeObstaclePresenter(model); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Bird")
        {
            Debug.Log("collision");
        }
    }
}
