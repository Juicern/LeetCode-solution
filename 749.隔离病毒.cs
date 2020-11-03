/*
 * @lc app=leetcode.cn id=749 lang=csharp
 *
 * [749] 隔离病毒
 *
 * https://leetcode-cn.com/problems/contain-virus/description/
 *
 * algorithms
 * Hard (47.10%)
 * Likes:    28
 * Dislikes: 0
 * Total Accepted:    739
 * Total Submissions: 1.6K
 * Testcase Example:  '[[0,1,0,0,0,0,0,1],[0,1,0,0,0,0,0,1],[0,0,0,0,0,0,0,1],[0,0,0,0,0,0,0,0]]'
 *
 * 病毒扩散得很快，现在你的任务是尽可能地通过安装防火墙来隔离病毒。
 * 
 * 假设世界由二维矩阵组成，0 表示该区域未感染病毒，而 1 表示该区域已感染病毒。可以在任意 2
 * 个四方向相邻单元之间的共享边界上安装一个防火墙（并且只有一个防火墙）。
 * 
 * 
 * 每天晚上，病毒会从被感染区域向相邻未感染区域扩散，除非被防火墙隔离。现由于资源有限，每天你只能安装一系列防火墙来隔离其中一个被病毒感染的区域（一个区域或连续的一片区域），且该感染区域对未感染区域的威胁最大且保证唯一。
 * 
 * 你需要努力使得最后有部分区域不被病毒感染，如果可以成功，那么返回需要使用的防火墙个数;
 * 如果无法实现，则返回在世界被病毒全部感染时已安装的防火墙个数。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入: grid = 
 * [[0,1,0,0,0,0,0,1],
 * ⁠[0,1,0,0,0,0,0,1],
 * ⁠[0,0,0,0,0,0,0,1],
 * ⁠[0,0,0,0,0,0,0,0]]
 * 输出: 10
 * 说明:
 * 一共有两块被病毒感染的区域: 从左往右第一块需要 5 个防火墙，同时若该区域不隔离，晚上将感染 5 个未感染区域（即被威胁的未感染区域个数为 5）;
 * 第二块需要 4 个防火墙，同理被威胁的未感染区域个数是 4。因此，第一天先隔离左边的感染区域，经过一晚后，病毒传播后世界如下:
 * [[0,1,0,0,0,0,1,1],
 * ⁠[0,1,0,0,0,0,1,1],
 * ⁠[0,0,0,0,0,0,1,1],
 * ⁠[0,0,0,0,0,0,0,1]]
 * 第二题，只剩下一块未隔离的被感染的连续区域，此时需要安装 5 个防火墙，且安装完毕后病毒隔离任务完成。
 * 
 * 
 * 示例 2：
 * 
 * 输入: grid = 
 * [[1,1,1],
 * ⁠[1,0,1],
 * ⁠[1,1,1]]
 * 输出: 4
 * 说明: 
 * 此时只需要安装 4 面防火墙，就有一小区域可以幸存，不被病毒感染。
 * 注意不需要在世界边界建立防火墙。
 * 
 * 
 * 
 * 示例 3:
 * 
 * 输入: grid = 
 * [[1,1,1,0,0,0,0,0,0],
 * ⁠[1,0,1,0,1,1,1,1,1],
 * ⁠[1,1,1,0,0,0,0,0,0]]
 * 输出: 13
 * 说明: 
 * 在隔离右边感染区域后，隔离左边病毒区域只需要 2 个防火墙了。
 * 
 * 
 * 
 * 
 * 说明:
 * 
 * 
 * grid 的行数和列数范围是 [1, 50]。
 * grid[i][j] 只包含 0 或 1 。
 * 题目保证每次选取感染区域进行隔离时，一定存在唯一一个对未感染区域的威胁最大的区域。
 * 
 * 
 * 
 * 
 */

// @lc code=start

using VT = System.ValueTuple<int, int>;
class Region
{
    public Dictionary<VT, int> boundEdge = new Dictionary<VT, int>();//必然是0
    public Region parent = null;
    public bool safe = false;
    public bool enLargetYet = false;
    public VT seed;
    public Region GetTop()
    {
        if (parent == null) return this;
        var p = parent;
        while (p.parent != null)
        {
            p = p.parent;
        }
        parent = p;
        return p;
    }
}
class Virtus
{
    private Dictionary<VT, Region> cellToRegion = new Dictionary<VT, Region>();
    private int[][] G;
    private List<Region> regionsX = new List<Region>();
    private void FindRegions(VT pos)
    {
        var oq = new Queue<VT>();
        oq.Enqueue(pos);
        var region = new Region();
        region.seed = pos;
        regionsX.Add(region);
        cellToRegion.Add(pos, region);
        while (oq.Count > 0)
        {
            var fir = oq.Dequeue();
            var nei = new List<VT>(){
                (fir.Item1+1, fir.Item2),
                (fir.Item1-1, fir.Item2),
                (fir.Item1, fir.Item2+1),
                (fir.Item1, fir.Item2-1),
            };
            foreach (var n in nei)
            {
                if (cellToRegion.ContainsKey(n)) continue;//已经处理过了
                if (n.Item1 >= 0 && n.Item1 < G.Length && n.Item2 >= 0 && n.Item2 < G[0].Length)
                {
                    var gv = G[n.Item1][n.Item2];
                    if (gv == 1)
                    {
                        oq.Enqueue(n);
                        cellToRegion.Add(n, region);
                    }
                    else
                    {
                        if (!region.boundEdge.ContainsKey(n)) region.boundEdge[n] = 0;
                        region.boundEdge[n]++;
                    }
                }
            }
        }
    }
    private void Merge(Region p1, Region p2)
    {
        p1 = p1.GetTop();
        p2 = p2.GetTop();
        if (p1 == p2) return;
        p2.parent = p1;
        foreach (var b in p2.boundEdge)
        {
            if (!p1.boundEdge.ContainsKey(b.Key)) p1.boundEdge[b.Key] = 0;
            p1.boundEdge[b.Key] += b.Value;
        }
    }

    private void Enlarge(Region r)
    {
        r = r.GetTop();
        var oq = new Queue<VT>();
        //////Console.WriteLine("En:" + r.boundEdge.Count);
        var visB = new HashSet<VT>();
        foreach (var b in r.boundEdge)
        {
            if (!cellToRegion.ContainsKey(b.Key)) //边界已经被污染了
            {
                cellToRegion.Add(b.Key, r);
                G[b.Key.Item1][b.Key.Item2] = 1;
            }
        }
        foreach (var b in r.boundEdge)
        {
            visB.Add(b.Key);
            oq.Enqueue(b.Key);
        }
        // var newB = new HashSet<VT>();
        r.boundEdge.Clear();
        while (oq.Count > 0)
        {
            //////Console.WriteLine("BoundCount:"+r.boundEdge.Count);
            var fir = oq.Dequeue();
            var nei = new List<VT>(){
                (fir.Item1+1, fir.Item2),
                (fir.Item1-1, fir.Item2),
                (fir.Item1, fir.Item2+1),
                (fir.Item1, fir.Item2-1),
            };
            foreach (var n in nei)
            {
                //1 肯定都被处理过了
                if (cellToRegion.ContainsKey(n))
                {
                    var otherTop = cellToRegion[n].GetTop();
                    //对方已经是安全区了不能污染了 相当于碰到墙壁了
                    if (!otherTop.safe && otherTop != r)
                    {
                        var ob = otherTop.boundEdge;
                        if (!otherTop.enLargetYet) //未扩容则加入我的边界准备扩容 否则只是加入边界
                        {
                            //消除其它人的边界 融入我的边界
                            foreach (var b in ob)
                            {
                                if (!visB.Contains(b.Key))
                                {
                                    oq.Enqueue(b.Key);
                                    visB.Add(b.Key);
                                }
                                if (!cellToRegion.ContainsKey(b.Key))
                                {
                                    cellToRegion.Add(b.Key, r);
                                    G[b.Key.Item1][b.Key.Item2] = 1;
                                }
                            }
                        }
                        Merge(r, otherTop);
                    }
                    continue;//已经处理过了
                }
                if (n.Item1 >= 0 && n.Item1 < G.Length && n.Item2 >= 0 && n.Item2 < G[0].Length)
                {
                    var gv = G[n.Item1][n.Item2];
                    if (!r.boundEdge.ContainsKey(n)) r.boundEdge[n] = 0;
                    r.boundEdge[n]++;
                    //////Console.WriteLine("BV:" + r.boundEdge[n]);
                }
            }
        }
        var nb = new Dictionary<VT, int>();
        foreach (var b in r.boundEdge)
        {
            if (!cellToRegion.ContainsKey(b.Key))
            {
                nb[b.Key] = b.Value;
            }
        }
        r.boundEdge = nb;
        //////Console.WriteLine("BV:"+r.boundEdge.Count);
    }
    public int ContainVirus(int[][] grid)
    {
        G = grid;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                var cv = grid[i][j];
                var k = (i, j);
                if (cv == 1)
                {
                    if (!cellToRegion.ContainsKey(k))
                    {
                        FindRegions(k);
                    }
                }
            }
        }
        if (regionsX.Count == 0) return 0;
        var total = 0;
        var nullParRegion = regionsX;
    FindMax:
        Region maxR = null;
        int maxBound = -1;
        var maxI = 0;
        var index = 0;
        for (var i = 0; i < nullParRegion.Count; i++)
        {
            var r = nullParRegion[i];
            if (r.boundEdge.Count > maxBound && r.parent == null)
            {
                maxBound = r.boundEdge.Count;
                maxR = r;
                maxI = index;
            }
            index++;
        }
        var temp = nullParRegion[0];
        nullParRegion[0] = maxR;
        nullParRegion[maxI] = temp;
        //Console.WriteLine("MaxR:"+maxR.boundEdge.Count+":"+maxI+":"+temp.boundEdge.Count+":"+nullParRegion.Count+":"+maxR.seed);
        foreach (var b in maxR.boundEdge)
        {
            // //////Console.WriteLine(total+":"+b.Key+":"+b.Value);
            total += b.Value;
        }
        maxR.GetTop().safe = true;

        //////Console.WriteLine("total:"+total);
        var newNull = new List<Region>();
        for (var i = 1; i < nullParRegion.Count; i++)
        {
            var r = nullParRegion[i];
            if (r.parent == null)
            {
                //传染还是要传染的
                newNull.Add(r);
                //Console.WriteLine("Before:"+r.seed+":" + r.boundEdge.Count);
                r.enLargetYet = true;
                Enlarge(r);
                //Console.WriteLine("EnLarge:"+r.boundEdge.Count);
            }
        }
        foreach (var r in newNull) r.enLargetYet = false;
        nullParRegion = newNull;
        //Console.WriteLine("nullCount:"+nullParRegion.Count);
        // foreach(var l in G){
        //     //Console.WriteLine(JsonSerializer.Serialize(l));
        // }
        if (nullParRegion.Count > 0) goto FindMax;
        return total;
    }
}

public class Solution
{
    public int ContainVirus(int[][] grid)
    {
        var b = new Virtus();
        return b.ContainVirus(grid);
    }
}
// @lc code=end

