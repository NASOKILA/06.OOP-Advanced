using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Lake : IEnumerable<int>
{
    public Lake(int[] stones)
    {
        this.stones = stones;
    }

    private int[] stones;

    public IEnumerator<int> GetEnumerator()
    {
        List<int> result = new List<int>();
        
        for (int i = 0; i < this.stones.Length; i += 2)
            result.Add(this.stones[i]);
        
        if (this.stones.Length % 2 == 0)
        {
            for (int i = this.stones.Length - 1; i >= 0; i -= 2)
            {
                result.Add(this.stones[i]);
            }
        }
        else
        {
            for (int i = this.stones.Length - 2; i >= 0; i -= 2)
            {
                result.Add(this.stones[i]);
            }
        }

        for (int i = 0; i < result.Count; i++)
            yield return result[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}