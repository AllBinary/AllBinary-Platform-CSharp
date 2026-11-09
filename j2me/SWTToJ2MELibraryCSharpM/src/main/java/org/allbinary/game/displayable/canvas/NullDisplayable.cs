// Generated Code Do Not Modify

extern alias J2MEForJ2MEJavaLibraryCSharp;
using System;
using System.Linq;
using Canvas = javax.microedition.lcdui.Canvas;
using Graphics = javax.microedition.lcdui.Graphics;
using BaseGameStatistics = org.allbinary.canvas.BaseGameStatistics;
using GameStatisticsFactory = org.allbinary.canvas.GameStatisticsFactory;

namespace org.allbinary.game.displayable.canvas;

//SWTToJ2ME
public class NullDisplayable : Canvas
{
    private static readonly J2MEForJ2MEJavaLibraryCSharp::org.allbinary.game.displayable.canvas.NullDisplayable SINGLETON = new J2MEForJ2MEJavaLibraryCSharp::org.allbinary.game.displayable.canvas.NullDisplayable();
    public static J2MEForJ2MEJavaLibraryCSharp::org.allbinary.game.displayable.canvas.NullDisplayable getInstance()
    {
        return J2MEForJ2MEJavaLibraryCSharp::org.allbinary.game.displayable.canvas.NullDisplayable.SINGLETON;
    }

    private NullDisplayable()
    {
    }

    private readonly BaseGameStatistics baseGameStatistics = GameStatisticsFactory.getInstance();
    public override void paint(Graphics graphics)
    {
        this.baseGameStatistics.nextRefresh();
    }

}

