// Generated Code Do Not Modify

using System;
using System.Linq;
using TsUtil = org.allbinary.TsUtil;
using NullUtil = org.allbinary.logic.NullUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using Visitor = org.allbinary.logic.util.visitor.Visitor;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.math.permutations;

public class ObjectPermutationVisitor : Visitor
{
    public readonly object[] data;
    public ObjectPermutationVisitor(object[] data)
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

    public virtual void print(object[] data)
    {
        StringMaker stringBuilder = new StringMaker();
        this.print(data, stringBuilder);
    }

    public virtual void print(object[] data, StringMaker stringBuilder)
    {
        TsUtil tsUtil = TsUtil.getInstance();
        int size = data.Length;
        for (int i = 0; i < size; i++) {
            stringBuilder.appendint(((int) tsUtil.hashCode(data[i])));
            stringBuilder.append(CommonSeps.getInstance().SPACE);
        }
        Console.WriteLine(stringBuilder.ToString());
    }

}

