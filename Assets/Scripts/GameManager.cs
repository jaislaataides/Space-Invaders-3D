using UnityEngine;
// using static EnemyGun;

public class GameManager : MonoBehaviour
{
    //SINGLETON
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManagerSingleton");
                    _instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    public int score = 0; 
    private int lives = 3; 
    private int barrier1life = 30;
    private int barrier2life = 30;
    private int barrier3life = 30;
    private int barrier4life = 30;

    public GameObject[] enemies = new GameObject[60];
    public GameObject bulletPrefabEnemy;

    private int frameCounter = 0;
    private int updateInterval = 50; 
    private float speed = 1f;
    private float moveDistance = 1f;
    private float moveInterval = 1f;
    private bool movingRight = true;

    private int leftBound = -398;
    private int rightBound = 395; 

    private enum EnemyState { MovingRight, MovingForward, MovingLeft}
    private EnemyState currentState = EnemyState.MovingRight;

    public void Start()
    {
        
    }

    private void Update()
    {
        // if(!areThereEnemiesLeft())
        //     Debug.Log("You won!!! Score: "+score);

        bool anyEnemyMoved = false;
        frameCounter++;

        if (frameCounter == updateInterval)
        {
            frameCounter = 0;
            foreach (GameObject enemy in enemies)
            {
                if(enemy != null)
                {
                    switch (currentState)
                    {
                        case EnemyState.MovingRight:
                            if (enemy.transform.position.x < rightBound)
                            {
                                Vector3 newPosition = enemy.transform.position + new Vector3(30, 0, 0);
                                enemy.transform.position = newPosition;
                            }
                            else
                            {
                                currentState = EnemyState.MovingForward;
                            }
                            break;

                        case EnemyState.MovingForward:
                            if(enemy.transform.position.z > -161.7)
                            {
                                foreach(GameObject enemyy in enemies)
                                {
                                    if(enemyy != null)
                                    {
                                        Vector3 newPosition = enemy.transform.position + new Vector3(0, 0, -30);
                                        enemy.transform.position = newPosition;
                                    }
                                }
                            }

                            if(enemy.transform.position.x  < rightBound)
                                currentState = EnemyState.MovingRight;

                            if(enemy.transform.position.x > leftBound )
                                currentState = EnemyState.MovingLeft;
                            
                            break;

                        case EnemyState.MovingLeft:
                            if (enemy.transform.position.x > leftBound)
                            {
                                Vector3 newPosition = enemy.transform.position + new Vector3(-30, 0, 0);
                                enemy.transform.position = newPosition;
                            }
                            else
                            {
                                currentState = EnemyState.MovingForward;
                            }
                            break;
                    }
                }
            }
        }
    }

    public int getRightBound()
    {
        return rightBound;
    }

    public int getLeftBound()
    {
        return leftBound;
    }

    public int barrierShotsLeft(string name)
    {
        switch (name)
        {
            case "bar1":
                barrier1life--;
                return barrier1life;
            case "bar2":
                barrier2life--;
                return barrier2life;
            case "bar3":
                barrier3life--;
                return barrier3life;
            case "bar4": 
                barrier4life--;
                return barrier4life;
            default:
                return 0;
        }
    }

    public void DecreaseLife()
    {
        if(lives > 0)
        {
            lives--;
            return;
        }
        EndGame();
    }

    public void ResetBarriers()
    {
        barrier1life = 30;
        barrier2life = 30;
        barrier3life = 30;
        barrier4life = 30;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log(score);
    }

    public void EnemyShoot()
    {
        //TODO: colocar inimigo pra atirar
    }

    public void EndGame()
    {
        //TODO: finalização e mostra o score
    }

    public bool areThereEnemiesLeft()
    {
        for(int i = 0; i < 60; i++)
        {
            if(enemies[0] != null)
            {
                return true;
            }
        }
        return false;
    }
}
