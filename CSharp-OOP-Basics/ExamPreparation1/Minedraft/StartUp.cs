using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        var draftManager = new DraftManager();
        draftManager.Mode(new List<string>() { "Energy" });
    }
}