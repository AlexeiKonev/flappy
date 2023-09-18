using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdView : MonoBehaviour
{
    [SerializeField] BirdModel model;

    BirdPresenter presenter;
    Rigidbody2D rb;

    void Start()
    {
        presenter = new BirdPresenter(model);    
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
}