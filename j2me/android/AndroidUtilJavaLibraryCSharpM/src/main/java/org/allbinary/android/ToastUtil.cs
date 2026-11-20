// Generated Code Do Not Modify

using System;
using System.Linq;
using Context = android.content.Context;
using View = android.view.View;
using Toast = android.widget.Toast;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.android;

public class ToastUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ToastUtil instance = new ToastUtil();
    public static ToastUtil getInstance()
    {
        return ToastUtil.instance;
    }

    public virtual void makeToast(View view, Context context, string message, int time)
    {
        view.post(new MakeToast(this, context, message, time));
    }

    //A member class instead of a local class using the method parameters since most of the converted languages do not have local classes.
    private class MakeToast : global::java.lang.Runnable
    {
        private readonly ToastUtil outer;

        private readonly Context context;
        private readonly string @string;
        private readonly int time;
        public MakeToast(ToastUtil outer, Context context, string @string, int time)
        {
            this.outer = outer;
            this.context = context;
            this.@string = @string;
            this.time = time;
        }

        public virtual void run()
        {
            LogUtil logUtil = LogUtil.getInstance();
            try {
                Toast.makeText(this.context, this.@string, this.time).show();
            } catch (Exception e) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
            }
        }

    }
}

