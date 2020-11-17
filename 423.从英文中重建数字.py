#
# @lc app=leetcode.cn id=423 lang=python3
#
# [423] 从英文中重建数字
#
# https://leetcode-cn.com/problems/reconstruct-original-digits-from-english/description/
#
# algorithms
# Medium (54.48%)
# Likes:    53
# Dislikes: 0
# Total Accepted:    5.4K
# Total Submissions: 9.9K
# Testcase Example:  '"owoztneoer"'
#
# 给定一个非空字符串，其中包含字母顺序打乱的英文单词表示的数字0-9。按升序输出原始的数字。
# 
# 注意:
# 
# 
# 输入只包含小写英文字母。
# 输入保证合法并可以转换为原始的数字，这意味着像 "abc" 或 "zerone" 的输入是不允许的。
# 输入字符串的长度小于 50,000。
# 
# 
# 示例 1:
# 
# 
# 输入: "owoztneoer"
# 
# 输出: "012" (zeroonetwo)
# 
# 
# 示例 2:
# 
# 
# 输入: "fviefuro"
# 
# 输出: "45" (fourfive)
# 
# 
#

# @lc code=start
class Solution:
    def originalDigits(self, s: 'str') -> 'str':
        # building hashmap letter -> its frequency
        count = collections.Counter(s)
        
        # building hashmap digit -> its frequency 
        out = {}
        # letter "z" is present only in "zero"
        out["0"] = count["z"]
        # letter "w" is present only in "two"
        out["2"] = count["w"]
        # letter "u" is present only in "four"
        out["4"] = count["u"]
        # letter "x" is present only in "six"
        out["6"] = count["x"]
        # letter "g" is present only in "eight"
        out["8"] = count["g"]
        # letter "h" is present only in "three" and "eight"
        out["3"] = count["h"] - out["8"]
        # letter "f" is present only in "five" and "four"
        out["5"] = count["f"] - out["4"]
        # letter "s" is present only in "seven" and "six"
        out["7"] = count["s"] - out["6"]
        # letter "i" is present in "nine", "five", "six", and "eight"
        out["9"] = count["i"] - out["5"] - out["6"] - out["8"]
        # letter "n" is present in "one", "nine", and "seven"
        out["1"] = count["n"] - out["7"] - 2 * out["9"]

        # building output string
        output = [key * out[key] for key in sorted(out.keys())]
        return "".join(output)

        
# @lc code=end

