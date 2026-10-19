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
//using Player = javax.microedition.media.Player;
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.audio;

public class Sounds
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly SoundStrings soundStrings = SoundStrings.getInstance();
    private readonly SoundsFactoryInterface soundsFactoryInterface;
    public Sounds(SoundsFactoryInterface soundsFactoryInterface)
    {
        this.soundsFactoryInterface = soundsFactoryInterface;
    }

    // throws Exception
    public virtual void init()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.INIT);
        CommonLabels commonLabels = CommonLabels.getInstance();
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        this.soundsFactoryInterface.init();
        Sound[] soundInterfaceArray = this.soundsFactoryInterface.getSoundInterfaceArray();
        SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
        int? indexInteger = null;
        string indexString = null;
        StringMaker stringBuffer = new StringMaker();
        for (int i = 0; i < soundInterfaceArray.Length; i++) {
            Sound soundInterface = soundInterfaceArray[i];
            if (soundInterface != null) {
                indexInteger = smallIntegerSingletonFactory.getAt(i);
                indexString = indexInteger.ToString();
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append(commonLabels.INDEX_LABEL);
                stringBuffer.append(indexString);
                stringBuffer.append(this.soundStrings.SOUND);
                stringBuffer.append(soundInterface.GetType().FullName);
                this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.INIT);
                soundInterface.init();
                progressCanvas.addNormalPortion(100, new StringMaker().append(this.soundStrings.INIT_SOUND).append(indexString).ToString());
            }
        }
        this.soundsFactoryInterface.setInitialized(true);
        this.logUtil.putF(this.commonStrings.END, this, this.commonStrings.INIT);
    }

    // throws Exception
    public virtual void stopAll()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.soundStrings.STOP_ALL);
        Sound[] soundInterfaceArray = this.soundsFactoryInterface.getSoundInterfaceArray();
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        Player player = null;
        for (int index = 0; index < soundInterfaceArray.Length; index++) {
            if (soundInterfaceArray[index] != null) {
                player = soundInterfaceArray[index].getPlayerP();
                if (player != null) {
                    player.stop();
                    progressCanvas.addPortion(100, this.soundStrings.STOPPING_SOUND, index);
                }
            }
        }
    }

    // throws Exception
    public virtual void closeAll()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.soundStrings.CLOSE_ALL);
        Sound[] soundInterfaceArray = this.soundsFactoryInterface.getSoundInterfaceArray();
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        Player player = null;
        for (int index = 0; index < soundInterfaceArray.Length; index++) {
            if (soundInterfaceArray[index] != null) {
                player = soundInterfaceArray[index].getPlayerP();
                if (player != null) {
                    player.close();
                    progressCanvas.addPortion(100, this.soundStrings.CLOSING_SOUND, index);
                }
            }
        }
    }

}

