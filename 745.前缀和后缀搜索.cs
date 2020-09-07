/*
 * @lc app=leetcode.cn id=745 lang=csharp
 *
 * [745] 前缀和后缀搜索
 *
 * https://leetcode-cn.com/problems/prefix-and-suffix-search/description/
 *
 * algorithms
 * Hard (32.46%)
 * Likes:    28
 * Dislikes: 0
 * Total Accepted:    1.2K
 * Total Submissions: 3.6K
 * Testcase Example:  '["WordFilter","f"]\n[[["apple"]],["a","e"]]'
 *
 * 给定多个 words，words[i] 的权重为 i 。
 * 
 * 设计一个类 WordFilter 实现函数WordFilter.f(String prefix, String suffix)。这个函数将返回具有前缀
 * prefix 和后缀suffix 的词的最大权重。如果没有这样的词，返回 -1。
 * 
 * 例子:
 * 
 * 
 * 输入:
 * WordFilter(["apple"])
 * WordFilter.f("a", "e") // 返回 0
 * WordFilter.f("b", "") // 返回 -1
 * 
 * 
 * 注意:
 * 
 * 
 * words的长度在[1, 15000]之间。
 * 对于每个测试用例，最多会有words.length次对WordFilter.f的调用。
 * words[i]的长度在[1, 10]之间。
 * prefix, suffix的长度在[0, 10]之前。
 * words[i]和prefix, suffix只包含小写字母。
 * 
 * 
 */

// @lc code=start
public class WordFilter {
    TrieNode trie;
    public WordFilter(string[] words) {
        trie = new TrieNode();
        for(int weight  = 0; weight < words.Length; weight++)
        {
            string word = words[weight] + "{";
            for (int i=0; i<word.Length;i++) {
                TrieNode cur = trie;
                cur.weight = weight;
                for(int j = i; j < 2 * word.Length - 1; j++) {
                    int k = word[j % word.Length] - 'a';
                    cur.children[k] ??= new TrieNode();
                    cur = cur.children[k];
                    cur.weight = weight;
                }
            }
        }
    }
    
    public int F(string prefix, string suffix) {
        TrieNode cur = trie;
        foreach(char letter in (suffix + "{" + prefix))
        {
            if(cur.children[letter - 'a'] == null) return -1;
            cur = cur.children[letter - 'a'];
        }
        return cur.weight;
    }
}
public class TrieNode
    {
        public TrieNode[] children;
        public int weight;
        public TrieNode() 
        {
            children  = new TrieNode[27];
            weight = 0;
        }
    }


/**
 * Your WordFilter object will be instantiated and called as such:
 * WordFilter obj = new WordFilter(words);
 * int param_1 = obj.F(prefix,suffix);
 */
// @lc code=end

