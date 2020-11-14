using System;

static class IO{
	 public static string GetLine(String message=""){
		if(message.Length>0)
			Console.WriteLine(message);
		string str = Console.ReadLine();
		int index = str.LastIndexOf('R');
		if(index==-1)
			return str;
		else
			return str.Substring(index+1);		
	}
}