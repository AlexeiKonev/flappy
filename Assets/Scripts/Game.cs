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
    public class PipeObstacleModel
    {
        
        public float speed  = 2f;
    }

[System.Serializable]
public class PipeObstaclePresenter
{
    private PipeObstacleModel model;
    private   Vector3 moveDirection;
    
    public PipeObstaclePresenter(PipeObstacleModel model)
    {
        this.model = model;
    }
}
 [System.Serializable]
    public class BackgroundControllerModel
    {
        public float horizontalSpeed =3f;
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
[System.Serializable]
public class PileSpawnerModel
{
    public GameObject prefab;

    public int maxPileOnScene;
    public float distanceVerticalMin;
    public float distanceVerticalMax;
    public float horizontalDistance;
    public float yClamp;
}

 public class PileSpawnerPresenter
    {
        public class Pair
        {
            public GameObject Top {get; private set;}
            public GameObject Bot {get; private set;}

            public Vector3 Position => Top.transform.position;
            public bool WasDestroyed => Top == null || Bot == null;
            public void Destroy()
            {
                GameObject.Destroy(Top);
                GameObject.Destroy(Bot);
            }

            public Pair(GameObject top, GameObject bot)
            {
                this.Top = top;
                this.Bot = bot;
            }
        }


        public PileSpawnerModel Model {get; set;}
        public Queue<Pair> Piles {get; private set;}
        public float LatestX{get; private set;}


        public PileSpawnerPresenter()
        {
            Piles = new Queue<Pair>();
            LatestX = Camera.main.orthographicSize * Screen.width / Screen.height;
        }

        public void Spawning()
        {
            if(Piles.Count > 0 && Piles.Peek().WasDestroyed)
                Piles.Dequeue();

            if(Piles.Count > Model.maxPileOnScene) return;
            Piles.Enqueue(CreatePile(LatestX));
        }

        public Pair CreatePile(float latestX)
        {
            GameObject prefab = Model.prefab;
            float x = latestX + Model.horizontalDistance;
            float y = Random.Range(-Model.yClamp, Model.yClamp);
            float distance = Random.Range(Model.distanceVerticalMin, Model.distanceVerticalMax) / 2f;

            GameObject top = GameObject.Instantiate(prefab);
            top.transform.localScale = new Vector3(1, -1, 1);
            top.transform.localPosition = new Vector3(x, y + distance, 0);

            GameObject bot = GameObject.Instantiate(prefab);
            bot.transform.localScale = new Vector3(1, 1, 1);
            bot.transform.localPosition = new Vector3(x, y - distance, 0);

            LatestX = x;
            return new Pair(top, bot);
        }

        public void Clear()
        {
            foreach(var e in Piles)
                e.Destroy();
            Piles.Clear();
        }
    }