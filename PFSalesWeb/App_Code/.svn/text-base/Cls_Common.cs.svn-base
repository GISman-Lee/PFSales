using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;

/// <summary>
/// Summary description for Cls_Common
/// </summary>
public static class Cls_Common
{
    public static string GeneratePassword(bool lowerCase)
    {
        int size = 8;

        StringBuilder Password = new StringBuilder();

        Random random = new Random();

        char ch;

        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            Password.Append(ch);
        }
        if (lowerCase)
        {
            return Password.ToString().ToLower();
        }
        else { return Password.ToString(); }


        return Password.ToString();

    }

}
