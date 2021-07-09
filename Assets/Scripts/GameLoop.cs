using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//脚本与游戏物体分离的开发模式
public class GameLoop : MonoBehaviour
{
    private SceneStateController controller = null;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = new SceneStateController();
        //设置默认状态为开始状态
        controller.SetState(new StartState(controller),false);
    }

    // Update is called once per frame
    void Update()
    {
        controller.StateUpdate();
    }
}
