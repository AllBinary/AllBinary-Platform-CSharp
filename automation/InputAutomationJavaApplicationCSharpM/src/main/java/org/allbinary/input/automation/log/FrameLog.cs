/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
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
//using File = java.io.File;
//using FileOutputStream = java.io.FileOutputStream;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using ImageOutputData = org.allbinary.input.automation.ImageOutputData;
using LongUtil = org.allbinary.logic.java.number.LongUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.input.automation.log;

public class FrameLog
{
    private static sbyte[] frameBytes = new string(("Frame: ").ToCharArray()).getBytes();
    private static sbyte[] info = new string(("Info: \n").ToCharArray()).getBytes();
    private static sbyte[] actions = new string(("Actions: \n").ToCharArray()).getBytes();
    private readonly long? frame;
    private StringMaker infoStringBuffer = new StringMaker();
    private StringMaker actionsStringBuffer = new StringMaker();
    public FrameLog(long? frame)
    {
        this.frame = frame;
    }

    public virtual void addInfo(string infoString)
    {
        this.infoStringBuffer.append(infoString);
    }

    public virtual void addActions(BasicArrayList vectorOfStrings)
    {
        int size = vectorOfStrings.size();
        for (int index = 0; index < size; index++) {
            this.addAction(((string) vectorOfStrings.get(index)));
        }
    }

    public virtual void addAction(string action)
    {
        this.actionsStringBuffer.append(action);
        this.actionsStringBuffer.append(CommonSeps.getInstance().NEW_LINE);
    }

    // throws Exception
    public virtual void write()
    {
        StringMaker filePathStringBuffer = new StringMaker();
        filePathStringBuffer.append(ImageOutputData.SAVE_PATH);
        filePathStringBuffer.append(LongUtil.fillIn(this.frame.ToString()));
        filePathStringBuffer.append(".txt");
        string filePath = filePathStringBuffer.ToString();
        FileOutputStream fileOutputStream = new FileOutputStream(new File(filePath));
        fileOutputStream.write(FrameLog.frameBytes);
        fileOutputStream.write(System.Array.ConvertAll(System.Text.Encoding.UTF8.GetBytes(getFrame().ToString()), value => unchecked((sbyte) value)));
        fileOutputStream.write('\n');
        fileOutputStream.write(FrameLog.info);
        fileOutputStream.write(System.Array.ConvertAll(System.Text.Encoding.UTF8.GetBytes(this.infoStringBuffer.ToString()), value => unchecked((sbyte) value)));
        fileOutputStream.write('\n');
        fileOutputStream.write(FrameLog.actions);
        fileOutputStream.write(System.Array.ConvertAll(System.Text.Encoding.UTF8.GetBytes(this.actionsStringBuffer.ToString()), value => unchecked((sbyte) value)));
        fileOutputStream.close();
    }

    public virtual long? getFrame()
    {
        return this.frame;
    }

}

