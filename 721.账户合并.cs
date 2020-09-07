using System.Security.Cryptography;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=721 lang=csharp
 *
 * [721] 账户合并
 *
 * https://leetcode-cn.com/problems/accounts-merge/description/
 *
 * algorithms
 * Medium (34.59%)
 * Likes:    97
 * Dislikes: 0
 * Total Accepted:    4.7K
 * Total Submissions: 13.5K
 * Testcase Example:  '[["John","johnsmith@mail.com","john_newyork@mail.com"],["John","johnsmith@mail.com","john00@mail.com"],["Mary","mary@mail.com"],["John","johnnybravo@mail.com"]]'
 *
 * 给定一个列表 accounts，每个元素 accounts[i] 是一个字符串列表，其中第一个元素 accounts[i][0] 是 名称
 * (name)，其余元素是 emails 表示该帐户的邮箱地址。
 * 
 * 
 * 现在，我们想合并这些帐户。如果两个帐户都有一些共同的邮件地址，则两个帐户必定属于同一个人。请注意，即使两个帐户具有相同的名称，它们也可能属于不同的人，因为人们可能具有相同的名称。一个人最初可以拥有任意数量的帐户，但其所有帐户都具有相同的名称。
 * 
 * 合并帐户后，按以下格式返回帐户：每个帐户的第一个元素是名称，其余元素是按顺序排列的邮箱地址。accounts 本身可以以任意顺序返回。
 * 
 * 例子 1:
 * 
 * 
 * Input: 
 * accounts = [["John", "johnsmith@mail.com", "john00@mail.com"], ["John",
 * "johnnybravo@mail.com"], ["John", "johnsmith@mail.com",
 * "john_newyork@mail.com"], ["Mary", "mary@mail.com"]]
 * Output: [["John", 'john00@mail.com', 'john_newyork@mail.com',
 * 'johnsmith@mail.com'],  ["John", "johnnybravo@mail.com"], ["Mary",
 * "mary@mail.com"]]
 * Explanation: 
 * ⁠ 第一个和第三个 John 是同一个人，因为他们有共同的电子邮件 "johnsmith@mail.com"。 
 * ⁠ 第二个 John 和 Mary 是不同的人，因为他们的电子邮件地址没有被其他帐户使用。
 * ⁠
 * 我们可以以任何顺序返回这些列表，例如答案[['Mary'，'mary@mail.com']，['John'，'johnnybravo@mail.com']，
 * ⁠
 * ['John'，'john00@mail.com'，'john_newyork@mail.com'，'johnsmith@mail.com']]仍然会被接受。
 * 
 * 
 * 
 * 注意：
 * 
 * 
 * accounts的长度将在[1，1000]的范围内。
 * accounts[i]的长度将在[1，10]的范围内。
 * accounts[i][j]的长度将在[1，30]的范围内。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        var unionFind = new UnionFind(10001);
        var emailToName = new Dictionary<string, string>();
        var emailToId = new Dictionary<string, int>();
        int id = 0;
        foreach(var account in accounts) {
            string name = "";
            foreach(var email in account) {
                if(name == "") {
                    name  = email;
                    continue;
                }
                if(!emailToName.ContainsKey(email)) emailToName.Add(email, name);
                else emailToName[email] = name;
                if(!emailToId.ContainsKey(email)) {
                    emailToId.Add(email, id++);
                }
                unionFind.Union(emailToId[account[1]], emailToId[email]);
            }
        } 
        var ans = new Dictionary<int, List<string>>();
        foreach(var email in emailToName.Keys) {
            int index = unionFind.Find(emailToId[email]);
            if(!ans.ContainsKey(index)) ans.Add(index, new List<string>());
            ans[index].Add(email);
        } 
        foreach(var component in ans.Values) {
            component.Sort(string.CompareOrdinal);
            component.Insert(0, emailToName[component[0]]);
        }
        return new List<IList<string>>(ans.Values);
    }
    /// <summary>
    /// 并查集
    /// </summary>
    internal class UnionFind {
        private int[] parent;
        private int[] rank;
        public UnionFind(int n) {
            parent = new int[n];
            rank = new int[n];
            for(int i = 0;i<n;i++) {
                parent[i] = i;
                rank[i] = 1;
            }
        }
        public int Find(int x) {
            if(parent[x] == x) return x;
            return parent[x] = Find(parent[x]);
        }
        public void Union(int x, int y) {
            int rootY = Find(y);
            int rootX = Find(x);
            if(rootX == rootY) return;
            if(rank[rootX] > rank[rootY]) {
                parent[rootX] = rootY;
                rank[rootY] += rank[rootX];
            }
            else {
                parent[rootY] = rootX;
                rank[rootX] += rank[rootY]; 
            }
        }
    }
}
// @lc code=end

