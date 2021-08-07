using System;
  
class Palandrome {
  
    static int CHARS = 256;
  
    
    static bool canFormPalindrome(string str)
    {
  
        int[] count = new int[CHARS];
        Array.Fill(count, 0);
  
        for (int i = 0; i < str.Length; i++)
            count[(int)(str[i])]++;
  
        int odd = 0;
        for (int i = 0; i < CHARS; i++) {
            if ((count[i] & 1) == 1)
                odd++;
  
            if (odd > 1)
                return false;
        }
  
        return true;
    }
  
    // Test code
    public static void Main()
    {
        if (canFormPalindrome("NITIN"))
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");
  
        if (canFormPalindrome("LONDON"))
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");
    }
}
