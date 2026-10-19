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
using GameTickTimeDelayHelper = org.allbinary.time.GameTickTimeDelayHelper;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using org.allbinary.util;

namespace org.allbinary.game.ag.ai;

public class MultiKeyPressesAI : KeyPressesAI
{
    private readonly TimeDelayHelper toggleTimeHelper = new TimeDelayHelper(600);
    private readonly GameTickTimeDelayHelper gameTickTimeDelayHelper = GameTickTimeDelayHelperFactory.getInstance();
    public MultiKeyPressesAI(ABHashtable<object, object> hashtable, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(hashtable, ownerLayerInterface, gameInput)
    {
        // base(hashtable, ownerLayerInterface, gameInput) is called from the constructor declaration
        this.update();
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
    }

    // throws Exception
    private void update()
    {
        GameInput gameInput = this.getGameInput();
        int?[] keys = this.keys;
        int size = keys.Length;
        if (this.isOn()) {
            for (int index = 0; index < size; index++) {
                int key = ((int) keys[index]);
                if (key != -1) {
                    gameInput.add(this.gameKeyEventFactory.getInstanceForKey(this, key));
                }
            }
        } else {
            for (int index = 0; index < size; index++) {
                int key = ((int) keys[index]);
                if (key != -1) {
                    gameInput.addForRemoval(this.gameKeyEventFactory.getInstanceForKey(this, key));
                }
            }
        }
    }

    // throws Exception
    public override void toggle()
    {
        if (this.toggleTimeHelper.isTime(this.gameTickTimeDelayHelper.startTime)) {
            base.toggle();
            this.update();
        }
    }

    // throws Exception
    public override void disable()
    {
        if (this.toggleTimeHelper.isTime(this.gameTickTimeDelayHelper.startTime)) {
            base.disable();
            this.update();
        }
    }

    // throws Exception
    public override void enable()
    {
        if (this.toggleTimeHelper.isTime(this.gameTickTimeDelayHelper.startTime)) {
            base.enable();
            this.update();
        }
    }

}

