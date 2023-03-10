//var actions = new List<Action>();
//for (var i = 0; i < 5; i++)
//{
//    var j = i;
//    actions.Add(() => Console.WriteLine($"MyAction: i={i} j={j}"));
//}
//foreach (var action in actions)
//{
//    action();
//}


var letters = new List<string> { "a", "b" }
var query = letters.Select(w => w.ToUpper());
letters.Add("z");
foreach (var l in query)
    Console.Write(l);