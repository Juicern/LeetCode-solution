/*
 * @lc app=leetcode.cn id=834 lang=javascript
 *
 * [834] 树中距离之和
 *
 * https://leetcode-cn.com/problems/sum-of-distances-in-tree/description/
 *
 * algorithms
 * Hard (34.31%)
 * Likes:    182
 * Dislikes: 0
 * Total Accepted:    7.3K
 * Total Submissions: 14.6K
 * Testcase Example:  '6\n[[0,1],[0,2],[2,3],[2,4],[2,5]]'
 *
 * 给定一个无向、连通的树。树中有 N 个标记为 0...N-1 的节点以及 N-1 条边 。
 * 
 * 第 i 条边连接节点 edges[i][0] 和 edges[i][1] 。
 * 
 * 返回一个表示节点 i 与其他所有节点距离之和的列表 ans。
 * 
 * 示例 1:
 * 
 * 
 * 输入: N = 6, edges = [[0,1],[0,2],[2,3],[2,4],[2,5]]
 * 输出: [8,12,6,10,10,10]
 * 解释: 
 * 如下为给定的树的示意图：
 * ⁠ 0
 * ⁠/ \
 * 1   2
 * ⁠  /|\
 * ⁠ 3 4 5
 * 
 * 我们可以计算出 dist(0,1) + dist(0,2) + dist(0,3) + dist(0,4) + dist(0,5) 
 * 也就是 1 + 1 + 2 + 2 + 2 = 8。 因此，answer[0] = 8，以此类推。
 * 
 * 
 * 说明: 1 <= N <= 10000
 * 
 */

// @lc code=start
/**
 * @param {number} N
 * @param {number[][]} edges
 * @return {number[]}
 */
const sumOfDistancesInTree = (N, edges) => {
    // 建立映射表，graph[i]：存放与节点i相连的所有节点
    const graph = new Array(N);
    for (let i = 0; i < graph.length; i++) {
        graph[i] = [];
    }
    for (const edge of edges) {
        const [from, to] = edge;
        graph[from].push(to);
        graph[to].push(from);
    }

    // distSum[i]：节点i到它所在子树的节点的距离和，后面更新为：节点i到其他所有节点的距离和
    const distSum = new Array(N).fill(0);
    // nodeNum[i]：节点i所在子树的节点个数，保底为1
    const nodeNum = new Array(N).fill(1);

    const postOrder = (root, parent) => {
        const neighbors = graph[root]; // 与它相连的节点们
        for (const neighbor of neighbors) {
            if (neighbor == parent) {    // 如果邻居是自己父亲，跳过。
                continue;                  // 如果邻居只有自己父亲，则for循环结束，当前递归结束  
            }
            postOrder(neighbor, root);
            nodeNum[root] += nodeNum[neighbor];
            distSum[root] += nodeNum[neighbor] + distSum[neighbor];
        }
    };

    const preOrder = (root, parent) => {
        const neighbors = graph[root];
        for (const neighbor of neighbors) {
            if (neighbor == parent) {
                continue;
            }
            distSum[neighbor] = distSum[root] - nodeNum[neighbor] + (N - nodeNum[neighbor]);
            preOrder(neighbor, root);
        }
    };

    postOrder(0, -1); // dfs的入口。因为N>=1，节点0肯定存在，就从节点0开始搜
    preOrder(0, -1);
    console.log(distSum);
    return distSum;
};
// @lc code=end

