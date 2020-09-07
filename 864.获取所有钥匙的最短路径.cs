using System.Linq;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=864 lang=csharp
 *
 * [864] 获取所有钥匙的最短路径
 *
 * https://leetcode-cn.com/problems/shortest-path-to-get-all-keys/description/
 *
 * algorithms
 * Hard (41.22%)
 * Likes:    36
 * Dislikes: 0
 * Total Accepted:    1.2K
 * Total Submissions: 2.9K
 * Testcase Example:  '["@.a.#","###.#","b.A.B"]'
 *
 * 给定一个二维网格 grid。 "." 代表一个空房间， "#" 代表一堵墙， "@" 是起点，（"a", "b", ...）代表钥匙，（"A",
 * "B", ...）代表锁。
 * 
 * 
 * 我们从起点开始出发，一次移动是指向四个基本方向之一行走一个单位空间。我们不能在网格外面行走，也无法穿过一堵墙。如果途经一个钥匙，我们就把它捡起来。除非我们手里有对应的钥匙，否则无法通过锁。
 * 
 * 假设 K 为钥匙/锁的个数，且满足 1 <= K <= 6，字母表中的前 K
 * 个字母在网格中都有自己对应的一个小写和一个大写字母。换言之，每个锁有唯一对应的钥匙，每个钥匙也有唯一对应的锁。另外，代表钥匙和锁的字母互为大小写并按字母顺序排列。
 * 
 * 返回获取所有钥匙所需要的移动的最少次数。如果无法获取所有钥匙，返回 -1 。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：["@.a.#","###.#","b.A.B"]
 * 输出：8
 * 
 * 
 * 示例 2：
 * 
 * 输入：["@..aA","..B#.","....b"]
 * 输出：6
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= grid.length <= 30
 * 1 <= grid[0].length <= 30
 * grid[i][j] 只含有 '.', '#', '@', 'a'-'f' 以及 'A'-'F'
 * 钥匙的数目范围是 [1, 6]，每个钥匙都对应一个不同的字母，正好打开一个对应的锁。
 * 
 * 
 */

// @lc code=start

public class Solution {
    int[][] dirs=new int[][]{new int[]{0,1},new int[]{0,-1},new int[]{1,0},new int[]{-1,0}};
    public int ShortestPathAllKeys(string[] grid) {
        int m=grid.Length,n=grid[0].Length;
        int x=-1,y=-1,max=0;
        for(int i=0;i<m;i++)
        {
            for(int j=0;j<n;j++)
            {
                var ch=grid[i][j];
                if(ch=='@')
                {
                    x=i;
                    y=j;
                }
                if(ch>='a'&&ch<='f')
                {
                    max=Math.Max(max,ch-'a'+1);
                }
            }
        }
        var q=new Queue<(int key,int x,int y)>();
        var visited=new HashSet<(int key,int x,int y)>();
        q.Enqueue((0,x,y));
        visited.Add((0,x,y));
        int step=0;
        while(q.Count!=0)
        {
            int size=q.Count;
            while(size-->0)
            {
                var cur=q.Dequeue();
                if(cur.key==((1<<max)-1)) return step;
                foreach(var dir in dirs)
                {
                    int nx=cur.x+dir[0];
                    int ny=cur.y+dir[1];
                    if(nx<0||nx>=m||ny<0||ny>=n||grid[nx][ny]=='#')continue;
                    int key=cur.key;
                    var ch=grid[nx][ny];
                    if(ch>='a'&&ch<='f')
                        key=key|(1<<(ch-'a'));
                    if(ch>='A'&&ch<='F'&&((1<<(ch-'A'))&key)==0)continue;
                    if(!visited.Contains((key,nx,ny)))
                    {
                        q.Enqueue((key,nx,ny));
                        visited.Add((key,nx,ny));
                    }
                }
            }
            step++;
        }
        return -1;
    }
}

// @lc code=end

