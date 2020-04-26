using BSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class DocumentField
{
    public long DocumentFieldID { get; set; }
    public string DocumentFieldName { get; set; }

    public static string GetList(out List<DocumentField> lt)
    {
        return DBM.GetList("usp_DocumentField_SelectAll", new { }, out lt);
    }
}