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
using InputImageType = org.allbinary.input.media.image.InputImageType;

namespace org.allbinary.input.automation.module.generic.configuration.profile;

public class SavedCaptureGenericProfileDataWorkerType : GenericProfileDataWorkerType
{
    public static SavedCaptureGenericProfileDataWorkerType SAVED_CAPTURE = new SavedCaptureGenericProfileDataWorkerType("Saved " + InputImageType.CAPTURE.getName(), "c:\\share\\captures\\2\\", 100);
    private string path = null;
    private int lastFrame = 0;
    public SavedCaptureGenericProfileDataWorkerType(string name, string path, int lastFrame) : base(name)
    {
        // base(name) is called from the constructor declaration
        this.setPath(path);
        this.setLastFrame(lastFrame);
    }

    public virtual string getPath()
    {
        return this.path;
    }

    public virtual void setPath(string path)
    {
        this.path = path;
    }

    public virtual int getLastFrame()
    {
        return this.lastFrame;
    }

    public virtual void setLastFrame(int lastFrame)
    {
        this.lastFrame = lastFrame;
    }

}

