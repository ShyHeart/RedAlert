using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController
{
    private ISceneState mState;
    private AsyncOperation mAo;
    private bool mIsRunStart = false;

    /// <summary>
    /// 设置状态
    /// </summary>
    /// <param name="state"></param>
    /// <param name="isLoadScene">因为开始状态就是默认的场景，是否需要加载场景</param>
    public void SetState(ISceneState state,bool isLoadScene=true)
    {
        if (mState != null)
        {
            mState.StateEnd();//让上一个场景状态，做一下清理工作
        }

        mState = state;
        if (isLoadScene)
        {
            mAo = SceneManager.LoadSceneAsync(mState.SceneName);//使用异步的方式加载场景，方便判断场景是否加载完毕。
            mIsRunStart = false;
        }
        else
        {
            mState.StateStart();
            mIsRunStart = true;
        }
    }


    public void StateUpdate()
    {
        //正在加载的时候返回，避免在加载场景的时候更新场景 StateUpdate
        if (mAo != null && mAo.isDone == false) return;


        //这样可能会导致他一直在调用Start，定义bool变量解决
        if (mIsRunStart == false && mAo != null && mAo.isDone == true)
        {
            mState.StateStart();
            mIsRunStart = true;
        }

        if (mState != null)
        {
            mState.StateUpdate();
        }
    }
}

