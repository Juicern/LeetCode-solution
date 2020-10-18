#
# @lc app=leetcode.cn id=928 lang=python3
#
# [928] 尽量减少恶意软件的传播 II
#
# https://leetcode-cn.com/problems/minimize-malware-spread-ii/description/
#
# algorithms
# Hard (40.59%)
# Likes:    27
# Dislikes: 0
# Total Accepted:    1.4K
# Total Submissions: 3.4K
# Testcase Example:  '[[1,1,0],[1,1,0],[0,0,1]]\n[0,1]'
#
# (这个问题与 尽量减少恶意软件的传播 是一样的，不同之处用粗体表示。)
# 
# 在节点网络中，只有当 graph[i][j] = 1 时，每个节点 i 能够直接连接到另一个节点 j。
# 
# 一些节点 initial
# 最初被恶意软件感染。只要两个节点直接连接，且其中至少一个节点受到恶意软件的感染，那么两个节点都将被恶意软件感染。这种恶意软件的传播将继续，直到没有更多的节点可以被这种方式感染。
# 
# 假设 M(initial) 是在恶意软件停止传播之后，整个网络中感染恶意软件的最终节点数。
# 
# 我们可以从初始列表中删除一个节点，并完全移除该节点以及从该节点到任何其他节点的任何连接。如果移除这一节点将最小化 M(initial)，
# 则返回该节点。如果有多个节点满足条件，就返回索引最小的节点。
# 
# 
# 
# 
# 
# 
# 示例 1：
# 
# 输出：graph = [[1,1,0],[1,1,0],[0,0,1]], initial = [0,1]
# 输入：0
# 
# 
# 示例 2：
# 
# 输入：graph = [[1,1,0],[1,1,1],[0,1,1]], initial = [0,1]
# 输出：1
# 
# 
# 示例 3：
# 
# 输入：graph = [[1,1,0,0],[1,1,1,0],[0,1,1,1],[0,0,1,1]], initial = [0,1]
# 输出：1
# 
# 
# 
# 
# 提示：
# 
# 
# 1 < graph.length = graph[0].length <= 300
# 0 <= graph[i][j] == graph[j][i] <= 1
# graph[i][i] = 1
# 1 <= initial.length < graph.length
# 0 <= initial[i] < graph.length
# 
# 
class Solution:
    def minMalwareSpread(self, graph: List[List[int]], initial: List[int]) -> int:
        n = len(graph)
        p = list(range(n))

        def get_root(x: int) -> int:
            if p[x] != p[p[x]]:
                p[x] = get_root(p[x])
            return p[x]

        initial = set(initial)
        not_infected = [i for i in p if i not in initial]

        for r in not_infected:
            for c in not_infected:
                if graph[r][c]:
                    r_root = get_root(r)
                    c_root = get_root(c)
                    if r_root > c_root:  # 大索引 并往 小索引
                        p[r_root] = c_root
                    else:
                        p[c_root] = r_root

        d = collections.defaultdict(set)  # 用set,之前用list 没考虑 1个感染点 连到 同一连通块的多个点,导致重复了.
        for i in initial:
            for j in not_infected:
                if graph[i][j]:  # 能到达该 无感染集合
                    j_root = get_root(j)
                    d[j_root].add(i)  # 用无感染集合的根索引 表示字典键

        if not d:  # 如果都不能到达,则删除initial里的最小索引
            return min(initial)

        res = []
        for k, v in d.items():
            if len(v) == 1:  # 只有一个且只能是一个
                res.append([v.pop(), p.count(k)])  # [索引, 个数]

        res.sort(key=lambda x: [-x[1], x[0]])
        
        return res and res[0][0] or min(initial)  # 如果没有只有1个感染点的集合,则返回最小的.
# @lc code=end

