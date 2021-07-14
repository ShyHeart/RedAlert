using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DM06Composite:MonoBehaviour
{
    void Start()
    {
        DMComposite root = new DMComposite("DM01State");

        DMLeaf leaf1 = new DMLeaf("one");
        DMLeaf leaf2 = new DMLeaf("three");
        DMComposite two = new DMComposite("two");

        root.AddChild(leaf1);
        root.AddChild(two);
        root.AddChild(leaf2);

        DMLeaf child1 = new DMLeaf("GameObject");
        DMLeaf child2 = new DMLeaf("GameObject (1)");
        two.AddChild(child1);
        two.AddChild(child2);

        ReadComponent(root);
    }
    //深度
    private void ReadComponent( DMComponent component )
    {
        Debug.Log(component.name);

        List<DMComponent> children = component.children;
        if (children == null || children.Count == 0) return;
        foreach (DMComponent child in children)
        {
            ReadComponent(child);
        }
    }
}



public abstract class DMComponent
{
    protected string mName;
    public string name { get { return mName; } }
    public DMComponent(string name)
    {
        mName = name;
        mChildren = new List<DMComponent>();
    }
    protected List<DMComponent> mChildren;
    public List<DMComponent> children { get { return mChildren; } }
    public abstract void AddChild(DMComponent c);
    public abstract void RemoveChild(DMComponent c);
    public abstract DMComponent GetChild(int index);
}

public class DMLeaf:DMComponent
{
    public DMLeaf(string name) : base(name) { }


    public override void AddChild(DMComponent c)
    {
        return;
    }

    public override void RemoveChild(DMComponent c)
    {
        return;
    }

    public override DMComponent GetChild(int index)
    {
        return null;
    }
}
public class DMComposite:DMComponent
{
    public DMComposite(string name) : base(name) { }


    public override void AddChild(DMComponent c)
    {
        mChildren.Add(c);
    }

    public override void RemoveChild(DMComponent c)
    {
        mChildren.Remove(c);
    }

    public override DMComponent GetChild(int index)
    {
        return mChildren[index];
    }
}