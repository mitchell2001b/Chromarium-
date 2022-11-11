using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveHandler : MonoBehaviour
{  
    public int currentActiveWaveIndex = 0;
    [SerializeField] List<GameObject> enemiesActive = new List<GameObject>();
    [SerializeField] int enemiesDefeated;
    [SerializeField] float waveCooldown = 0;
    [SerializeField] PlayerShip playerShip;
    [SerializeField] ShopInteractable shop;

    [System.Serializable]
    public class Wave
    {
        [SerializeField] float spawnDelay;
        public int enemyCount;
        
        [SerializeField]List<EnemyPool> availablePools = new List<EnemyPool>();
        [SerializeField]List<Transform> spawnPoints = new List<Transform>();
        public List<GameObject> activeEnemies = new List<GameObject>();
        
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
    public List<Wave> waves = new List<Wave>();

    public void UpdateCurrentWaveKillCount()
    {
        enemiesDefeated++;
        if(CheckIfWaveIsCleared())
        {           
            StartCoroutine(WaveIsCleared());
        }
    }

    private IEnumerator WaveIsCleared()
    {
        
        yield return new WaitForSeconds(waveCooldown);

        if (currentActiveWaveIndex >= waves.Count)
        {
            Debug.Log("all clear"); //all waves have been cleared
            if(playerShip != null) playerShip.ActivateShip();
            if(shop != null) shop.SpawnShop();
        }
        else
        {
            StartWave(currentActiveWaveIndex);
        }
       
        
       
       
    }
    private bool CheckIfWaveIsCleared()
    {      
        bool waveCleared = false; 
        if(enemiesDefeated == waves[currentActiveWaveIndex - 1].enemyCount)
        {          
            waveCleared = true;
        }

        return waveCleared;
    }
    public void StartWave(int waveIndex)
    {                                     
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
