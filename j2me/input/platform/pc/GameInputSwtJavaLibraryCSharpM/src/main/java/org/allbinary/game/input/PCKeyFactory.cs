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
using PositionStrings = org.allbinary.math.PositionStrings;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.game.input;

public class PCKeyFactory
{
    private static readonly PCKeyFactory SINGLETON = new PCKeyFactory();
    public static PCKeyFactory getInstance()
    {
        return PCKeyFactory.SINGLETON;
    }

    public readonly PCGameKey UNKNOWN = new PCGameKey(254, "UNKNOWN");
    public readonly PCGameKey ENTER = new PCGameKey(13, "Enter");
    public readonly PCGameKey _A = new PCGameKey(65, "A");
    public readonly PCGameKey _B = new PCGameKey(66, "B");
    public readonly PCGameKey _C = new PCGameKey(67, "C");
    public readonly PCGameKey _D = new PCGameKey(68, "D");
    public readonly PCGameKey _E = new PCGameKey(69, "E");
    public readonly PCGameKey _F = new PCGameKey(70, "F");
    public readonly PCGameKey _G = new PCGameKey(71, "G");
    public readonly PCGameKey _H = new PCGameKey(72, "H");
    public readonly PCGameKey _I = new PCGameKey(73, "I");
    public readonly PCGameKey _J = new PCGameKey(74, "J");
    public readonly PCGameKey _K = new PCGameKey(75, "K");
    public readonly PCGameKey _L = new PCGameKey(76, "L");
    public readonly PCGameKey _M = new PCGameKey(77, "M");
    public readonly PCGameKey _N = new PCGameKey(78, "N");
    public readonly PCGameKey _O = new PCGameKey(79, "O");
    public readonly PCGameKey _P = new PCGameKey(80, "P");
    public readonly PCGameKey _Q = new PCGameKey(81, "Q");
    public readonly PCGameKey _R = new PCGameKey(82, "R");
    public readonly PCGameKey _S = new PCGameKey(83, "S");
    public readonly PCGameKey _T = new PCGameKey(84, "T");
    public readonly PCGameKey _U = new PCGameKey(85, "U");
    public readonly PCGameKey _V = new PCGameKey(86, "V");
    public readonly PCGameKey _W = new PCGameKey(87, "W");
    public readonly PCGameKey _X = new PCGameKey(88, "X");
    public readonly PCGameKey _Y = new PCGameKey(89, "Y");
    public readonly PCGameKey _Z = new PCGameKey(90, "Z");
    public readonly PCGameKey a = new PCGameKey(97, "a");
    public readonly PCGameKey b = new PCGameKey(98, "b");
    public readonly PCGameKey c = new PCGameKey(99, "c");
    public readonly PCGameKey d = new PCGameKey(100, "d");
    public readonly PCGameKey e = new PCGameKey(101, "e");
    public readonly PCGameKey f = new PCGameKey(102, "f");
    public readonly PCGameKey g = new PCGameKey(103, "g");
    public readonly PCGameKey h = new PCGameKey(104, "h");
    public readonly PCGameKey i = new PCGameKey(105, "i");
    public readonly PCGameKey j = new PCGameKey(106, "j");
    public readonly PCGameKey k = new PCGameKey(107, "k");
    public readonly PCGameKey l = new PCGameKey(108, "l");
    public readonly PCGameKey m = new PCGameKey(109, "m");
    public readonly PCGameKey n = new PCGameKey(110, "n");
    public readonly PCGameKey o = new PCGameKey(111, "o");
    public readonly PCGameKey p = new PCGameKey(112, "p");
    public readonly PCGameKey q = new PCGameKey(113, "q");
    public readonly PCGameKey r = new PCGameKey(114, "r");
    public readonly PCGameKey s = new PCGameKey(115, "s");
    public readonly PCGameKey t = new PCGameKey(116, "t");
    public readonly PCGameKey u = new PCGameKey(117, "u");
    public readonly PCGameKey v = new PCGameKey(118, "v");
    public readonly PCGameKey w = new PCGameKey(119, "w");
    public readonly PCGameKey x = new PCGameKey(120, PositionStrings.getInstance().X);
    public readonly PCGameKey y = new PCGameKey(121, PositionStrings.getInstance().Y);
    public readonly PCGameKey z = new PCGameKey(122, "z");
    public readonly PCGameKey ZERO = new PCGameKey(48, CommonPhoneStrings.getInstance().ZERO);
    public readonly PCGameKey ONE = new PCGameKey(49, CommonPhoneStrings.getInstance().ONE);
    public readonly PCGameKey TWO = new PCGameKey(50, CommonPhoneStrings.getInstance().TWO);
    public readonly PCGameKey THREE = new PCGameKey(51, CommonPhoneStrings.getInstance().THREE);
    public readonly PCGameKey FOUR = new PCGameKey(52, CommonPhoneStrings.getInstance().FOUR);
    public readonly PCGameKey FIVE = new PCGameKey(53, CommonPhoneStrings.getInstance().FIVE);
    public readonly PCGameKey SIX = new PCGameKey(54, CommonPhoneStrings.getInstance().SIX);
    public readonly PCGameKey SEVEN = new PCGameKey(55, CommonPhoneStrings.getInstance().SEVEN);
    public readonly PCGameKey EIGHT = new PCGameKey(56, CommonPhoneStrings.getInstance().EIGHT);
    public readonly PCGameKey NINE = new PCGameKey(57, CommonPhoneStrings.getInstance().NINE);
    public readonly PCGameKey DPAD_UP = new PCGameKey(38, CommonPhoneStrings.getInstance().UP);
    public readonly PCGameKey DPAD_DOWN = new PCGameKey(40, CommonPhoneStrings.getInstance().DOWN);
    public readonly PCGameKey DPAD_LEFT = new PCGameKey(37, CommonPhoneStrings.getInstance().LEFT);
    public readonly PCGameKey DPAD_RIGHT = new PCGameKey(39, CommonPhoneStrings.getInstance().RIGHT);
    public readonly PCGameKey DPAD_UP2;
    public readonly PCGameKey DPAD_DOWN2;
    public readonly PCGameKey DPAD_LEFT2;
    public readonly PCGameKey DPAD_RIGHT2;
    public readonly PCGameKey COMMA = new PCGameKey(44, "COMMA");
    public readonly PCGameKey SPACE = new PCGameKey(32, "SPACE");
    public readonly PCGameKey DEL = new PCGameKey(46, "DEL");
    public readonly PCGameKey STAR = new PCGameKey(42, CommonPhoneStrings.getInstance().STAR);
    public readonly PCGameKey QUESTION = new PCGameKey(47, "?");
    public readonly PCGameKey PERIOD = new PCGameKey(46, CommonSeps.getInstance().PERIOD);
    public readonly PCGameKey ESCAPE = new PCGameKey(27, "Esc");
    public readonly PCGameKey BACK_SPACE = new PCGameKey(8, "Backspace");
    public virtual bool isSubmission(Input input)
    {
        if (input == this.ENTER) {
            return true;
        }
        return false;
    }

    public virtual bool isDelete(Input input)
    {
        if (input == this.DEL) {
            return true;
        }
        return false;
    }

    public virtual bool isBackSpace(Input input)
    {
        if (input == this.BACK_SPACE) {
            return true;
        }
        return false;
    }

    public virtual bool isUp(Input input)
    {
        if (input == this.DPAD_UP || input == this.DPAD_UP2) {
            return true;
        }
        return false;
    }

    public virtual bool isDown(Input input)
    {
        if (input == this.DPAD_DOWN || input == this.DPAD_DOWN2) {
            return true;
        }
        return false;
    }

    public virtual bool isLeft(Input input)
    {
        if (input == this.DPAD_LEFT || input == this.DPAD_LEFT2) {
            return true;
        }
        return false;
    }

    public virtual bool isRight(Input input)
    {
        if (input == this.DPAD_RIGHT || input == this.DPAD_RIGHT2) {
            return true;
        }
        return false;
    }

    public virtual bool isEnter(Input input)
    {
        if (input == this.ENTER) {
            return true;
        }
        return false;
    }

    public PCKeyFactory()
    {
        this.DPAD_UP2 = this.DPAD_UP;
        this.DPAD_DOWN2 = this.DPAD_DOWN;
        this.DPAD_LEFT2 = this.DPAD_LEFT;
        this.DPAD_RIGHT2 = this.DPAD_RIGHT;
    }

}

