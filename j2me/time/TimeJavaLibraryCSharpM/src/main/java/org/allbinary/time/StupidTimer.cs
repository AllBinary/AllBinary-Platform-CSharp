// Generated Code Do Not Modify

using System;
using System.Linq;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Visitor = org.allbinary.logic.util.visitor.Visitor;
using CommonStrings = org.allbinary.@string.CommonStrings;
using ThreadObjectUtil = org.allbinary.thread.ThreadObjectUtil;

namespace org.allbinary.time;

public class StupidTimer
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly NullUtil nullUtil = NullUtil.getInstance();
    private readonly ThreadObjectUtil threadObjectUtil = ThreadObjectUtil.getInstance();
    private bool visitBool(Visitor visitorInterface)
    {
        bool? result = ((bool?) visitorInterface.visit(this.nullUtil.NULL_OBJECT));
        bool result2 = result;
        return result2;
    }

    // throws Exception
    public void visit(Visitor visitorInterface, TimeDelayHelper timeDelayHelper)
    {
        bool tookTooLong = false;
        string WAITING_FOR = "Waiting for: ";
        PreLogUtil.put(new StringMaker().append(WAITING_FOR).append(StringUtil.getInstance().toString(visitorInterface)).ToString(), this, this.commonStrings.VISIT);
        int index = 0;
        while (this.visitBool(visitorInterface)) {
            if (index % 10 == 0) {
                PreLogUtil.put(new StringMaker().append(WAITING_FOR).appendint(index).ToString(), this, this.commonStrings.VISIT);
            }
            index++;
            lock (this) {
                this.threadObjectUtil.waitObjectFor(this, 1800);
            }
            if (timeDelayHelper.isTimeTNT()) {
                tookTooLong = true;
                break;
            }
        }
        if (tookTooLong) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.VISIT, new Exception(new StringMaker().append("Took Too Long: ").append(StringUtil.getInstance().toString(visitorInterface)).ToString()));
        } else {
            PreLogUtil.put(timeDelayHelper.ToString(), this, this.commonStrings.VISIT);
        }
    }

    // throws Exception
    public virtual void stopWaiting()
    {
        lock (this) {
            this.threadObjectUtil.notifyObject(this);
        }
    }

}

