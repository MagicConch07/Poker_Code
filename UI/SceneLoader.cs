using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IUIButton
{
    [SerializeField] private string _sceneName;

    // TODO : 이거를 쫘왁 애니메이션 갈기고 애들 다 배치되면 씬 로드하는 걸로
    
    public void Click()
    {
        SceneManager.LoadScene(_sceneName);
        
    }
}
