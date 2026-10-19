// Generated Code Do Not Modify

using System;
using System.Linq;
//using Graphics = javax.microedition.lcdui.Graphics;

namespace org.allbinary.graphics.form.item;

public interface ABCustomItemInterface
{
    int getMinimumWidth();

    int getMinimumHeight();

    string getLabel();

    void paintXY(Graphics graphics, int x, int y);

    void paintUnselected(Graphics graphics, int x, int y);

}

