using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectScene : MonoBehaviour
{
    public Texture btnTexture;
    // Start is called before the first frame update


    void OnGUI()
    {
        if (!btnTexture)
        {
            Debug.LogError("Please assign a texture on the inspector");
            return;
        }

        if (GUI.Button(new Rect(300, 100, 500, 200), "GO TO SCENE "))
        {
            SceneManager.LoadSceneAsync(0);
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
