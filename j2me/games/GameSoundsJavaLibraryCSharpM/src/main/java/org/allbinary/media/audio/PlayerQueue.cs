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
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.media.audio;

public class PlayerQueue
{
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly BasicArrayList list = new BasicArrayListD();
    private int max;
    private static readonly string TOTAL = "Sounds In Queue: ";
    public PlayerQueue(int max)
    {
        this.max = max;
    }

    public virtual void add(Sound sound)
    {
        try {
            if (!this.list.contains(sound)) {
                this.list.add(sound);
            }
        } catch (Exception e) {
            PreLogUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.ADD);
        }
    }

    public virtual bool process()
    {
        Sound sound = NoSound.getInstance();
        try {
            bool played = false;
            if (this.list.size() > 0) {
                sound = ((Sound) this.list.removeAt(0));
                if (sound != null) {
                    sound.getPlayerP().start();
                }
                while (this.list.size() > this.max) {
                    this.list.removeAt(0);
                }
                played = true;
            }
            return played;
        } catch (Exception e) {
            string resource = StringUtil.getInstance().EMPTY_STRING;
            if (sound != null) {
                resource = sound.getResource();
            }
            PreLogUtil.put(new StringMaker().append(this.commonStrings.EXCEPTION_LABEL).append(resource).ToString(), this, this.commonStrings.PROCESS);
            return false;
        }
    }

    public virtual void clear()
    {
        this.list.clear();
    }

    public override string ToString()
    {
        return new StringMaker().append(PlayerQueue.TOTAL).appendint(this.list.size()).ToString();
    }

}

