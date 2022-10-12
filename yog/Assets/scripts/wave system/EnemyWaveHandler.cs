using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveHandler : MonoBehaviour
{

    //[SerializeField]List<Transform> spawnPoints = new List<Transform>();



    public int currentActiveWaveIndex = 0;
    [SerializeField] List<GameObject> enemiesActive = new List<GameObject>();
    [SerializeField] int enemiesDefeated;
    [SerializeField] float waveCooldown = 0;

    [System.Serializable]
    public class Wave
    {
        [SerializeField] float spawnDelay;
        public int enemyCount;
        
        [SerializeField]List<EnemyPool> availablePools = new List<EnemyPool>();
        [SerializeField]List<Transform> spawnPoints = new List<Transform>();
        public List<GameObject> activeEnemies = new List<GameObject>();
        //public List<EnemyHealth> enemyHealthComponents = new List<EnemyHealth>();

        private Transform GetRandomSpawnPoint()
        {
            int index = Random.Range(0, spawnPoints.Count);

            return spawnPoints[index];
        }    
        public IEnumerator TriggerWave()
        {
            foreach(GameObject enemy in activeEnemies)
            {                
                Transform point = GetRandomSpawnPoint();
                Instantiate(enemy, point.position, point.rotation);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
        public void SetupWave()
        {
            int enemiesActiveCount = 0;

            while(enemiesActiveCount < enemyCount)
            {
                EnemyPool pool = GetRandomEnemyPool();
                GameObject enemy = pool.GetRandomEnemyPrefab();
                
                if(CheckIfEnemyCanBeAdded(enemy, pool))
                {
                    enemiesActiveCount++;
                    AddActiveEnemy(enemy);
                    //enemyHealthComponents.Add(enemy.GetComponent<EnemyHealth>());
                }
            }
        }

        public EnemyPool GetRandomEnemyPool()
        {
            int index = Random.Range(0, availablePools.Count);
           
            return availablePools[index];
        }
                   
        private bool CheckIfEnemyCanBeAdded(GameObject enemy, EnemyPool pool)
        {
            bool canBeAdded = true;

            if(enemy = null)
            {
                canBeAdded = false;
            }
            else if(!pool.CheckIfEnemyCanSpawn())
            {
                canBeAdded = false;
            }

            return canBeAdded;
        }
        private void AddActiveEnemy(GameObject enemy)
        {
           
            activeEnemies.Add(enemy);
        }

        /*public bool CheckIfEnemyExistsInWave(GameObject enemy)
        {
            bool enemyExists = false;

            if(activeEnemies.Find((x) => x.name == enemy.name))
            {
                enemyExists = true;
            }

            return enemyExists;
        }*/

    }
    [System.Serializable]
    public class EnemyPool
    {
        [SerializeField] EnemyTier tierLevel;
        [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();

        public GameObject GetRandomEnemyPrefab()
        {
            int index = Random.Range(0, enemyPrefabs.Count);

            return enemyPrefabs[index];
        }


        public bool CheckIfEnemyCanSpawn()
        {
            int random = Random.Range(0, 101);

            if (random <= (int)tierLevel)
            {
                return true;
            }

            return false;

        }
    }


    //public List<EnemyPool> availblePools = new List<EnemyPool>();
    public List<Wave> waves = new List<Wave>();

    public void UpdateCurrentWaveKillCount()
    {
        enemiesDefeated++;
        if(CheckIfWaveIsCleared())
        {
            //StopCoroutine(WaveIsCleared());
            StartCoroutine(WaveIsCleared());
        }
    }

    private IEnumerator WaveIsCleared()
    {
        
        yield return new WaitForSeconds(waveCooldown);

        if (currentActiveWaveIndex >= waves.Count)
        {
            Debug.Log("all clear"); //all waves have been cleared
        }
        else
        {
            StartWave(currentActiveWaveIndex);
        }
       
        
       
       
    }
    private bool CheckIfWaveIsCleared()
    {
        //Debug.Log(waves[currentActiveWaveIndex - 1].enemyCount.ToString() + " aantal");
        //Debug.Log(enemiesDefeated.ToString() + " defeated");
        bool waveCleared = false; 
        if(enemiesDefeated == waves[currentActiveWaveIndex - 1].enemyCount)
        {          
            waveCleared = true;
        }

        return waveCleared;
    }
    public void StartWave(int waveIndex)
    {     
        //Debug.Log(waveIndex.ToString() + " de wave idnex" + waves.Count.ToString() + " de wave count");                               
        StartCoroutine(waves[waveIndex].TriggerWave());
        enemiesActive = waves[waveIndex].activeEnemies;
        currentActiveWaveIndex++;
        enemiesDefeated = 0;
        
       
    }

    public int GetEnemiesDefeated()
    {
        return enemiesDefeated;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(Wave wave in waves)
        {
            wave.SetupWave();
        }
        StartWave(currentActiveWaveIndex);      
    }

    // Update is called once per frame
    void Update()
    {
        
       
        
    }


}
