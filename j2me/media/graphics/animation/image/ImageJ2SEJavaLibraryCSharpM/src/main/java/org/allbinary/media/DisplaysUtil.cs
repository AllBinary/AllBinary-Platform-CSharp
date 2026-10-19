/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
 *  
 * By agreeing to this license you and any business entity you represent are 
 * legally bound to the AllBinary Open License Version 1 legal agreement. 
 *  
 * You may obtain the AllBinary Open License Version 1 legal agreement from 
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository. 
 *  
 * Created By: Travis Berthelot 
 *   
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
//using Dimension = java.awt.Dimension;
//using DisplayMode = java.awt.DisplayMode;
//using GraphicsDevice = java.awt.GraphicsDevice;
//using GraphicsEnvironment = java.awt.GraphicsEnvironment;
//using Toolkit = java.awt.Toolkit;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;

namespace org.allbinary.media;

public class DisplaysUtil
{
    public static DisplaysUtil getInstance()
    {
        return DisplaysUtil.instance;
    }

    private static readonly DisplaysUtil instance = new DisplaysUtil();
    public virtual Rectangle getPrimaryScreenSize()
    {
        Dimension dimension = Toolkit.getDefaultToolkit().getScreenSize();
        return new Rectangle(PointFactory.getInstance().ZERO_ZERO, dimension.width, dimension.height);
    }

    public virtual Rectangle[] getScreenSizesAsRectangleArray()
    {
        GraphicsEnvironment graphicsEnvironment = GraphicsEnvironment.getLocalGraphicsEnvironment();
        GraphicsDevice[] graphicsDeviceArray = graphicsEnvironment.getScreenDevices();
        GraphicsDevice graphicsDevice = null;
        DisplayMode displayMode = null;
        Rectangle rectangle = null;
        int size = graphicsDeviceArray.Length;
        Rectangle[] rectangleArray = new Rectangle[size];
        for (int index = 0; index < size; index++) {
            graphicsDevice = graphicsDeviceArray[index];
            displayMode = graphicsDevice.getDisplayMode();
            rectangle = new Rectangle(PointFactory.getInstance().ZERO_ZERO, displayMode.getWidth(), displayMode.getHeight());
            rectangleArray[index] = rectangle;
        }
        return rectangleArray;
    }

}

