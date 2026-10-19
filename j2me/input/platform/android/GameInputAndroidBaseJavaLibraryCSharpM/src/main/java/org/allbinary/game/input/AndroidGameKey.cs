// Generated Code Do Not Modify

using System;
using System.Linq;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.input;

public class AndroidGameKey : Input
{
    public AndroidGameKey(int keyCode, string name) : base(keyCode, name)
    {
        // base(keyCode, name) is called from the constructor declaration
        InputFactory inputFactory = InputFactory.getInstance();
        inputFactory.inputIntegerArray[this.getId()] = this;
    }

    public override string ToString()
    {
        return "AndroidGameKey: " + base.ToString();
    }

    public static string getString(int keyCode)
    {
        Input input = InputFactory.getInstance().getInstanceById(keyCode);
        if (input != null) {
            return input.getName();
        } else {
            return StringUtil.getInstance().EMPTY_STRING;
        }
    }

}

