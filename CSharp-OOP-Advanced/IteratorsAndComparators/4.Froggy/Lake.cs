using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Lake : IEnumerable<int>
{
    private List<int> list;

    public Lake(List<int> list)
    {
        this.list = list;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < list.Count; i += 2)
        {
            yield return list[i];
        }

        int cor = (list.Count % 2 == 0) ? 1 : 2;

        for (int i = list.Count - cor; i > 0; i -= 2)
        {
            yield return list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
