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
using GameInput = org.allbinary.game.input.GameInput;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using HashtableUtil = org.allbinary.util.HashtableUtil;
using BasicAI = org.allbinary.game.ai.BasicAI;
using org.allbinary.util;

namespace org.allbinary.game.ag.ai;

public class KeyPressesAI : BasicAI
{
    private bool on = true;
    public int?[] keys;
    public KeyPressesAI(ABHashtable<object, object> hashtable, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(ownerLayerInterface, gameInput)
    {
        // base(ownerLayerInterface, gameInput) is called from the constructor declaration
        this.keys = new int?[hashtable.size()];
        object[] objectArray = HashtableUtil.getInstance().getKeysAsArray(hashtable);
        int size = objectArray.Length;
        for (int index = 0; index < size; index++) {
            this.keys[index] = ((int?) hashtable.get(((object) objectArray[index])));
        }
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        if (this.on) {
            for (int index = 0; index < this.keys.Length; index++) {
                base.processKeyAI(((int) this.keys[index]));
            }
        }
    }

    // throws Exception
    public virtual void toggle()
    {
        if (this.isOn()) {
            this.setOn(false);
        } else {
            this.setOn(true);
        }
    }

    // throws Exception
    public virtual void disable()
    {
        this.setOn(false);
    }

    // throws Exception
    public virtual void enable()
    {
        this.setOn(true);
    }

    private void setOn(bool on)
    {
        this.on = on;
    }

    public virtual bool isOn()
    {
        return this.on;
    }

}

