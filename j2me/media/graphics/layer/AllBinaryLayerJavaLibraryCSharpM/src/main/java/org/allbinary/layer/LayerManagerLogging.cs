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
using TsUtil = org.allbinary.TsUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.layer;

public class LayerManagerLogging : LayerManagerLoggingBase
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly LayerManagerLogging instance = new LayerManagerLogging();
    public static LayerManagerLogging getInstance()
    {
        return LayerManagerLogging.instance;
    }

    private readonly StringMaker stringBuilder = new StringMaker();
    private readonly string APPEND = "append";
    private readonly string APPEND_ = " append: ";
    private readonly string _AT_ = " at: ";
    private readonly string ATTEMPT_REMOVE_ = " Remove Attempt: ";
    private readonly string REMOVE_ = " Remove: ";
    private readonly string REMOVE = "remove";
    private readonly string DID_NOT_REMOVE = " Did not remove: ";
    private readonly string CLEAR = " Clear List";
    private static bool removeFailed = false;
    // throws Exception
    public override void append(AllBinaryLayer layerInterface)
    {
        this.stringBuilder.delete(0, this.stringBuilder.length());
        this.logUtil.putF(this.stringBuilder.appendint(((int) TsUtil.getInstance().hashCode(this))).append(this.APPEND_).append(layerInterface.getName()).ToString(), this, this.APPEND);
    }

    public override void appendAt(AllBinaryLayer layerInterface, int index)
    {
        this.stringBuilder.delete(0, this.stringBuilder.length());
        this.logUtil.putF(this.stringBuilder.appendint(((int) TsUtil.getInstance().hashCode(this))).append(this.APPEND_).append(layerInterface.getName()).append(this._AT_).appendint(index).ToString(), this, this.APPEND);
    }

    public override void remove(AllBinaryLayer layerInterface)
    {
        if (layerInterface == null) {
            this.stringBuilder.delete(0, this.stringBuilder.length());
            this.logUtil.putF(this.stringBuilder.appendint(((int) TsUtil.getInstance().hashCode(this))).append(this.ATTEMPT_REMOVE_).append(StringUtil.getInstance().toString(layerInterface)).ToString(), this, this.REMOVE);
        } else {
            this.stringBuilder.delete(0, this.stringBuilder.length());
            this.logUtil.putF(this.stringBuilder.appendint(((int) TsUtil.getInstance().hashCode(this))).append(this.ATTEMPT_REMOVE_).append(layerInterface.getName()).ToString(), this, this.REMOVE);
        }
    }

    public override void removeResult(LayerManager layerManager, AllBinaryLayer layerInterface, bool result)
    {
        if (layerInterface == null) {
            this.stringBuilder.delete(0, this.stringBuilder.length());
            this.logUtil.putF(this.stringBuilder.appendint(((int) TsUtil.getInstance().hashCode(this))).append(this.REMOVE_).append(StringUtil.getInstance().toString(layerInterface)).ToString(), this, this.REMOVE);
        } else if (result) {
            if (LayerManagerLogging.removeFailed) {
                this.stringBuilder.delete(0, this.stringBuilder.length());
                this.logUtil.putF(this.stringBuilder.appendint(((int) TsUtil.getInstance().hashCode(this))).append(this.REMOVE_).append(layerInterface.getName()).ToString(), this, this.REMOVE);
            }
        } else {
            this.stringBuilder.delete(0, this.stringBuilder.length());
            this.logUtil.putF(this.stringBuilder.appendint(((int) TsUtil.getInstance().hashCode(this))).append(this.DID_NOT_REMOVE).append(layerInterface.getName()).ToString(), this, this.REMOVE);
            LayerManagerLogging.removeFailed = true;
        }
    }

    private void log(LayerManager layerManager)
    {
        this.stringBuilder.delete(0, this.stringBuilder.length());
        int size = layerManager.getSize();
        CommonSeps commonSeps = CommonSeps.getInstance();
        this.stringBuilder.append(Convert.ToString(TsUtil.getInstance().hashCode(layerManager), 16)).append(commonSeps.COLON_SEP);
        this.stringBuilder.appendint(size).append(commonSeps.COLON_SEP);
        AllBinaryLayer allBinaryLayer = null;
        for (int index = 0; index < size; index++) {
            allBinaryLayer = (((AllBinaryLayer) layerManager.getLayerAt(index)));
            this.stringBuilder.append(allBinaryLayer.getName()).append(commonSeps.COMMA);
        }
        this.logUtil.putF(this.stringBuilder.ToString(), this, this.REMOVE);
    }

    public override void clear()
    {
        this.stringBuilder.delete(0, this.stringBuilder.length());
        this.logUtil.putF(this.stringBuilder.appendint(((int) TsUtil.getInstance().hashCode(this))).append(this.CLEAR).ToString(), this, this.CLEAR);
    }

}

