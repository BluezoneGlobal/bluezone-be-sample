using BSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class DocumentType
{
    public long DocumentTypeID { get; set; }
    public string DocumentTypeName { get; set; }

    public static string GetList(out List<DocumentType> lt)
    {
        return DBM.GetList("usp_DocumentType_SelectAll", new { }, out lt);
    }
}