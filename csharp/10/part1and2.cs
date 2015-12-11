using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class Day10
{
	static void Main()
	{
		var s = Console.ReadLine().ToList();
		for(int i=0; i<50; i++){
			s = LookAndSay(s);
			Console.WriteLine(s.Count);
		}		
	}
	static List<char> LookAndSay(List<char> s){
		var tuple = s.Skip(1).Aggregate(
			new {res=new List<char>(), ch=s[0], count=1}, 
			(t, c) => 
				c == t.ch 
				? new {res=t.res, ch=c, count=t.count+1}
				: new {res=t.res.With(""+t.count + t.ch), ch=c, count=1});
		return tuple.res.With("" + tuple.count + tuple.ch);
	}
	
	static List<T> With<T>(this List<T> list, IEnumerable<T> items){
		list.AddRange(items);
		return list;
	}
}
