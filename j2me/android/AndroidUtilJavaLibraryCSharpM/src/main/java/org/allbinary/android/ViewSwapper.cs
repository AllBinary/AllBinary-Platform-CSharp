// Generated Code Do Not Modify

using System;
using System.Linq;
using Activity = android.app.Activity;
using View = android.view.View;
using ViewGroup = android.view.ViewGroup;

namespace org.allbinary.android;

public class ViewSwapper
{
    public static readonly View[] NULL_VIEW_ARRAY = new View[0];
    private readonly int rootViewId;
    private readonly Activity activity;
    private int currentMainViewId = -1;
    private View[] mainViewArray = ViewSwapper.NULL_VIEW_ARRAY;
    private View[] topViewArray = ViewSwapper.NULL_VIEW_ARRAY;
    public ViewSwapper(Activity activity, int rootViewId)
    {
        this.activity = activity;
        this.rootViewId = rootViewId;
    }

    public virtual void setMainViews(View[] viewArray)
    {
        this.mainViewArray = viewArray;
    }

    public virtual void setTopViewArray(View[] topViewArray)
    {
        this.topViewArray = topViewArray;
    }

    public virtual void setMainView(int id)
    {
        ViewGroup viewGroup = ((ViewGroup) this.activity.findViewById(this.rootViewId));
        if (id != this.currentMainViewId) {
            for (int index = 0; index < this.topViewArray.Length; index++) {
                viewGroup.removeView(this.topViewArray[index]);
            }
            for (int index = 0; index < this.mainViewArray.Length; index++) {
                if (id != this.mainViewArray[index].getId()) {
                    viewGroup.removeView(this.mainViewArray[index]);
                }
            }
            for (int index = 0; index < this.mainViewArray.Length; index++) {
                if (id == this.mainViewArray[index].getId()) {
                    viewGroup.addView(this.mainViewArray[index]);
                    this.currentMainViewId = id;
                }
            }
            for (int index = 0; index < this.topViewArray.Length; index++) {
                viewGroup.addView(this.topViewArray[index]);
            }
        }
    }

}

