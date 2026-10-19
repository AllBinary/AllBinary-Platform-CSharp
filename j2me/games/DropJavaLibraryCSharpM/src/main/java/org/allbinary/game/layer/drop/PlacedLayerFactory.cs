// Generated Code Do Not Modify

using System;
using System.Linq;
using AllBinaryLayerFactoryInterface = org.allbinary.layer.AllBinaryLayerFactoryInterface;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.game.layer.drop;

public class PlacedLayerFactory
{
    private static readonly PlacedLayerFactory instance = new PlacedLayerFactory();
    private readonly BasicArrayList list = new BasicArrayListD();
    private PlacedLayerFactory()
    {
    }

    public virtual void clear()
    {
        this.list.clear();
    }

    public static PlacedLayerFactory getInstance()
    {
        return PlacedLayerFactory.instance;
    }

    public virtual int getSize()
    {
        return this.list.size();
    }

    private readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    public virtual AllBinaryLayerFactoryInterface getRandomInstance()
    {
        return ((AllBinaryLayerFactoryInterface) this.basicArrayListUtil.getRandom(this.list));
    }

    public virtual void add(AllBinaryLayerFactoryInterface layerInterfaceFactoryInterface)
    {
        this.list.add(layerInterfaceFactoryInterface);
    }

}

