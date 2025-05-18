using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IUIButton
{
    [SerializeField] private string _sceneName;

    public void Click()
    {
        SceneManager.LoadScene(_sceneName);

    }
}
