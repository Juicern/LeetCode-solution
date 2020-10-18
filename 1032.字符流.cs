/*
 * @lc app=leetcode.cn id=1032 lang=csharp
 *
 * [1032] 字符流
 *
 * https://leetcode-cn.com/problems/stream-of-characters/description/
 *
 * algorithms
 * Hard (36.01%)
 * Likes:    42
 * Dislikes: 0
 * Total Accepted:    1.6K
 * Total Submissions: 4.4K
 * Testcase Example:  '["StreamChecker","query","query","query","query","query","query","query","query","query","query","query","query"]\n' +
  '[[["cd","f","kl"]],["a"],["b"],["c"],["d"],["e"],["f"],["g"],["h"],["i"],["j"],["k"],["l"]]'
 *
 * 按下述要求实现 StreamChecker 类：
 * 
 * 
 * StreamChecker(words)：构造函数，用给定的字词初始化数据结构。
 * query(letter)：如果存在某些 k >= 1，可以用查询的最后
 * k个字符（按从旧到新顺序，包括刚刚查询的字母）拼写出给定字词表中的某一字词时，返回 true。否则，返回 false。
 * 
 * 
 * 
 * 
 * 示例：
 * 
 * StreamChecker streamChecker = new StreamChecker(["cd","f","kl"]); // 初始化字典
 * streamChecker.query('a');          // 返回 false
 * streamChecker.query('b');          // 返回 false
 * streamChecker.query('c');          // 返回 false
 * streamChecker.query('d');          // 返回 true，因为 'cd' 在字词表中
 * streamChecker.query('e');          // 返回 false
 * streamChecker.query('f');          // 返回 true，因为 'f' 在字词表中
 * streamChecker.query('g');          // 返回 false
 * streamChecker.query('h');          // 返回 false
 * streamChecker.query('i');          // 返回 false
 * streamChecker.query('j');          // 返回 false
 * streamChecker.query('k');          // 返回 false
 * streamChecker.query('l');          // 返回 true，因为 'kl' 在字词表中。
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= words.length <= 2000
 * 1 <= words[i].length <= 2000
 * 字词只包含小写英文字母。
 * 待查项只包含小写英文字母。
 * 待查项最多 40000 个。
 * 
 * 
 */

// @lc code=start
public class StreamChecker {
    
    public class TrieNode
    {
        public TrieNode[] Children;
        public bool IsWord;
        public TrieNode()
        {
            Children = new TrieNode[26];
            IsWord = false;
        }
    }

    public TrieNode root = new TrieNode();
    List<char> list = new List<char>();
    
    public StreamChecker(string[] words) {
            
        foreach(string word in words)
        {
            TrieNode curr = root;
            for(int i = word.Length - 1; i >= 0; i--)
            {
                int idx = word[i] - 'a'; 
                
                if(curr.Children[idx] == null)
                    curr.Children[idx] = new TrieNode();  
                
                curr = curr.Children[idx];
            }
            
            curr.IsWord = true;
        }
    }
    
    public bool Query(char letter) {
        
        list.Add(letter);
        TrieNode curr = root;
        
        for(int i = list.Count - 1; i >= 0; i--)
        {
            int idx = list[i] - 'a';
            
            if(curr.Children[idx] == null)
                return false;
           
            if(curr.Children[idx].IsWord)
                return true;
            
            curr = curr.Children[idx];
        }
        
        return false;
    }
}

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * bool param_1 = obj.Query(letter);
 */
// @lc code=end

