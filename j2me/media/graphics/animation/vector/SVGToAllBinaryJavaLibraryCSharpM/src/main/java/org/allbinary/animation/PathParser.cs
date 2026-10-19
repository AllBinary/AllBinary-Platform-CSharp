// Generated Code Do Not Modify

using System;
using System.Linq;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.animation;

public class PathParser
{
    private static string[] tokenize(string d)
    {
        BasicArrayList tokens = new BasicArrayListD();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < d.Length; i++) {
            char c = d[i];
            if (c == ' ' || c == ',' || c == '\t' || c == '\n' || c == '\r') {
                if (sb.Length > 0) {
                    tokens.add(sb.ToString());
                    sb.setLength(0);
                }
            } else if (c == 'M' || c == 'm' || c == 'L' || c == 'l' || c == 'V' || c == 'v' || c == 'C' || c == 'c' || c == 'Z' || c == 'z') {
                if (sb.Length > 0) {
                    tokens.add(sb.ToString());
                    sb.setLength(0);
                }
                tokens.add((c).ToString());
            } else {
                sb.Append(c);
            }
        }
        if (sb.Length > 0) {
            tokens.add(sb.ToString());
        }
        string[] res = new string[tokens.size()];
        tokens.toArrayType(res);
        return res;
    }

    public static int parsePath(string d, int[] outX, int[] outY, int maxPoints)
    {
        string[] tokens = tokenize(d);
        int[] count = new int[] { 0 };
        FixedPoint fixedPoint = FixedPoint.getInstance();
        int curX = 0;
        int curY = 0;
        int startX = 0;
        int startY = 0;
        int idx = 0;
        while (idx < tokens.Length) {
            string tok = tokens[idx++];
            char cmd = tok[0];
            if (cmd == 'M' || cmd == 'm') {
                int x = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                int y = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                if (cmd == 'm') {
                    x += curX;
                    y += curY;
                }
                curX = x;
                curY = y;
                startX = x;
                startY = y;
                outX[count[0]] = curX;
                outY[count[0]] = curY;
                count[0]++;
            } else if (cmd == 'L' || cmd == 'l') {
                int x = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                int y = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                if (cmd == 'l') {
                    x += curX;
                    y += curY;
                }
                curX = x;
                curY = y;
                outX[count[0]] = curX;
                outY[count[0]] = curY;
                count[0]++;
            } else if (cmd == 'V' || cmd == 'v') {
                int y = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                if (cmd == 'v') {
                    y += curY;
                }
                curY = y;
                outX[count[0]] = curX;
                outY[count[0]] = curY;
                count[0]++;
            } else if (cmd == 'C' || cmd == 'c') {
                int x1 = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                int y1 = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                int x2 = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                int y2 = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                int x3 = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                int y3 = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                if (cmd == 'c') {
                    x1 += curX;
                    y1 += curY;
                    x2 += curX;
                    y2 += curY;
                    x3 += curX;
                    y3 += curY;
                }
                PGUtil.getInstance().flattenCubicBezier(curX, curY, x1, y1, x2, y2, x3, y3, outX, outY, count, maxPoints);
                curX = x3;
                curY = y3;
            } else if (cmd == 'Z' || cmd == 'z') {
                curX = startX;
                curY = startY;
                outX[count[0]] = curX;
                outY[count[0]] = curY;
                count[0]++;
            }
            while (idx < tokens.Length && !isCommand(tokens[idx])) {
                if (cmd == 'M' || cmd == 'm' || cmd == 'L' || cmd == 'l') {
                    int x = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                    int y = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                    if (cmd == 'm' || cmd == 'l') {
                        x += curX;
                        y += curY;
                    }
                    curX = x;
                    curY = y;
                    outX[count[0]] = curX;
                    outY[count[0]] = curY;
                    count[0]++;
                } else if (cmd == 'V' || cmd == 'v') {
                    int y = fixedPoint.toFixed(double.Parse(tokens[idx++]));
                    if (cmd == 'v') {
                        y += curY;
                    }
                    curY = y;
                    outX[count[0]] = curX;
                    outY[count[0]] = curY;
                    count[0]++;
                }
            }
        }
        return count[0];
    }

    private static bool isCommand(string tok)
    {
        char c = tok[0];
        return "MmLlVvCcZz".IndexOf(c) >= 0;
    }

}

