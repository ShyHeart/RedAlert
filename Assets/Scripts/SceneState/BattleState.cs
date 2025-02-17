﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class BattleState:ISceneState
{
    public BattleState(SceneStateController controller) : base("03BattleScene", controller)
    {

    }

    //战斗模式子系统 兵营，关卡 角色管理 行为 成就
    private GameFacade _gameFacade;

    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }

    public override void StateEnd()
    {
         GameFacade.Instance.Release();
    }

    public override void StateUpdate()
    {
        if ( GameFacade.Instance.isGameOver)
        {
            mController.SetState(new MainMenuState(mController));
        }

        GameFacade.Instance.Update();
    }
}
