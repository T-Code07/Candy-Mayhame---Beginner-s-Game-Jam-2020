using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum LevelType
{
    SURVIVAL,
    KILLALL,
    WAVE
}

public class GameManager : MonoBehaviour
{
    Enemy_AI[] m_Enemies;
    
    [SerializeField] PlayerController m_player;

    [Header("Waves: ")]
    [SerializeField] int m_numberOfWaves = 10;
    [SerializeField] int m_enemiesPerWave = 4;
    private int m_wavesFinished = 0;
  

    [Space(5)]

    [Header("Spawner: ")]
    [SerializeField] int m_enemySpawnArea = 20;
    [SerializeField] int m_maxEnemies = 20;
    [SerializeField] Enemy_AI m_enemyPref;
    Vector3 m_spawnPlace;

    bool m_GamePlayed = false;

    [Space(5)]
    [Header("UI: ")]
    [SerializeField] UIManager m_UIManager;


    private LevelType m_levelType;
    private bool m_gameIsRunning = false;
    private bool m_gameJustStarted = false;
    private float m_survivalTimeStart;

    public bool GamePlayed
    {
        get { return m_GamePlayed; }
        set { m_GamePlayed = value; }
    }

    private void Start()
    {
        m_player = FindObjectOfType<PlayerController>();
        RestartGame();
    }

    public void RestartGame()
    {
        
        GameChooser();
        m_gameJustStarted = true;
        print("Starting Game...");
    }

    void Update()
    {
        if (m_player.gameObject.GetComponent<Health>().m_pLayerIsDead) return;
       // if(m_player)
        m_Enemies = new Enemy_AI[m_maxEnemies];
        m_Enemies = FindObjectsOfType<Enemy_AI>();

        if (!m_GamePlayed)
        {
            m_gameIsRunning = true;
            EnemySpawner(m_levelType);
            m_gameJustStarted = false;


        }
        else
        {
            print("Game Ended");
            m_gameIsRunning = false;
            if(m_levelType == LevelType.SURVIVAL)
            {
                print("You survived for: " + (Time.deltaTime - m_survivalTimeStart).ToString());
            }
            else if(m_levelType == LevelType.WAVE)
            {
                print("You surved for: " + m_wavesFinished.ToString());
            }
          
        }

    }

    private void EnemySpawner(LevelType levelType)
    {
        print("Spawing Enemies");
        if (levelType == LevelType.SURVIVAL)
        {
            SurvivalGame();
        }
        else if(levelType == LevelType.KILLALL)
        {
            KillAllGame();
        }
        else if(levelType == LevelType.WAVE)
        {
            WaveGame();
        }
    }

    private void KillAllGame()
    {
        //first time it has looped,
        if (m_gameJustStarted)
        {
            print("Kill-All: Runng Update for 1st time.");
            for (int i = 0; i <= m_maxEnemies; i++)
            {
                print("Need to spawn more enemies");
                SpawnNewEnemy();
            }
        }

        if(m_Enemies.Length <= 0)
        {
            m_GamePlayed = true;
            print("You won the kill all game!");
        }
    }

    private void SurvivalGame()
    {
        m_survivalTimeStart = Time.deltaTime;

        if (m_Enemies.Length <= 2)//If only 2 enemies in scene: spawn more
        {
            print("Survival Game: Trying to spawn more enemies");
            SpawnNewEnemy();
        }
        

    }

    private void WaveGame()
    {
        if (m_gameJustStarted)
        {
            m_wavesFinished = 0;
        }

        if (m_wavesFinished < m_numberOfWaves && m_Enemies.Length == 0)
        {
            SpawnNewWave();
            if (m_gameJustStarted) { return; }

            m_wavesFinished += 1;
        }
        else
        {
            m_GamePlayed = true;
            print("You survived all of the waves!");
        }
        
    }

    private void SpawnNewWave()
    {
        for(int i = 0; i <= m_enemiesPerWave; i++)
        {
            SpawnNewEnemy();
        }
    }

    private void GameChooser()
    {
        //Unity's function for random
        int randumNum = Random.Range(0, 4);//get a random number between 0-4. Can return 0,1,2
        switch (randumNum)
        {
            case 0://if randumNum ==0
                m_levelType = LevelType.KILLALL;
                break;

            case 1://randumNum == 1
                m_levelType = LevelType.SURVIVAL;
                break;

            case 2://randomNum == 2
                m_levelType = LevelType.WAVE;
                break;
        }

        print("Game Mode Set To: " + m_levelType.ToString());
    }

    private void SpawnNewEnemy()
    {
       GameObject newEnemy = Instantiate(m_enemyPref.gameObject);//Create new wave
        newEnemy.transform.position = Random.insideUnitSphere * m_enemySpawnArea;//spawn in at a random position around a sphere that is the size of enemySpawnArea
        newEnemy.transform.position = new Vector3(newEnemy.transform.position.x, 0);//Change wave's postion to be at y=0
        newEnemy.transform.rotation = Quaternion.identity;//makes sure rotation isn't crazy
        print("Spawing more enemies");
    }


    private void OnDrawGizmos()//Draws things
    {
        Gizmos.color = Color.green;
        try { Gizmos.DrawWireSphere(m_player.transform.position, m_enemySpawnArea); }//Draws a wire sphere at player transform with the area being equal to enemySpawnArea while player alive
        catch { }
    }
}
