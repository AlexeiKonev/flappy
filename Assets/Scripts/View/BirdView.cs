using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdView : MonoBehaviour
{
    [SerializeField]
    private BirdModel model;

    private BirdPresenter presenter;
    private Rigidbody2D rb;

    private void Start()
    {
        presenter = new BirdPresenter(model);    
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(IsInput())
        {
            bool isStartFly = presenter.Flyup(transform.localPosition);
            if(isStartFly)
                rb.velocity = Vector2.zero;
        }

        transform.localPosition = presenter.Update(transform.localPosition, Time.deltaTime);
    }

    private bool IsInput()
    {
        return Input.GetMouseButtonDown(0);
    }
}