//Linq to db , Linq to object
//query exprission , linq

List<int> source = new (){
1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32
};

var resultMany = from r in source
                 from l in source
                 where l+r>50
                 select r + l;
#region many


foreach (var result in resultMany)
{
    Console.Write(result+",");
}
Console.WriteLine("===============");
var resultManyLinq = source.SelectMany(e => source, (e, f) => f + e).Where(r=>r>50);
foreach (var result in resultManyLinq)
{
    Console.Write(result+",");
}

#endregion

#region operatorCannotBeDeffred because evaluate immediatly Like any , all ,contain ,single so these have another function anyasync,allasync,containasync
Console.WriteLine("Any: " + resultMany.Any(e => e >= 64));
Console.WriteLine("All: " + resultMany.All(e => e >= 64));
Console.WriteLine("Contains: " + resultMany.Contains(64));
#endregion


//be carerful when use elementat , count with where opeartor because it will evaluate count or element at each iteterate in loop if we use it because i enemerable didn't implement ilist or this nonindexable