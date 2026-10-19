// Generated Code Do Not Modify

using System;
using System.Linq;
//using Graphics = javax.microedition.lcdui.Graphics;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.graphics.form;

public class ABCustomForm : CustomScreen
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public ABCustomForm(string title, ABCustomItem[] items, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor)
    {
    }

    public virtual ABCustomItem[] getAllitems()
    {
        return new ABCustomItem[0];
    }

    public virtual int size()
    {
        return 0;
    }

    public virtual void setSelectedIndex(int index)
    {
    }

    public virtual int getSelectedIndex()
    {
        return 0;
    }

    public virtual void deleteAll()
    {
    }

    public virtual void delete(int itemNum)
    {
    }

    public virtual int append(ABCustomItem item)
    {
        return -1;
    }

    public virtual void insert(int itemNum, ABCustomItem item)
    {
    }

    public virtual void set(int itemNum, ABCustomItem item)
    {
    }

    public virtual ABCustomItem get(int itemNum)
    {
        return ABCustomItem.getNullInstance();
    }

    public virtual int getWidth()
    {
        throw new SystemException();
    }

    public virtual void paint(Graphics graphics)
    {
    }

    public virtual string getTitle()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

}

