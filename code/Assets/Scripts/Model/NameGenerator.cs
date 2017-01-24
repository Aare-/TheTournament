using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public class NameGenerator {

    private string[] names = {"Maximus", "Brutus", "Luxus", "Aulus", "Cicero", "Fabius", "Gaius", "Nero", "Vitus", "Titus" , "Crixus", "Spartacus", "Spiritus", "Jagielonian", "Ujotus"};
    private string[][] prefixes = new string[][]
    {
        new[]{"Fallen", "Noob", "Scumbag", "Faggot", "Slow", "Little"},
        new[]{"Great", "Good"},
        new[]{"Super", "Uber", "Master"} 
    };
    private Dictionary<string, int> postfixDicionary;
    
 
    public NameGenerator()
    {
        Random.seed = (int)DateTime.Now.Ticks;
        
        postfixDicionary = new Dictionary<string, int>();
        for (int index = 0; index < names.Length; index++)
        {
            postfixDicionary.Add(names[index], 0);
        }
    }

    public string GenerateName(int index = 0)
    {
        string name = names[Random.Range(0, names.Length)];
        if (index > 0) name = GetPrefix(index) + " " + name;
        name += " " + GetUniquePostFixNumber(name);
        return name;
    }

    private string GetPrefix(int index)
    {
        return prefixes[index][Random.Range(0, prefixes[index].Length)];
    }

    private string GetUniquePostFixNumber(String name)
    {
        int postfix;
        
        postfixDicionary.TryGetValue(name, out postfix);
        postfix++;
        postfixDicionary[name] = postfix;
        
        return Roman.To(postfix);
    }

    public string AddPrefix(string name, int level)
    {
        return GetPrefix(level) + " " + name;
    }
}
