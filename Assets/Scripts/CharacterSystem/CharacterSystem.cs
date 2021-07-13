using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CharacterSystem : IGameSystem
{
    private List<ICharacter> mEnemys = new List<ICharacter>();
    private List<ICharacter> mSoldiers = new List<ICharacter>();

    public void AddEnemy(IEnemy enemy)
    {
        mEnemys.Add(enemy);
    }
    public void RemoveEnemey(IEnemy enemy)
    {
        mEnemys.Remove(enemy);
    }
    public void AddSoldier(ISoldier soldier)
    {
        mSoldiers.Add(soldier);
    }
    public void RemoveSoldier(ISoldier soldier)
    {
        mSoldiers.Remove(soldier);
    }

    public override void Update()
    {
        UpdateEnemy();
        UpdateSoldier();

        //RemoveCharacterIsKilled(mEnemys);
        //RemoveCharacterIsKilled(mSoldiers);
    }
    private void UpdateEnemy()
    {
        foreach (IEnemy e in mEnemys)
        {
            e.Update();
            e.UpdateFSMAI(mSoldiers);
        }
    }
    private void UpdateSoldier()
    {
        foreach (ISoldier s in mSoldiers)
        {
         s.Update();
         s.UpdateFSMAI(mEnemys);
        }
    }
}