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
            for (int index_0 = 0; index_0 < this.topViewArray.Length; index_0++) {
                viewGroup.removeView(this.topViewArray[index_0]);
            }
            for (int index_1 = 0; index_1 < this.mainViewArray.Length; index_1++) {
                if (id != this.mainViewArray[index_1].getId()) {
                    viewGroup.removeView(this.mainViewArray[index_1]);
                }
            }
            for (int index_2 = 0; index_2 < this.mainViewArray.Length; index_2++) {
                if (id == this.mainViewArray[index_2].getId()) {
                    viewGroup.addView(this.mainViewArray[index_2]);
                    this.currentMainViewId = id;
                }
            }
            for (int index_3 = 0; index_3 < this.topViewArray.Length; index_3++) {
                viewGroup.addView(this.topViewArray[index_3]);
            }
        }
    }

}

