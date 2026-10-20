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
        class MakeToast : global::java.lang.Runnable
        {
            public readonly string @string;
            public MakeToast(string @string)
            {
                this.@string = @string;
            }

            public virtual void run()
            {
                LogUtil logUtil = LogUtil.getInstance();
                try {
                    Toast.makeText(context, this.@string, time).show();
                } catch (Exception e) {
                    CommonStrings commonStrings = CommonStrings.getInstance();
                    logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
                }
            }

        }
        view.post(new MakeToast(message));
    }

}

