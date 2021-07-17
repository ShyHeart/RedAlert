using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


//外观模式  中介者
public class GameFacade
{

    //私有的实例
    private static GameFacade _instance = new GameFacade();
    private bool m_IsGameOver = false;

    //单例模式
    public static GameFacade Instance { get { return _instance; } }

    public bool isGameOver { get { return m_IsGameOver; } }


    private GameFacade()
    {

    }

    //把各个系统定义出来
    private ArchievementSystem _archievementSystem;
    private CampSystem _campSystem;
    private CharacterSystem _characterSystem;
    private EnergySystem _energySystem;
    private GameEventSystem _gameEventSystem;
    private StageSystem _stageSystem;

    private CampInfoUI _campInfoUi;
    private GamePauseUI _gamePauseUi;
    private GameStateInfoUI _gameStateInfoUi;
    private SoldierInfoUI _solderInfoUi;

    public void Init()
    {
        _archievementSystem = new ArchievementSystem();
        _campSystem = new CampSystem();
        _characterSystem = new CharacterSystem();
        _energySystem = new EnergySystem();
        _gameEventSystem = new GameEventSystem();
        _stageSystem = new StageSystem();

        _campInfoUi = new CampInfoUI();
        _gamePauseUi = new GamePauseUI();
        _gameStateInfoUi = new GameStateInfoUI();
        _solderInfoUi = new SoldierInfoUI();


        _archievementSystem.Init();
        _campSystem.Init();
        _characterSystem.Init();
        _energySystem.Init();
        _gameEventSystem.Init();
        _stageSystem.Init();
        _campInfoUi.Init();
        _gamePauseUi.Init();
        _gameStateInfoUi.Init();
        _solderInfoUi.Init();

        LoadMemento();
    }

    public void Update()
    {
        _archievementSystem.Update();
        _campSystem.Update();
        _characterSystem.Update();
        _energySystem.Update();
        _gameEventSystem.Update();
        _stageSystem.Update();
        _campInfoUi.Update();
        _gamePauseUi.Update();
        _gameStateInfoUi.Update();
        _solderInfoUi.Update();

    }

    public void Release()
    {
        _archievementSystem.Release();
        _campSystem.Release();
        _characterSystem.Release();
        _energySystem.Release();
        _gameEventSystem.Release();
        _stageSystem.Release();
        _campInfoUi.Release();
        _gamePauseUi.Release();
        _gameStateInfoUi.Release();
        _solderInfoUi.Release();

        CreateMemento();
    }


    public Vector3 GetEnemyTargetPosition()
    {
        return _stageSystem.targetPosition;
    }

    public void ShowCampInfo(ICamp camp)
    {
        _campInfoUi.ShowCampInfo(camp);
    }

    public void AddSoldier(ISoldier soldier)
    {
        _characterSystem.AddSoldier(soldier);
    }

    public void AddEnemy(IEnemy enemy)
    {
        _characterSystem.AddEnemy(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        _characterSystem.RemoveEnemey(enemy);
    }
    public bool TakeEnergy(int value)
    {
        return _energySystem.TakeEnergy(value);
    }

    public void RecycleEnergy(int value)
    {
        _energySystem.RecycleEnergy(value);
        
    }
     
    public void ShowMsg(string msg)
    {
        _gameStateInfoUi.ShowMsg(msg);
    }
    public void UpdateEnergySlider(int nowEnergy, int maxEnergy)
    {
        _gameStateInfoUi.UpdateEnergySlider(nowEnergy, maxEnergy);
    }
    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        _gameEventSystem.RegisterObserver(eventType,observer);
    }
    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer){
        _gameEventSystem.RemoveObserver(eventType,observer);
    }

    public void NotifySubject(GameEventType eventType)
    {
        _gameEventSystem.NotifySubject(eventType);
    }

    private void LoadMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.LoadData();
        _archievementSystem.SetMemento(memento);
    }

    private void CreateMemento()
    {
        AchievementMemento memento= _archievementSystem.CreateMemento();
        memento.SaveData();
    }

    public void RunVisitor(ICharacterVisitor visitor)
    {
        _characterSystem.RunVisitor(visitor);
    }
}
