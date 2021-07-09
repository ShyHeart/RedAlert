using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 场景状态的基础接口
/// </summary>
public class ISceneState
{
    private string mSceneName;
    protected SceneStateController mController;

    public string SceneName
    {
        get { return mSceneName; }
    }

    public ISceneState(string sceneName,SceneStateController controller)
    {
        mSceneName = sceneName;
        mController = controller;
    }

    /// <summary>
    /// 每次进入到这个状态的时候调用
    /// </summary>
    public virtual void StateStart()
    {

    }
    public virtual void StateEnd()
    {

    }
    public virtual void StateUpdate()
    {

    }
}
