/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
//using Graphics = javax.microedition.lcdui.Graphics;

namespace org.allbinary.graphics.font;

public class UpdateMyFontProcessor : MyFontProcessor
{
    private readonly UpdateMyFontInterface updateMeasurementProcessor;
    public UpdateMyFontProcessor(UpdateMyFontInterface keyValueDrawCharArray)
    {
        this.updateMeasurementProcessor = keyValueDrawCharArray;
    }

    public override void process(Graphics graphics)
    {
        this.updateMeasurementProcessor.updateMeasurement(graphics);
    }

}

