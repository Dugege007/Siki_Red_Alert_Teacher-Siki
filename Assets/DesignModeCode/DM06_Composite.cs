using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：组合模式
 * 创建时间：
 */

public class DM06_Composite : MonoBehaviour
{
    private void Start()
    {
        DMComposite root = new DMComposite("DM06_Composite");

        DMComposite composite = new DMComposite("Composite");
        DMComposite composite1 = new DMComposite("Composite (1)");

        DMLeaf leaf = new DMLeaf("Leaf");
        DMLeaf leaf1 = new DMLeaf("Leaf (1)");
        DMLeaf leaf2 = new DMLeaf("Leaf (2)");
        DMLeaf leaf3 = new DMLeaf("Leaf (3)");

        root.AddChild(composite);
        root.AddChild(composite1);
        root.AddChild(leaf3);
        composite.AddChild(leaf);
        composite1.AddChild(leaf1);
        composite1.AddChild(leaf2);

        ReadComponent(root);
    }

    // 深度优先
    private void ReadComponent(DMComponent component)
    {
        Debug.Log(component.Name);
        List<DMComponent> children = component.Children;
        if (children == null || children.Count == 0) return;

        foreach (DMComponent child in children)
        {
            ReadComponent(child);
        }
    }
}

public abstract class DMComponent
{
    protected List<DMComponent> mChildren;
    protected string mName;

    public List<DMComponent> Children { get { return mChildren; } }
    public string Name { get { return mName; } }

    public DMComponent(string name)
    {
        mName = name;
        mChildren = new List<DMComponent>();
    }

    public abstract void AddChild(DMComponent component);
    public abstract void RemoveChild(DMComponent component);
    public abstract DMComponent GetChild(int index);
}

public class DMLeaf : DMComponent
{
    public DMLeaf(string name) : base(name) { }

    public override void AddChild(DMComponent component)
    {
        return;
    }

    public override DMComponent GetChild(int index)
    {
        return null;
    }

    public override void RemoveChild(DMComponent component)
    {
        return;
    }
}

public class DMComposite : DMComponent
{
    public DMComposite(string name) : base(name) { }

    public override void AddChild(DMComponent component)
    {
        mChildren.Add(component);
    }

    public override DMComponent GetChild(int index)
    {
        return mChildren[index];
    }

    public override void RemoveChild(DMComponent component)
    {
        mChildren.Remove(component);
    }
}