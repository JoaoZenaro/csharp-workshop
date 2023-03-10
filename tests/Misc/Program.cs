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


//var letters = new List<string> { "a", "b" }
//var query = letters.Select(w => w.ToUpper());
//letters.Add("z");
//foreach (var l in query)
//    Console.Write(l);


var stations = new List<string>
{
 "Kings Cross KGX",
 "Liverpool Street LVS",
 "Euston EUS",
 "New Street NST"
};
var query1 = from station in stations
             where station[^3..] == "LVS" || station[^3..] == "EUS" ||
             station[0..^3].Trim().ToUpper().EndsWith("CROSS")
             select new
             {
                 code = station[^3..],
                 name = station[0..^3].Trim().ToUpper()
             };


var query2 = from station in stations
             let code = station[^3..]
             let name = station[0..^3].Trim().ToUpper()
             where code == "LVS" || code == "EUS" ||
             name.EndsWith("CROSS")
             select new { code, name };