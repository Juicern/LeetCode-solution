/*
 * @lc app=leetcode.cn id=399 lang=csharp
 *
 * [399] 除法求值
 *
 * https://leetcode-cn.com/problems/evaluate-division/description/
 *
 * algorithms
 * Medium (55.02%)
 * Likes:    239
 * Dislikes: 0
 * Total Accepted:    12.5K
 * Total Submissions: 22.8K
 * Testcase Example:  '[["a","b"],["b","c"]]\n' +
  '[2.0,3.0]\n' +
  '[["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]'
 *
 * 给出方程式 A / B = k, 其中 A 和 B 均为用字符串表示的变量， k
 * 是一个浮点型数字。根据已知方程式求解问题，并返回计算结果。如果结果不存在，则返回 -1.0。
 * 
 * 输入总是有效的。你可以假设除法运算中不会出现除数为 0 的情况，且不存在任何矛盾的结果。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：equations = [["a","b"],["b","c"]], values = [2.0,3.0], queries =
 * [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
 * 输出：[6.00000,0.50000,-1.00000,1.00000,-1.00000]
 * 解释：
 * 给定：a / b = 2.0, b / c = 3.0
 * 问题：a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ?
 * 返回：[6.0, 0.5, -1.0, 1.0, -1.0 ]
 * 
 * 
 * 示例 2：
 * 
 * 输入：equations = [["a","b"],["b","c"],["bc","cd"]], values = [1.5,2.5,5.0],
 * queries = [["a","c"],["c","b"],["bc","cd"],["cd","bc"]]
 * 输出：[3.75000,0.40000,5.00000,0.20000]
 * 
 * 
 * 示例 3：
 * 
 * 输入：equations = [["a","b"]], values = [0.5], queries =
 * [["a","b"],["b","a"],["a","c"],["x","y"]]
 * 输出：[0.50000,2.00000,-1.00000,-1.00000]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= equations.length <= 20
 * equations[i].length == 2
 * 1 <= equations[i][0].length, equations[i][1].length <= 5
 * values.length == equations.length
 * 0.0 < values[i] <= 20.0
 * 1 <= queries.length <= 20
 * queries[i].length == 2
 * 1 <= queries[i][0].length, queries[i][1].length <= 5
 * equations[i][0], equations[i][1], queries[i][0], queries[i][1] 由小写英文字母与数字组成
 * 
 * 
 */

// @lc code=start
public class Solution {
    private class UnionFind{
        // 存储父结点
        private int[] parent;
        // 权重 x / rootX
        private double[] weight;

        public UnionFind(int len){
            parent = new int[len];
            weight = new double[len];
            for (int i = 0; i < len; i++) {
                parent[i] = i;
                weight[i] = 1.0d;
            }
        }

        public int Find(int x){
            if (x != parent[x]) {
                // 压缩前

                //       c    weight[c] = c / c       
                //      b    weight[b] = b / c
                //     a   weight[a] = a / b 

                // 压缩后
                //     c    weight[c] = c / c   
                //    b a   weight[b] = b / c      
                //   weight[a] = weight[a] * weight[b] = a / c

                // 这里一定要用递归！！切记！！！
                // 因为需要从上往下 将子节点挂接 到 根结点
                // 这里与非带权并查集不同 需要借助距离根结点最近点运算得到当前点对应的权重
                int origin = parent[x];
                parent[x] = Find(parent[x]);
                weight[x] *= weight[origin];
            }
            return parent[x];
        }

        // 将分母作为父节点
        public void Union(int x, int y, double value){ 
            // weight[rootX] = rootX / rootY

            // 上述表达式由下边的式子求得
            // weight[y] = y / rootY
            // weight[x] = x / rootX
            // value = x / y
            int rootX = Find(x);
            int rootY = Find(y);
            parent[rootX] = rootY;
            weight[rootX] = weight[y] * value / weight[x];
        }
    
        public double IsConnected(int x, int y){
            int rootX = Find(x);
            int rootY = Find(y);
            // 同根结点做中介数值
            if (rootX == rootY) return weight[x] / weight[y];
            else return -1.0d;
        }
    
    }

    public double[] CalcEquation(IList<IList<string>> e, double[] v, IList<IList<string>> q) {
        int id = 0;
        Dictionary<string, int> dic = new Dictionary<string, int>();
        UnionFind unionFind = new UnionFind(e.Count * 2);
        double[] ans = new double[q.Count];

        for (int i = 0; i < e.Count; i++) {
            string a = e[i][0], b = e[i][1];
            if (!dic.ContainsKey(a)) dic.Add(a, id++);
            if (!dic.ContainsKey(b)) dic.Add(b, id++);
            int x = dic[a], y = dic[b];
            unionFind.Union(x, y, v[i]);
        }

        for (int i = 0; i < q.Count; i++) {
            string a = q[i][0], b = q[i][1];
            if (!dic.ContainsKey(a) || !dic.ContainsKey(b)){
                ans[i] = -1.0d;
            } else {
                int x = dic[a], y = dic[b];
                ans[i] = unionFind.IsConnected(x, y);
            }
        }
        return ans;
    }
}
// @lc code=end

