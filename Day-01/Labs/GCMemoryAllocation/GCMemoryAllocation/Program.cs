using System;
using System.Collections.Generic;
Console.WriteLine(&quot;=== Garbage Collection Demo ===&quot;);
long before = GC.GetTotalMemory(true);
Console.WriteLine($&quot; Memory Before Allocation: { before / 1024}
KB & quot;);
CreatePatients();
GC.Collect();
GC.WaitForPendingFinalizers();
GC.Collect();
long after = GC.GetTotalMemory(true);
Console.WriteLine($&quot; Memory After Cleanup: { after / 1024}
KB & quot;);
Console.WriteLine($&quot; Difference From Start: { (after - before) / 1024}
KB & quot;);
static void CreatePatients()
{

.NET 9 · Visual Studio 2022 · Page 8

var patients = new List& lt; string&gt; ();
    for (int i = 0; i & lt; 50_000; i++)
    {
        patients.Add($&quot; Patient -{ i}
        &quot;);
}
long during = GC.GetTotalMemory(true);
Console.WriteLine($&quot; Memory During Allocation: