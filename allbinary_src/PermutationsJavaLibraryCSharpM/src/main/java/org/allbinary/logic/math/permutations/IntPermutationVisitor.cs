// Generated Code Do Not Modify

using System;
using System.Linq;
using NullUtil = org.allbinary.logic.NullUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using Visitor = org.allbinary.logic.util.visitor.Visitor;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.math.permutations;

public class IntPermutationVisitor : Visitor
{
    public readonly int[] data;
    public IntPermutationVisitor(int[] data)
    {
        this.data = data;
    }

    private StringMaker stringBuilder = new StringMaker();
    public override object visit(object anyType)
    {
        this.stringBuilder.delete(0, stringBuilder.length());
        this.print(this.data, stringBuilder);
        return NullUtil.getInstance().NULL_OBJECT;
    }

    public virtual void print(int[] data)
    {
        StringMaker stringBuilder = new StringMaker();
        this.print(data, stringBuilder);
    }

    public virtual void print(int[] data, StringMaker stringBuilder)
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        int size = data.Length;
        for (int i = 0; i < size; i++) {
            stringBuilder.appendint(data[i]);
            stringBuilder.append(commonSeps.SPACE);
        }
        Console.WriteLine(stringBuilder.ToString());
    }

}

