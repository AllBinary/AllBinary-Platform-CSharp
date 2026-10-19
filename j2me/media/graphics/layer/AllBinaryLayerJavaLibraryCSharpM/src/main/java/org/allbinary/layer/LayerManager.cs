// Generated Code Do Not Modify

using System;
using System.Linq;
//using Graphics = javax.microedition.lcdui.Graphics;
using TsUtil = org.allbinary.TsUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using SynchObject = org.allbinary.thread.SynchObject;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using ABSystemWrapper = org.allbinary.logic.ABSystemWrapper;

namespace org.allbinary.layer;

public class LayerManager
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ABSystemWrapper systemWrapper = ABSystemWrapper.getInstance();
    private readonly TsUtil tsUtil = TsUtil.getInstance();
    private readonly LayerManagerLoggingBase layerManagerLogging;
    private readonly BasicArrayList list = new BasicArrayListD();
    private readonly SynchObject anyType = new SynchObject();
    public LayerManager(LayerManagerLoggingBase layerManagerLogging)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.layerManagerLogging = layerManagerLogging;
    }

    public virtual bool contains(AllBinaryLayer layerInterface)
    {
        return this.list.contains(layerInterface);
    }

    // throws Exception
    public virtual void update(AllBinaryLayer layerInterface)
    {
        bool had = this.list.remove(layerInterface);
        if (had) {
            AllBinaryLayer nextLayerInterface = null;
            int size = this.list.size();
            for (int index = 0; index < size; index++) {
                nextLayerInterface = ((AllBinaryLayer) this.list.get(index));
                if (layerInterface.getZP() > nextLayerInterface.getZP()) {
                    this.list.addAt(index, layerInterface);
                    return;
                }
            }
            this.list.add(layerInterface);
        }
    }

    // throws Exception
    public virtual void insert(AllBinaryLayer layerInterface)
    {
        AllBinaryLayer nextLayerInterface = null;
        int size = this.list.size();
        for (int index = 0; index < size; index++) {
            nextLayerInterface = ((AllBinaryLayer) this.list.get(index));
            if (layerInterface.getZP() > nextLayerInterface.getZP()) {
                this.appendAt(layerInterface, index);
                return;
            }
        }
        this.append(layerInterface);
    }

    // throws Exception
    public virtual void append(AllBinaryLayer layerInterface)
    {
        this.layerManagerLogging.append(layerInterface);
        this.list.add(layerInterface);
    }

    // throws Exception
    public virtual void appendAt(AllBinaryLayer layerInterface, int index)
    {
        this.layerManagerLogging.appendAt(layerInterface, index);
        this.list.addAt(index, layerInterface);
    }

    // throws Exception
    public virtual void remove(AllBinaryLayer layerInterface)
    {
        lock (this.anyType) {
            this.layerManagerLogging.remove(layerInterface);
            bool result = this.list.remove(layerInterface);
            this.layerManagerLogging.removeResult(this, layerInterface, result);
        }
    }

    public virtual Layer getLayerAt(int index)
    {
        return ((Layer) this.list.objectArray[index]);
    }

    public virtual int getSize()
    {
        return this.list.size();
    }

    // throws Exception
    public virtual void cleanup()
    {
        lock (this.anyType) {
            this.list.clear();
            this.layerManagerLogging.clear();
            this.tsUtil.gc();
            this.tsUtil.gc();
        }
    }

    public virtual void paint(Graphics g, int x, int y)
    {
        lock (this.anyType) {
            Layer comp = null;
            for (int index = this.list.size(); --index >= 0; ) {
                comp = ((Layer) this.list.objectArray[index]);
                if (comp != null && comp.isVisible()) {
                    comp.paint(g);
                }
            }
        }
    }

}

