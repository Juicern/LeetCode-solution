/*
 * @lc app=leetcode.cn id=1106 lang=csharp
 *
 * [1106] 解析布尔表达式
 *
 * https://leetcode-cn.com/problems/parsing-a-boolean-expression/description/
 *
 * algorithms
 * Hard (55.48%)
 * Likes:    42
 * Dislikes: 0
 * Total Accepted:    2.8K
 * Total Submissions: 5.1K
 * Testcase Example:  '"!(f)"'
 *
 * 给你一个以字符串形式表述的 布尔表达式（boolean） expression，返回该式的运算结果。
 * 
 * 有效的表达式需遵循以下约定：
 * 
 * 
 * "t"，运算结果为 True
 * "f"，运算结果为 False
 * "!(expr)"，运算过程为对内部表达式 expr 进行逻辑 非的运算（NOT）
 * "&(expr1,expr2,...)"，运算过程为对 2 个或以上内部表达式 expr1, expr2, ... 进行逻辑 与的运算（AND）
 * "|(expr1,expr2,...)"，运算过程为对 2 个或以上内部表达式 expr1, expr2, ... 进行逻辑 或的运算（OR）
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：expression = "!(f)"
 * 输出：true
 * 
 * 
 * 示例 2：
 * 
 * 输入：expression = "|(f,t)"
 * 输出：true
 * 
 * 
 * 示例 3：
 * 
 * 输入：expression = "&(t,f)"
 * 输出：false
 * 
 * 
 * 示例 4：
 * 
 * 输入：expression = "|(&(t,f,t),!(t))"
 * 输出：false
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= expression.length <= 20000
 * expression[i] 由 {'(', ')', '&', '|', '!', 't', 'f', ','} 中的字符组成。
 * expression 是以上述形式给出的有效表达式，表示一个布尔值。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public bool ParseBoolExpr(string expression) {
        if(FindSingleExpr(expression) == "t")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
     string FindSingleExpr(string expression)
        {
            int startIndex = 0;
            string singleExpression = "";
            for (int i=0;i< expression.Length;i++)
            {
                if(expression[i]== '&' || expression[i] == '|' || expression[i] == '!')
                {
                    startIndex = i;
                }
                if(expression[i] == ')')
                {
                    singleExpression = expression.Substring(startIndex, i - startIndex + 1);
                    string result = GetExpr(singleExpression);
                    return FindSingleExpr(expression.Replace(singleExpression, result));
                }
            }
            return expression;
        }

         string GetExpr(string singleExpression)
        {
            switch(singleExpression[0])
            {
                case '&':
                    return And(singleExpression);
                case '|':
                    return Or(singleExpression);
                case '!':
                    return Not(singleExpression);
                default:
                    return singleExpression;
            }
        }

         string Or(string expression)
        {
            if(expression.IndexOf('t')>0)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

         string And(string expression)
        {
            if (expression.IndexOf('f') > 0)
            {
                return "f";
            }
            else
            {
                return "t";
            }
        }

         string Not(string expression)
        {
            if (expression.IndexOf('f') > 0)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }
}

// @lc code=end

