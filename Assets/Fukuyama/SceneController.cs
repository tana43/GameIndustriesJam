using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class SceneController : MonoBehaviour
{
    public GameObject fadeObject;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeObject.GetComponent<FadeController>().IsPlayFadeOut())
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
