using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Animator transition;

    // Khai báo biến singleton
    private static Transition _instance;
    public static Transition Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Transition>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<Transition>();
                    singletonObject.name = typeof(Transition).ToString() + " (Singleton)";
                }
            }
            return _instance;
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevelTransition());
    }

    IEnumerator LoadLevelTransition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
    }
}
