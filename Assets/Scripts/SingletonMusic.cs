using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SingletonMusic : MonoBehaviour
{
    static SingletonMusic instance;
    private void Awake()
    {
        if(instance != null && SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
