#
# @lc app=leetcode.cn id=770 lang=python3
#
# [770] 基本计算器 IV
#
# https://leetcode-cn.com/problems/basic-calculator-iv/description/
#
# algorithms
# Hard (51.83%)
# Likes:    25
# Dislikes: 0
# Total Accepted:    469
# Total Submissions: 907
# Testcase Example:  '"e + 8 - a + 5"\n["e"]\n[1]'
#
# 给定一个表达式 expression 如 expression = "e + 8 - a + 5" 和一个求值映射，如 {"e": 1}（给定的形式为
# evalvars = ["e"] 和 evalints = [1]），返回表示简化表达式的标记列表，例如 ["-1*a","14"]
# 
# 
# 表达式交替使用块和符号，每个块和符号之间有一个空格。
# 块要么是括号中的表达式，要么是变量，要么是非负整数。
# 块是括号中的表达式，变量或非负整数。
# 变量是一个由小写字母组成的字符串（不包括数字）。请注意，变量可以是多个字母，并注意变量从不具有像 "2x" 或 "-x" 这样的前导系数或一元运算符
# 。
# 
# 
# 表达式按通常顺序进行求值：先是括号，然后求乘法，再计算加法和减法。例如，expression = "1 + 2 * 3" 的答案是 ["7"]。
# 
# 输出格式如下：
# 
# 
# 对于系数非零的每个自变量项，我们按字典排序的顺序将自变量写在一个项中。例如，我们永远不会写像 “b*a*c” 这样的项，只写 “a*b*c”。
# 项的次数等于被乘的自变量的数目，并计算重复项。(例如，"a*a*b*c" 的次数为
# 4。)。我们先写出答案的最大次数项，用字典顺序打破关系，此时忽略词的前导系数。
# 项的前导系数直接放在左边，用星号将它与变量分隔开(如果存在的话)。前导系数 1 仍然要打印出来。
# 格式良好的一个示例答案是 ["-2*a*a*a", "3*a*a*b", "3*b*b", "4*a", "5*c", "-6"] 。
# 系数为 0 的项（包括常数项）不包括在内。例如，“0” 的表达式输出为 []。
# 
# 
# 
# 
# 示例：
# 
# 输入：expression = "e + 8 - a + 5", evalvars = ["e"], evalints = [1]
# 输出：["-1*a","14"]
# 
# 输入：expression = "e - 8 + temperature - pressure",
# evalvars = ["e", "temperature"], evalints = [1, 12]
# 输出：["-1*pressure","5"]
# 
# 输入：expression = "(e + 8) * (e - 8)", evalvars = [], evalints = []
# 输出：["1*e*e","-64"]
# 
# 输入：expression = "7 - 7", evalvars = [], evalints = []
# 输出：[]
# 
# 输入：expression = "a * b * c + b * a * c * 4", evalvars = [], evalints = []
# 输出：["5*a*b*c"]
# 
# 输入：expression = "((a - b) * (b - c) + (c - a)) * ((a - b) + (b - c) * (c -
# a))",
# evalvars = [], evalints = []
# 
# 输出：["-1*a*a*b*b","2*a*a*b*c","-1*a*a*c*c","1*a*b*b*b","-1*a*b*b*c","-1*a*b*c*c","1*a*c*c*c","-1*b*b*b*c","2*b*b*c*c","-1*b*c*c*c","2*a*a*b","-2*a*a*c","-2*a*b*b","2*a*c*c","1*b*b*b","-1*b*b*c","1*b*c*c","-1*c*c*c","-1*a*a","1*a*b","1*a*c","-1*b*c"]
# 
# 
# 
# 
# 提示：
# 
# 
# expression 的长度在 [1, 250] 范围内。
# evalvars, evalints 在范围 [0, 100] 内，且长度相同。
# 
# 
#

# @lc code=start
import re
from collections import namedtuple
left = r'(?P<LEFT>\()'
right = r'(?P<RIGHT>\))'
var = r'(?P<VAR>[a-z]+)'
num = r'(?P<NUM>\d+)'
add = r'(?P<ADD>\+)'
sub = r'(?P<SUB>\-)'
mul = r'(?P<MUL>\*)'
ws = r'(?P<WS> +)'
pt = re.compile('|'.join([left, right, var, ws, num, add, sub, mul]))

token = namedtuple('token', ['type', 'value'])


def genToken(s):
    scanner = pt.scanner(s)
    for i in iter(scanner.match, None):
        if i.lastgroup != 'WS':
            yield token(i.lastgroup, i.group(0))


class parser(object):
    '''grammar
        expr -> expr {'+'|'-'} term | term
        term -> term '*' item | item
        item -> num | var | '(' expr ')'
    '''

    def __init__(self, s, vars):
        self.token = [i for i in genToken(s)]
        self.lookahead = 0
        self.var = vars

    def parse(self):
        dic = self.term()
        # terminate symbol
        while self.lookahead < len(self.token) and not self.isType('RIGHT'):
            assert self.isType('SUB', 'ADD')
            sign = 1 if self.match() == '+' else -1
            var = self.term()
            for i in var:
                if i in dic:
                    dic[i] += var[i]*sign
                else:
                    dic[i] = var[i]*sign
        return dic

    def match(self, curType=None):
        sym = self.token[self.lookahead]
        # print(sym,curType)
        if curType is None or sym.type == curType:
            self.lookahead += 1
            return sym.value
        raise Exception('Invalid input string')

    def isType(self, *s):
        sym = self.token[self.lookahead]
        return any(sym.type == i for i in s)

    def term(self):
        li = []
        dic = self.item()
        while self.lookahead < len(self.token) and self.isType('MUL'):
            self.match()
            li.append(self.item())
        for d2 in li:
            newDic = {}
            for v1 in dic:
                for v2 in d2:
                    s = ''
                    if v1 == '':
                        s = v2
                    elif v2 == '':
                        s = v1
                    else:
                        s = '*'.join(sorted(v1.split('*')+v2.split('*')))
                    if s in newDic:
                        newDic[s] += dic[v1]*d2[v2]
                    else:
                        newDic[s] = dic[v1]*d2[v2]
            dic = newDic
        return dic

    def item(self):
        if self.isType('NUM'):
            return {'': int(self.match())}
        elif self.isType('VAR'):
            name = self.match()
            if name in self.var:
                return {'': self.var[name]}
            else:
                return {name: 1}
        elif self.isType('LEFT'):
            self.match()
            dic = self.parse()
            self.match('RIGHT')
            return dic
        else:
            print(self.token[self.lookahead])
            raise Exception('invalid string')


class Solution:
    def basicCalculatorIV(self, expression, evalvars, evalints):
        """
        :type expression: str
        :type evalvars: List[str]
        :type evalints: List[int]
        :rtype: List[str]
        """
        self.var = dict(zip(evalvars, evalints))
        dic = parser(expression, self.var).parse()
        n = dic.pop('') if '' in dic else 0
        ret = []
        li = sorted(dic, key=lambda s: (-s.count('*'), s))
        for i in li:
            if dic[i] != 0:
                s = str(dic[i])
                ret.append(s + ('*'+i) if i else s)
        if n != 0:
            ret.append(str(n))
        return ret


if __name__ == '__main__':
    sol = Solution()
    exprs = [
        "((a - b) * (b - c) + (c - a)) * ((a - b) + (b - c) * (c - a))", "e + 8 - a + 5"]
    names = [[], ["e"]]
    vars = [[], [1]]
    for i, j, k in zip(exprs, names, vars):
        print('>>>', i, j, k)
        print(sol.basicCalculatorIV(i, j, k))

# @lc code=end

