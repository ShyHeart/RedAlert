using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//脚本与游戏物体分离的开发模式
public class GameLoop : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
