/*
 * @lc app=leetcode.cn id=1041 lang=csharp
 *
 * [1041] 困于环中的机器人
 */

// @lc code=start
public class Solution
{
    public bool IsRobotBounded(string instructions)
    {
        int len = instructions.Length;
        int x=0, y=0;
        int dir = 0;    //0->up, 1->right, 2->down, 3->left
        foreach(char ch in instructions)
        {
            if(ch=='R') dir = (dir+1) % 4;
            if(ch=='L') dir = (dir+3) % 4;
            if(ch=='G')
            {
                switch(dir)
                {
                    case 0: y++; break;
                    case 1: x++; break;
                    case 2: y--; break;
                    case 3: x--; break;
                }
            }
        }
        if((x==0 && y==0) || dir != 0) return true;
        return false;
    }
}
// @lc code=end

