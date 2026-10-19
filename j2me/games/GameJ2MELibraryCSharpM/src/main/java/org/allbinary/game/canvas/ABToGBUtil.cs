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
//using Canvas = javax.microedition.lcdui.Canvas;
//using NullCanvas = javax.microedition.lcdui.NullCanvas;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;

namespace org.allbinary.game.canvas;

public class ABToGBUtil
{
    private static readonly ABToGBUtil instance = new ABToGBUtil();
    public static ABToGBUtil getInstance()
    {
        return ABToGBUtil.instance;
    }

    public Canvas abCanvas = NullCanvas.NULL_CANVAS;
    public AllBinaryGameLayerManager allBinaryGameLayerManager = AllBinaryGameLayerManager.getNullInstance();
}

