// Generated Code Do Not Modify

using System;
using System.Linq;
//using Canvas = javax.microedition.lcdui.Canvas;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;

namespace org.allbinary.game.configuration.feature;

public class MultiPlayerGameFeatureFactory
{
    private static readonly MultiPlayerGameFeatureFactory instance = new MultiPlayerGameFeatureFactory();
    public static MultiPlayerGameFeatureFactory getInstance()
    {
        return MultiPlayerGameFeatureFactory.instance;
    }

    private MultiPlayerGameFeatureFactory()
    {
    }

    public virtual void addCommands(object anyType)
    {
        GameCommandsFactory gameCommandsFactory = GameCommandsFactory.getInstance();
        Canvas canvas = ((Canvas) anyType);
        canvas.addCommand(gameCommandsFactory.QUIT_COMMAND);
    }

}

