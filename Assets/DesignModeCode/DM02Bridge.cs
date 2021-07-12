using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM02Bridge : MonoBehaviour
{
    void Start()
    {
        IRenderEngine renderEngine = new OpenGL();
        Sphere sphere = new Sphere(renderEngine);
        sphere.Draw();
        Cube cube = new Cube(renderEngine);
        cube.Draw();
        Capsule capsule = new Capsule(renderEngine);
        capsule.Draw();
    }
}

public class ISharp
{
    public string name;
    public IRenderEngine RenderEngine;

    public ISharp(IRenderEngine renderEngine)
    {
        this.RenderEngine = renderEngine;
    }

    public void Draw()
    {
        RenderEngine.Render(name);
    }
}

public abstract class IRenderEngine
{
    public abstract void Render(string name);
}

public class Sphere:ISharp
{
    /*public string name = "Sphere";

    public OpenGL OpenGl = new OpenGL();
    public DirectX dx = new DirectX();

    public void Draw()
    {
        OpenGl.Render(name);
    }

    public void Drawdx()
    {
        dx.Render(name);
    }*/

    public Sphere(IRenderEngine re):base(re)
    {
        name = "Sphere";
    }
}

public class Cube:ISharp
{
    /* public string name = "Cube";

     public OpenGL OpenGl = new OpenGL();
     public DirectX dx = new DirectX();

     public void Draw()
     {
         OpenGl.Render(name);
     }
     public void Drawdx()
     {
         dx.Render(name);
     }*/

    public Cube(IRenderEngine re):base(re)
    {
        name = "Cube";
    }

}

public class Capsule:ISharp
{
    /*public string name = "Capsule";

    public OpenGL OpenGl = new OpenGL();
    public DirectX dx = new DirectX();

    public void Draw()
    {
        OpenGl.Render(name);
    }
    public void Drawdx()
    {
        dx.Render(name);
    }*/

    public Capsule(IRenderEngine re):base(re)
    {
        name = "Capsule";
    }

}


public class OpenGL:IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log("OpenGL绘制出来了：" + name);
    }
}

public class DirectX:IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log("DirectX绘制出来了：" + name);
    }

}

public class SuperRender : IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log("SuperRender绘制出来了：" + name);
    }
}


