/*
 * @lc app=leetcode.cn id=393 lang=java
 *
 * [393] UTF-8 编码验证
 *
 * https://leetcode-cn.com/problems/utf-8-validation/description/
 *
 * algorithms
 * Medium (38.85%)
 * Likes:    52
 * Dislikes: 0
 * Total Accepted:    7.3K
 * Total Submissions: 18.8K
 * Testcase Example:  '[197,130,1]'
 *
 * UTF-8 中的一个字符可能的长度为 1 到 4 字节，遵循以下的规则：
 * 
 * 
 * 对于 1 字节的字符，字节的第一位设为0，后面7位为这个符号的unicode码。
 * 对于 n 字节的字符 (n > 1)，第一个字节的前 n 位都设为1，第 n+1
 * 位设为0，后面字节的前两位一律设为10。剩下的没有提及的二进制位，全部为这个符号的unicode码。
 * 
 * 
 * 这是 UTF-8 编码的工作方式：
 * 
 * 
 * ⁠  Char. number range  |        UTF-8 octet sequence
 * ⁠     (hexadecimal)    |              (binary)
 * ⁠  --------------------+---------------------------------------------
 * ⁠  0000 0000-0000 007F | 0xxxxxxx
 * ⁠  0000 0080-0000 07FF | 110xxxxx 10xxxxxx
 * ⁠  0000 0800-0000 FFFF | 1110xxxx 10xxxxxx 10xxxxxx
 * ⁠  0001 0000-0010 FFFF | 11110xxx 10xxxxxx 10xxxxxx 10xxxxxx
 * 
 * 
 * 给定一个表示数据的整数数组，返回它是否为有效的 utf-8 编码。
 * 
 * 注意:
 * 输入是整数数组。只有每个整数的最低 8 个有效位用来存储数据。这意味着每个整数只表示 1 字节的数据。
 * 
 * 示例 1:
 * 
 * 
 * data = [197, 130, 1], 表示 8 位的序列: 11000101 10000010 00000001.
 * 
 * 返回 true 。
 * 这是有效的 utf-8 编码，为一个2字节字符，跟着一个1字节字符。
 * 
 * 
 * 示例 2:
 * 
 * 
 * data = [235, 140, 4], 表示 8 位的序列: 11101011 10001100 00000100.
 * 
 * 返回 false 。
 * 前 3 位都是 1 ，第 4 位为 0 表示它是一个3字节字符。
 * 下一个字节是开头为 10 的延续字节，这是正确的。
 * 但第二个延续字节不以 10 开头，所以是不符合规则的。
 * 
 * 
 */

// @lc code=start
class Solution {
    // input types: determined by most significant 1 ~ 5 bits
    static final int TYPE_0 = 0b00000000;
    static final int TYPE_1 = 0b10000000;
    static final int TYPE_2 = 0b11000000;
    static final int TYPE_3 = 0b11100000;
    static final int TYPE_4 = 0b11110000;
    // masks for most significant 1 to 5 bis
    static final int[] MASKS = new int[]{0b10000000, 0b11000000, 0b11100000, 0b11110000, 0b11111000};
    // input type enumation
    static final int[] TYPES = new int[]{TYPE_0, TYPE_1, TYPE_2, TYPE_3, TYPE_4};
    // map of cur_stat : (input_type : next_stat)
    static final Map<Integer, Map<Integer, Integer>> DFA = new HashMap<>();
    // build the dfa
    static {
        DFA.put(0, Map.of(TYPE_0, 0, TYPE_2, 1, TYPE_3, 2, TYPE_4, 3));
        DFA.put(1, Map.of(TYPE_1, 0));
        DFA.put(2, Map.of(TYPE_1, 4));
        DFA.put(4, Map.of(TYPE_1, 0));
        DFA.put(3, Map.of(TYPE_1, 5));
        DFA.put(5, Map.of(TYPE_1, 6));
        DFA.put(6, Map.of(TYPE_1, 0));
    }
    
    public boolean validUtf8(int[] data) {
        int cur = 0;
        for (int input : data) {
            Integer next = getNext(cur, input);
            if (next == null) {
                return false;
            }
            cur = next;
        }
        return cur == 0;
    }

    private static int getType(int in) {
        for (int i = 0; i < TYPES.length; i++) {
            if ((MASKS[i] & in) == TYPES[i]) {
                return TYPES[i];
            }
        }
        // unreachable. unless input is "11111xxx" which is not a valid utf-8 character.
        return -1;
    }
    
    private static Integer getNext(int cur, int input) {
        int type = getType(input);
        if (type == -1) return null;
        return DFA.get(cur).get(type);
    }
}

// @lc code=end

