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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.graphics.displayable;

public class CanvasStrings
{
    private static readonly CanvasStrings instance = new CanvasStrings();
    public static CanvasStrings getInstance()
    {
        return CanvasStrings.instance;
    }

    public readonly string CONSTRUCTOR = "MyCanvas::MyCanvas";
    public readonly string PAUSE = "MyCanvas::pause";
    public readonly string UN_PAUSE = "MyCanvas::unPause";
    public readonly string SET_FULL_SCREEN_MODE = "setFullScreenMode";
    public readonly string SIZE_CHANGED = "sizeChanged";
    public readonly string SCALED_IMAGES = "scaledImages";
    public readonly string PAINT = "paint";
    public readonly string ON_DISPLAY_CHANGE_EVENT = "onDisplayChangeEvent";
    public readonly string UPDATE_MEASUREMENT = "updateMeasurement";
    public readonly string FD_WIDTH = " font/display width: ";
    public readonly string FD_HEIGHT = " font/display height: ";
    public readonly BasicArrayList EMPTY_CHILD_NAME_LIST = BasicArrayListUtil.getInstance().getImmutableInstance();
    public readonly string ABOUT = "About";
    public readonly string OPTIONS = "Options";
    public readonly string FONT_ATLAS = "/font.png";
    public readonly string OBJ_MODEL = "_obj";
    public readonly string MD2_MODEL = "_md2";
    public readonly string _PNG = ".png";
}

