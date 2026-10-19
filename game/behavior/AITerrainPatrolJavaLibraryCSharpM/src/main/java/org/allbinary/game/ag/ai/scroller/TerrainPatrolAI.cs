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
using BasicTerrainInfo = org.allbinary.game.terrain.BasicTerrainInfo;
using TerrainEvent = org.allbinary.game.terrain.TerrainEvent;
using TerrainEventCircularStaticPool = org.allbinary.game.terrain.TerrainEventCircularStaticPool;
using TerrainEventHandler = org.allbinary.game.terrain.TerrainEventHandler;
using TerrainEventListener = org.allbinary.game.terrain.TerrainEventListener;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using Angle = org.allbinary.math.Angle;
using AngleFactory = org.allbinary.math.AngleFactory;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.ag.ai.scroller;

public class TerrainPatrolAI : PacePatrolAI
{
    private readonly TerrainEventListener terrainEventListener = new TerrainEventListener();
    private readonly Angle DOWN = AngleFactory.getInstance().DOWN;
    private readonly BasicTerrainInfo CLIFF;
    public TerrainPatrolAI(ABHashtable<object, object> hashtable, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(hashtable, ownerLayerInterface, gameInput)
    {
        this.CLIFF = new BasicTerrainInfo(this.DOWN);
        // base(hashtable, ownerLayerInterface, gameInput) is called from the constructor declaration
        TerrainEventHandler.getInstance(ownerLayerInterface).addListener(this.terrainEventListener);
        this.terrainEventListener.onTerrainEvent(TerrainEventCircularStaticPool.getInstance().getNext(this.CLIFF));
    }

    protected override void update()
    {
        base.update();
        this.changeDirectionIfCliffReached();
    }

    private void changeDirectionIfCliffReached()
    {
        BasicArrayList list = this.terrainEventListener.getList();
        int size = list.size();
        for (int index = 0; index < size; index++) {
            TerrainEvent terrainEvent = ((TerrainEvent) list.removeAt(index));
            BasicTerrainInfo basicTerrainInfo = terrainEvent.getBasicTerrainInfo();
            Angle angle = basicTerrainInfo.getAngle();
            if (angle == this.DOWN) {
                this.nextDirection();
                if (!this.isFollowLimitedByTerrain) {
                    this.logUtil.putF("Following Limited", this, "onTerrainEvent");
                    this.isFollowLimitedByTerrain = true;
                }
            }
        }
    }

}

