using System;
using System.Linq;

public class Path
{
    public string PathCurrent { get; private set; }

    public Path(string path)
    {
        PathCurrent = path;
    }

    public void Current(string FPath)
    {
        if (FPath == "/")
        {
            PathCurrent = "/";
            return;
        }

        while (FPath.Length > 0)
        {
            if (FPath.Length > 1)
            {
                if (FPath.Substring(0, 2) == "..")
                {
                    if (!String.IsNullOrEmpty(PathCurrent))
                    {
                        PathCurrent = PathCurrent.Remove(PathCurrent.LastIndexOf("/", StringComparison.Ordinal));
                        if (String.IsNullOrEmpty(PathCurrent))
                        {
                            PathCurrent = "/";
                        }
                    }

                    FPath = FPath.Remove(0, 2);
                    continue;
                }
            }

            if (FPath[0] == '/')
            {
                FPath = FPath.Remove(0, 1);
                if (FPath[0] == '.')
                {
                    continue; 
                }
            }

            if (PathCurrent.Last() != '/')
            {
                PathCurrent += "/";
            }

            var nextPath = FPath.IndexOf("/", StringComparison.Ordinal);
            if (nextPath == -1)
            {
                PathCurrent += FPath;
                FPath = "";
            }
            else
            {
                PathCurrent += FPath.Substring(0, nextPath); 
                FPath = FPath.Remove(0, nextPath);
            }
        } 
    }

    public static void Main(string[] args)
    {
        Path path = new Path("/a/b/c/d");
        path.Current("../x");
        Console.WriteLine(path.CurrentPath);
        Console.ReadLine(); 
    }
}
