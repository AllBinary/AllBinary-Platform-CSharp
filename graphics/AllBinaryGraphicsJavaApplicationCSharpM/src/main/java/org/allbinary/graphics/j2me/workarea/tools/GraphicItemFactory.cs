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
using LOGGING = org.allbinary.log.LOGGING;
using StdUtil = org.allbinary.logic.StdUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using Node = org.w3c.dom.Node;

namespace org.allbinary.graphics.j2me.workarea.tools;

public class GraphicItemFactory
{
    private static readonly GraphicItemFactory instance = new GraphicItemFactory();
    public static GraphicItemFactory getInstance()
    {
        return GraphicItemFactory.instance;
    }

    private readonly HashMap<object, object> graphicItems;
    private readonly GraphicsItemInterfaceFactoryInterface DEFAULT = new SelectionToolFactory();
    private GraphicItemFactory()
    {
        this.graphicItems = StdUtil.getInstance().createHashMap();
        this.graphicItems.put(LinesGraphicItem.getStaticName(), new LinesGraphicItemFactory());
    }

    public virtual GraphicsItemInterfaceFactoryInterface getInstance(string itemName)
    {
        GraphicsItemInterfaceFactoryInterface graphicsItemInterfaceFactoryInterface = ((GraphicsItemInterfaceFactoryInterface) this.graphicItems.get(itemName));
        if (graphicsItemInterfaceFactoryInterface == null) {
            graphicsItemInterfaceFactoryInterface = DEFAULT;
        }
        return graphicsItemInterfaceFactoryInterface;
    }

    // throws Exception
    public virtual HashMap<object, object> getInstance(BasicArrayList graphicItemNodeList)
    {
        int numberOfItems = graphicItemNodeList.size();
        HashMap<object, object> graphicItemHashMap = StdUtil.getInstance().createHashMap();
        if (LOGGING.contains(LOGGING.MENUEVENT)) {
        }
        for (int index = 0; index < numberOfItems; index++) {
            GraphicItemInterface graphicItem = GraphicItemBuilder.getInstance(((Node) graphicItemNodeList.get(index)));
            graphicItemHashMap.put(graphicItem.getTreeNode(), graphicItem);
        }
        return graphicItemHashMap;
    }

}

