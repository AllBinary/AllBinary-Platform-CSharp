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
using AllBinaryGameLayer = org.allbinary.game.layer.AllBinaryGameLayer;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.media.graphics.geography.map;

public class GeographicMapEventHandler : BasicEventHandler
{
    private static GeographicMapEventHandler instance = new GeographicMapEventHandler();
    public static GeographicMapEventHandler getInstance()
    {
        return GeographicMapEventHandler.instance;
    }

    private readonly BasicArrayList list = new BasicArrayListD();
    private GeographicMapEventHandler()
    {
    }

    public virtual void addListener(AllBinaryGameLayer gameLayer)
    {
        if (!this.list.contains(gameLayer)) {
            this.list.add(gameLayer);
        }
    }

    public override void removeAllListeners()
    {
        this.list.clear();
        base.removeAllListeners();
    }

    public override void removeListener(EventListenerInterface eventListenerInterface)
    {
        this.list.remove(eventListenerInterface);
        base.removeListener(eventListenerInterface);
    }

    public virtual void fireEvent()
    {
        for (int index = this.list.size(); --index >= 0; ) {
            try {
                AllBinaryGameLayer gameLayer = ((AllBinaryGameLayer) this.list.get(index));
                gameLayer.move();
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
        }
    }

}

