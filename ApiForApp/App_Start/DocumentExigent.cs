using BSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class DocumentExigent
{
    public long DocumentExigentID { get; set; }
    public string DocumentExigentName { get; set; }

    public static string GetList(out List<DocumentExigent> lt)
    {
        return DBM.GetList("usp_DocumentExigent_SelectAll", new { }, out lt);
    }
}