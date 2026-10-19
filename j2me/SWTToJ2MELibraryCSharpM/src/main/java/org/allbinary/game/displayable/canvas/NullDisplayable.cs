// Generated Code Do Not Modify

using System;
using System.Linq;
//using Canvas = javax.microedition.lcdui.Canvas;
//using Graphics = javax.microedition.lcdui.Graphics;
using BaseGameStatistics = org.allbinary.canvas.BaseGameStatistics;
using GameStatisticsFactory = org.allbinary.canvas.GameStatisticsFactory;

namespace org.allbinary.game.displayable.canvas;

//SWTToJ2ME
public class NullDisplayable : Canvas
{
    private static readonly NullDisplayable SINGLETON = new NullDisplayable();
    public static NullDisplayable getInstance()
    {
        return NullDisplayable.SINGLETON;
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

