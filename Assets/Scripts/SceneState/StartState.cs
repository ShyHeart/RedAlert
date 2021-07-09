using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class StartState:ISceneState
{
    public StartState(SceneStateController controller) : base("01StartScene", controller)
    {

    }

    private Image _logo;
    private float _SmoothingSpeed = 0.5f;
    private float _waitTime = 2;
    public override void StateStart()
    {
        _logo = GameObject.Find("Logo").GetComponent<Image>();
        _logo.color = Color.black;
    }

    public override void StateUpdate()
    {
        _logo.color = Color.Lerp(_logo.color, Color.white, _SmoothingSpeed * Time.deltaTime);
        _waitTime -= Time.deltaTime;
        if (_waitTime <= 0)
        {
            mController.SetState(new MainMenuState(mController));
        }

    }
}
