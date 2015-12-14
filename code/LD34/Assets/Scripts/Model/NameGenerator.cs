using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator {

    private int _level = 0;
    private Dictionary<int, string> titles;
    private System.String[] names = {"Maximus", "Brutus", "Luxus", "Aulus", "Cicero", "Fabius", "Gaius", "Nero", "Vitus", "Titus" , "Crixus", "Spartacus", "Spiritus", "Jagielonian", "Ujotus"};

    public NameGenerator()
    {
        titles = new Dictionary<int, string>();
        titles.Add(0, "");
    }

    public string GenerateName(int index = 0)
    {
        string name = names[Random.Range(0, names.Length)];
        if(index > 0){
            string title;
            if(titles.TryGetValue(index, out title))
                return title + " " + name;
        }
        return name;
    }

}
