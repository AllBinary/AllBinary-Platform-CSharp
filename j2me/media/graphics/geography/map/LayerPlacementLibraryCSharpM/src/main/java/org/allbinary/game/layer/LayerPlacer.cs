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
using java.util;
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using LayerInterfaceFactory = org.allbinary.layer.LayerInterfaceFactory;
using LayerInterfaceVisitor = org.allbinary.layer.LayerInterfaceVisitor;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using EnumerationUtil = org.allbinary.util.EnumerationUtil;

namespace org.allbinary.game.layer;

public class LayerPlacer
{
    private readonly EnumerationUtil enumerationUtil = EnumerationUtil.getInstance();
    public readonly LayerInterfaceVisitor layerInterfaceVisitor;
    private readonly GPoint dimension;
    public LayerPlacer(LayerInterfaceVisitor layerInterfaceVisitor, GPoint dimension)
    {
        this.layerInterfaceVisitor = layerInterfaceVisitor;
        this.dimension = dimension;
    }

    // throws Exception
    public virtual void processList(BasicArrayList list)
    {
        int size = list.size();
        LayerPlacementInterface layerPlacementInterface = null;
        for (int index = 0; index < size; index++) {
            layerPlacementInterface = ((LayerPlacementInterface) list.objectArray[index]);
            this.process(layerPlacementInterface);
        }
    }

    // throws Exception
    public virtual void process(LayerPlacementInterface layerPlacementInterface)
    {
        GPoint relativePoint = this.getPoint(layerPlacementInterface);
        LayerInterfaceFactory layerInterfaceFactory = LayerInterfaceFactory.getInstance();
        ABHashtable<object, object> hashtable = layerPlacementInterface.getInstance();
        Enumeration enumeration = hashtable.keys();
        GPoint point = null;
        ABHashtable<object, object> layerHashtable = null;
        int x = 0;
        int y = 0;
        int z = 0;
        AllBinaryLayer layerInterface = null;
        while (this.enumerationUtil.hasMoreElements(enumeration)) {
            point = ((GPoint) this.enumerationUtil.nextElement(enumeration));
            layerHashtable = ((ABHashtable<object, object>) hashtable.get(point));
            x = point.getX() + relativePoint.getX();
            y = point.getY() + relativePoint.getY();
            z = point.getZ() + relativePoint.getZ();
            layerInterface = layerInterfaceFactory.getNexInstance(layerHashtable, x, y, z);
            this.layerInterfaceVisitor.visit(layerInterface);
        }
    }

    // throws Exception
    public virtual GPoint getPoint(LayerPlacementInterface layerPlacementInterface)
    {
        PointFactory pointFactory = PointFactory.getInstance();
        LayerPlacementType layerPlacementType = layerPlacementInterface.getLayerType();
        if (layerPlacementType == LayerPlacementTypeFactory.getInstance().MAP) {
            int width = layerPlacementInterface.getWidth();
            int height = layerPlacementInterface.getHeight();
            int x = ((this.dimension.getX() - width) / 2);
            int y = ((this.dimension.getY() - height) / 2);
            return pointFactory.createXY(x, y);
        } else if (layerPlacementType == LayerPlacementTypeFactory.getInstance().UP) {
            int width = layerPlacementInterface.getWidth();
            int height = layerPlacementInterface.getHeight();
            int x = ((this.dimension.getX() - width) / 2);
            int y = -height;
            return pointFactory.createXY(x, y);
        } else {
            throw new Exception("PlacementType Not Recognized");
        }
    }

}

