using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject bullets;
    public int poolSize;

    private void Awake() {
        
        if(SharedInstance == null) SharedInstance = this;
    }

    void Start()
    {

        poolSize = 15;
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < poolSize; i++)
        {
            tmp = Instantiate(bullets);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    public void DisableAllBullets(){
        foreach(GameObject bullet in pooledObjects){
            if (bullet.activeSelf) bullet.SetActive(false);
        }
    }

    public GameObject GetBullet(){
        for(int i = 0; i < poolSize; i++){
            
            Debug.Log("bang");
            if(pooledObjects[i] == null) continue;
            if(!pooledObjects[i].activeInHierarchy) 
                return pooledObjects[i];
        }

        Debug.Log("Return null");
        return null;
    }

}
