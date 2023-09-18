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
        public float flyUp;
        public float speedFlyup;
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


}