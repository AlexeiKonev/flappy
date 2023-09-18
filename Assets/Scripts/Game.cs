using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

 [System.Serializable]
    public class BirdModel
    {
        public float flyUp = 0.5f;
        public float speedFlyup = 3.5f;
    }
    
 [System.Serializable]
    public class BackgroundControllerModel
    {
        public float horizontalSpeed;
        public float minX;
        public float maxX;
    }
    
public class BirdPresenter
{
    BirdModel model;

    Vector3 flyup;
    public bool IsFlying {get; private set;}

    public BirdPresenter(BirdModel model)
    {
        this.model = model;
    }

    public bool Flyup(Vector3 position)
    {
        if(IsFlying) return false;

        IsFlying = true;
        flyup = position + Vector3.up * model.flyUp;
        return true;
    }

    public Vector3 Update(Vector3 position, float dt)
    {
        if(IsFlying)
            position = Vector3.MoveTowards(position, flyup, model.speedFlyup * dt);

        if(position == flyup)
            IsFlying = false;

        return position;
    }
}