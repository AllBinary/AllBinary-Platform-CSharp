// Generated Code Do Not Modify

using System;
using System.Linq;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.graphics.form.item;

public class ABCustomGaugeItem : ABCustomItem
{
    public static readonly ABCustomGaugeItem NULL_GAUGE_ITEM = new ABCustomGaugeItem(StringUtil.getInstance().EMPTY_STRING, 1, 0, BasicColorFactory.getInstance().BLACK, BasicColorFactory.getInstance().WHITE);
    public ABCustomGaugeItem(string label, int maxValue, int initialValue, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(label, backgroundBasicColor, foregroundBasicColor)
    {
        // base(label, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
    }

}

