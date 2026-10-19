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

    private readonly ABKeyEventWrapper keyEventWrapper = ABKeyEventWrapper.getInstance();
    public readonly PCGameKey UNKNOWN;
    public readonly PCGameKey ENTER = new PCGameKey(5, "Enter");
    public readonly PCGameKey _A;
    public readonly PCGameKey _B;
    public readonly PCGameKey _C;
    public readonly PCGameKey _D;
    public readonly PCGameKey _E;
    public readonly PCGameKey _F;
    public readonly PCGameKey _G;
    public readonly PCGameKey _H;
    public readonly PCGameKey _I;
    public readonly PCGameKey _J;
    public readonly PCGameKey _K;
    public readonly PCGameKey _L;
    public readonly PCGameKey _M;
    public readonly PCGameKey _N;
    public readonly PCGameKey _O;
    public readonly PCGameKey _P;
    public readonly PCGameKey _Q;
    public readonly PCGameKey _R;
    public readonly PCGameKey _S;
    public readonly PCGameKey _T;
    public readonly PCGameKey _U;
    public readonly PCGameKey _V;
    public readonly PCGameKey _W;
    public readonly PCGameKey _X;
    public readonly PCGameKey _Y;
    public readonly PCGameKey _Z;
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
    public readonly PCGameKey ZERO;
    public readonly PCGameKey ONE;
    public readonly PCGameKey TWO;
    public readonly PCGameKey THREE;
    public readonly PCGameKey FOUR;
    public readonly PCGameKey FIVE;
    public readonly PCGameKey SIX;
    public readonly PCGameKey SEVEN;
    public readonly PCGameKey EIGHT;
    public readonly PCGameKey NINE;
    public readonly PCGameKey DPAD_UP;
    public readonly PCGameKey DPAD_DOWN;
    public readonly PCGameKey DPAD_LEFT;
    public readonly PCGameKey DPAD_RIGHT;
    public readonly PCGameKey DPAD_UP2;
    public readonly PCGameKey DPAD_DOWN2;
    public readonly PCGameKey DPAD_LEFT2;
    public readonly PCGameKey DPAD_RIGHT2;
    public readonly PCGameKey COMMA;
    public readonly PCGameKey SPACE;
    public readonly PCGameKey DEL;
    public readonly PCGameKey STAR = new PCGameKey(42, CommonPhoneStrings.getInstance().STAR);
    public readonly PCGameKey QUESTION = new PCGameKey(47, "?");
    public readonly PCGameKey PERIOD;
    public readonly PCGameKey ESCAPE;
    public readonly PCGameKey BACK_SPACE;
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
        this.UNKNOWN = new PCGameKey(this.keyEventWrapper.VK_UNDEFINED, "UNKNOWN");
        this._A = new PCGameKey(this.keyEventWrapper.VK_A, "A");
        this._B = new PCGameKey(this.keyEventWrapper.VK_B, "B");
        this._C = new PCGameKey(this.keyEventWrapper.VK_C, "C");
        this._D = new PCGameKey(this.keyEventWrapper.VK_D, "D");
        this._E = new PCGameKey(this.keyEventWrapper.VK_E, "E");
        this._F = new PCGameKey(this.keyEventWrapper.VK_F, "F");
        this._G = new PCGameKey(this.keyEventWrapper.VK_G, "G");
        this._H = new PCGameKey(this.keyEventWrapper.VK_H, "H");
        this._I = new PCGameKey(this.keyEventWrapper.VK_I, "I");
        this._J = new PCGameKey(this.keyEventWrapper.VK_J, "J");
        this._K = new PCGameKey(this.keyEventWrapper.VK_K, "K");
        this._L = new PCGameKey(this.keyEventWrapper.VK_L, "L");
        this._M = new PCGameKey(this.keyEventWrapper.VK_M, "M");
        this._N = new PCGameKey(this.keyEventWrapper.VK_N, "N");
        this._O = new PCGameKey(this.keyEventWrapper.VK_O, "O");
        this._P = new PCGameKey(this.keyEventWrapper.VK_P, "P");
        this._Q = new PCGameKey(this.keyEventWrapper.VK_Q, "Q");
        this._R = new PCGameKey(this.keyEventWrapper.VK_R, "R");
        this._S = new PCGameKey(this.keyEventWrapper.VK_S, "S");
        this._T = new PCGameKey(this.keyEventWrapper.VK_T, "T");
        this._U = new PCGameKey(this.keyEventWrapper.VK_U, "U");
        this._V = new PCGameKey(this.keyEventWrapper.VK_V, "V");
        this._W = new PCGameKey(this.keyEventWrapper.VK_W, "W");
        this._X = new PCGameKey(this.keyEventWrapper.VK_X, "X");
        this._Y = new PCGameKey(this.keyEventWrapper.VK_Y, "Y");
        this._Z = new PCGameKey(this.keyEventWrapper.VK_Z, "Z");
        this.ZERO = new PCGameKey(this.keyEventWrapper.VK_0, CommonPhoneStrings.getInstance().ZERO);
        this.ONE = new PCGameKey(this.keyEventWrapper.VK_1, CommonPhoneStrings.getInstance().ONE);
        this.TWO = new PCGameKey(this.keyEventWrapper.VK_2, CommonPhoneStrings.getInstance().TWO);
        this.THREE = new PCGameKey(this.keyEventWrapper.VK_3, CommonPhoneStrings.getInstance().THREE);
        this.FOUR = new PCGameKey(this.keyEventWrapper.VK_4, CommonPhoneStrings.getInstance().FOUR);
        this.FIVE = new PCGameKey(this.keyEventWrapper.VK_5, CommonPhoneStrings.getInstance().FIVE);
        this.SIX = new PCGameKey(this.keyEventWrapper.VK_6, CommonPhoneStrings.getInstance().SIX);
        this.SEVEN = new PCGameKey(this.keyEventWrapper.VK_7, CommonPhoneStrings.getInstance().SEVEN);
        this.EIGHT = new PCGameKey(this.keyEventWrapper.VK_8, CommonPhoneStrings.getInstance().EIGHT);
        this.NINE = new PCGameKey(this.keyEventWrapper.VK_9, CommonPhoneStrings.getInstance().NINE);
        this.DPAD_UP = new PCGameKey(this.keyEventWrapper.VK_UP, CommonPhoneStrings.getInstance().UP);
        this.DPAD_DOWN = new PCGameKey(this.keyEventWrapper.VK_DOWN, CommonPhoneStrings.getInstance().DOWN);
        this.DPAD_LEFT = new PCGameKey(this.keyEventWrapper.VK_LEFT, CommonPhoneStrings.getInstance().LEFT);
        this.DPAD_RIGHT = new PCGameKey(this.keyEventWrapper.VK_RIGHT, CommonPhoneStrings.getInstance().RIGHT);
        this.DPAD_UP2 = this.DPAD_UP;
        this.DPAD_DOWN2 = this.DPAD_DOWN;
        this.DPAD_LEFT2 = this.DPAD_LEFT;
        this.DPAD_RIGHT2 = this.DPAD_RIGHT;
        this.COMMA = new PCGameKey(this.keyEventWrapper.VK_COMMA, "COMMA");
        this.SPACE = new PCGameKey(this.keyEventWrapper.VK_SPACE, "SPACE");
        this.DEL = new PCGameKey(this.keyEventWrapper.VK_DELETE, "DEL");
        this.PERIOD = new PCGameKey(this.keyEventWrapper.VK_PERIOD, CommonSeps.getInstance().PERIOD);
        this.ESCAPE = new PCGameKey(this.keyEventWrapper.VK_ESCAPE, "Esc");
        this.BACK_SPACE = new PCGameKey(this.keyEventWrapper.VK_BACK_SPACE, "Backspace");
    }

}

